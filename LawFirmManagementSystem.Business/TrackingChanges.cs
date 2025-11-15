using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirmManagementSystem.Business
{
    public class TrackingChanges
    {
        public int TrackingChangesId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public TrackingChanges()
        {
            TrackingChangesId = 0;
            CreatedBy = 0;
            CreatedDate = DateTime.MinValue;
            LastUpdatedBy = 0;
            LastUpdatedDate = DateTime.MinValue;
        }
        private TrackingChanges(int trackingChangesId, int createdBy, DateTime createdDate, int lastUpdatedBy, DateTime lastUpdatedDate)
        {
            TrackingChangesId = trackingChangesId;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedDate = lastUpdatedDate;
        }
        public static TrackingChanges GetTrackingChanges(int trackingChangesId)
        {
            int createdBy = 0, updatedBy = 0;
            DateTime createdDate = DateTime.MinValue, updatedDate = DateTime.MinValue;
            if (Data.TrackingChangesDataAccess.GetTrackingChanges(trackingChangesId, ref createdBy, ref createdDate, ref updatedBy, ref updatedDate))
            {
                return new TrackingChanges(trackingChangesId, createdBy, createdDate, updatedBy, updatedDate);
            }
            return new TrackingChanges();
        }
    }
}
