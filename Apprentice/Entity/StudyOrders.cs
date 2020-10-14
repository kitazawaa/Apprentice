using System;

namespace Entity
{
    public class StudyOrders
    {
        public string OrderNumber { get; set; }

        public string StudyStatus { get; set; }

        public DateTime ScheduledOn { get; set; }

        public string StudyTypeName { get; set; }

        public string Comment { get; set; }

        public DateTime StudyUpdatedAt { get; set; }
    }
}
