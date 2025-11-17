using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;

namespace LawFirmManagementSystem_Business
{
    public class Client
    {
        public enum enMode { UpdateMode = 0 , AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;
        public int ClientId { get; set; }
        public int PersonId { get; set; }
        private Person _personInfo;
        public Person PersonInfo
        {
            get
            {
                return _personInfo;
            }
            set { _personInfo = value; }

        }
        public int TrackingChangesId { get; set; }
        private TrackingChanges _trackingChangesInfo;
        public TrackingChanges TrackingChangesInfo
        {
            get
            {
                return _trackingChangesInfo;
            }
            set { _trackingChangesInfo = value; }
        }
        public string Notes { get; set; }
        public Client()
        {
            ClientId = 0;
            PersonId = 0;
            TrackingChangesId = 0;
            Notes = string.Empty;
            _personInfo = new Person();
            _trackingChangesInfo = new TrackingChanges();
            mode = enMode.AddNewMode;
        }
        private Client(int clientId , int personId , int trackingChangesId, string notes)
        {
            ClientId=clientId;
            PersonId=personId;
            TrackingChangesId=trackingChangesId;
            Notes=notes;

            _personInfo = Person.GetPerson(personId);
            _trackingChangesInfo = TrackingChanges.GetTrackingChanges(personId);

            mode = enMode.UpdateMode;
        }
        public static Client GetClient(int clientId)
        {
            int personId = 0, trackingChangesId = 0;
            string notes = string.Empty;
            if (ClientsDataAccess.GetClient(clientId, ref personId, ref trackingChangesId, ref notes))
            {
                return new Client(clientId, personId, trackingChangesId, notes);
            }
            return new Client();
        }
        public static DataTable GetAllClients()
        {
            return ClientsDataAccess.GetAllClients();
        }
        private bool _UpdateClient() =>
            ClientsDataAccess.UpdateClient(ClientId, PersonInfo.FullName, PersonInfo.Phone, PersonInfo.Address, TrackingChangesInfo.LastUpdatedBy, Notes);
        private bool _AddNewClient()
        {
            ClientId =  ClientsDataAccess.AddClient(PersonInfo.FullName, PersonInfo.Phone, PersonInfo.Address, TrackingChangesInfo.CreatedBy, Notes);
            return (ClientId > 0);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateClient();
                    break;
                case enMode.AddNewMode:
                    if (_AddNewClient())
                    {
                        mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
        public static bool DeleteClient(int clientId) => ClientsDataAccess.DeleteClient(clientId);
    }
}
