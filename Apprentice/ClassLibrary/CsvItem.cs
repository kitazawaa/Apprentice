using System.Collections.Generic;

namespace ClassLibrary
{
    public class CsvItem
    {
        public string OrderNumber { get; set; }
        public string ScheduledOn { get; set; }
        public string ProcessingDivision { get; set; }
        public string StudyTypeCode { get; set; }
        public string StudyTypeName { get; set; }
        public string PatientId { get; set; }
        public string PatientKanjiName { get; set; }
        public string PatientKanaName { get; set; }
        public string PatientBirthDate { get; set; }
        public string PatientGender { get; set; }
        public List<ShotItemSet> ShotItemSet { get; set; }
    }
}
