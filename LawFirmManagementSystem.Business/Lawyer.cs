using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirmManagementSystem_Business
{
    public class Lawyer
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        public int LawyerId { get; set; }
        public int PersonId { get; set; }
        public Person PersonInfo
        {
            get
            {
                return Person.GetPerson(PersonId);
            }
        }
        public int TrackingChangesId { get; set; }

        public TrackingChanges TrackingChangesInfo
        {
            get
            {
                return TrackingChanges.GetTrackingChanges(TrackingChangesId);
            }
        }

        public string Notes { get; set; }

        public Lawyer()
        {
            LawyerId = 0;
            PersonId = 0;
            TrackingChangesId = 0;
            Notes = string.Empty;
            mode = enMode.AddNewMode;
        }

        private Lawyer(int lawyerId, int personId, int trackingChangesId, string notes)
        {
            LawyerId = lawyerId;
            PersonId = personId;
            TrackingChangesId = trackingChangesId;
            Notes = notes;
            mode = enMode.UpdateMode;
        }
        public static Lawyer GetLawyer(int lawyerId)
        {
            int personId = 0, trackingChangesId = 0;
            string notes = string.Empty;

            if (LawyersDataAccess.GetLawyer(lawyerId, ref personId, ref trackingChangesId, ref notes))
            {
                return new Lawyer(lawyerId, personId, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new Lawyer();
        }

        public static DataTable GetAllLawyers()
        {
            return LawyersDataAccess.GetAllLawyers();
        }

        public static bool DeleteLawyer(int lawyerId) => LawyersDataAccess.DeleteLawyer(lawyerId);

        private bool _UpdateLawyer()
        {
            // This method relies on the PersonInfo and TrackingChangesInfo properties
            // to get the FullName, Phone, Address, and LastUpdatedBy.
            return LawyersDataAccess.UpdateLawyer(
                LawyerId,
                PersonInfo.FullName,
                PersonInfo.Phone,
                PersonInfo.Address,
                TrackingChangesInfo.LastUpdatedBy,
                Notes);
        }

        private bool _AddNewLawyer()
        {
            // This method relies on the PersonInfo and TrackingChangesInfo properties
            // to be populated *before* SaveLawyer() is called.
            LawyerId = LawyersDataAccess.AddLawyer(
                PersonInfo.FullName,
                PersonInfo.Phone,
                PersonInfo.Address,
                TrackingChangesInfo.CreatedBy,
                Notes);

            return (LawyerId > 0);
        }

        public bool SaveLawyer()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateLawyer();

                case enMode.AddNewMode:
                    if (_AddNewLawyer())
                    {
                        // If add new is successful, switch to UpdateMode
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
    }
}
