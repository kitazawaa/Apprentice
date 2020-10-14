using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class ValidatedStudyItems
    {
        public int OrderNumber { get; set; }
        public int ProcessingDivision { get; set; }
        public DateTime ScheduledOn { get; set; }
        public string StudyTypeCode { get; set; }
        public string StudyTypeName { get; set; }
        public List<ShotItemSet> ShotItemSet { get; set; }
    }
}
