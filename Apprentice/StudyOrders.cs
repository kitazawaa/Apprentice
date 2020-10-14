using System;

namespace Entity
{
    public class StudyOrders
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public string PatientId { get; set; }

        public int StudyStatus { get; set; }

        public int ProcessingDivision { get; set; }

        public DateTime ScheduledOn { get; set; }

        public DateTime StudiedAt { get; set; }

        public int StudyTypeCode { get; set; }

        public string StudyTypeName { get; set; }

        public string Comment { get; set; }

        public DateTime StudyCreatedAt { get; set; }

        public DateTime StudyUpdatedAt { get; set; }

        public int IsDeleted { get; set; }


    }
}
