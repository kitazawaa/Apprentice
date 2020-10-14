using System;

namespace ClassLibrary
{
    public class WorkItemDetails
    {
        public WorkItemDetails()
        {
        }
        
        public DateTime StudiedAt { get; set; }

        public DateTime PatientBirthDate { get; set; }

        public string PatientGender { get; set; }
    }
}