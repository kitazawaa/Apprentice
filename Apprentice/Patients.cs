using System;

namespace Entity
{
    public class Patients
    {
        public int Id { get; set; }

        public string PatientId { get; set; }

        public string PatientKanjiName { get; set; }

        public string PatientKanaName { get; set; }

        public DateTime PatientBirthDate { get; set; }

        public string PatientGender { get; set; }

        public DateTime PatientCreatedAt { get; set; }

        public DateTime PatientUpdatedAt { get; set; }

        public int IsDeleted { get; set; }

        public static implicit operator Patients(Patients v)
        {
            throw new NotImplementedException();
        }
    }
}
