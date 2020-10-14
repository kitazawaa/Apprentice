using Entity;
using System;

namespace ClassLibrary
{
    public class WorkItem
    {
        private Patients _patient;
        private StudyOrders _study;
        private ShotItems _shot;

        public WorkItem(Patients patient, StudyOrders study, ShotItems shot)
        {
            this._patient = patient;
            this._study = study;
            this._shot = shot;
        }

        public string OrderNumber
        {
            get => _study.OrderNumber;
            set => _study.OrderNumber = value;
        }

        public string StudyStatus
        {
            get => _study.StudyStatus;
            set => _study.StudyStatus = value;
        }

        public DateTime ScheduledOn
        {
            get => _study.ScheduledOn;
            set => _study.ScheduledOn = value;
        }

        public string PatientId
        {
            get => _patient.PatientId;
            set => _patient.PatientId = value;
        }

        public string PatientKanjiName
        {
            get => _patient.PatientKanjiName;
            set => _patient.PatientKanjiName = value;
        }

        public string PatientKanaName
        {
            get => _patient.PatientKanaName;
            set => _patient.PatientKanaName = value;
        }

        public string StudyTypeName
        {
            get => _study.StudyTypeName;
            set => _study.StudyTypeName = value;
        }

        public string ShotItemName
        {
            get => _shot.ShotItemName;
            set => _shot.ShotItemName = value;
        }

        public string Comment
        {
            get => _study.Comment;
            set => _study.Comment = value;
        }

        public DateTime StudyUpdatedAt
        {
            get => _study.StudyUpdatedAt;
            set => _study.StudyUpdatedAt = value;
        }
    }
}
