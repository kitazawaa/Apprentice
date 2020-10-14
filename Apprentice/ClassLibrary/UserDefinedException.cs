using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class OrderNumberException : Exception
    {
        public OrderNumberException(string message) : base(message)
        {

        }
    }

    public class ScheduledOnException : Exception
    {
        public ScheduledOnException(string message) : base(message)
        {

        }
    }

    public class ProcessingDivisionException : Exception
    {
        public ProcessingDivisionException(string message) : base(message)
        {

        }
    }

    public class StudyTypeCodeException : Exception
    {
        public StudyTypeCodeException(string message) : base(message)
        {

        }
    }

    public class StudyTypeNameException : Exception
    {
        public StudyTypeNameException(string message) : base(message)
        {

        }
    }

    public class PatientIdException : Exception
    {
        public PatientIdException(string message) : base(message)
        {

        }
    }

    public class PatientKanjiNameException : Exception
    {
        public PatientKanjiNameException(string message) : base(message)
        {

        }
    }

    public class PatientKanaNameException : Exception
    {
        public PatientKanaNameException(string message) : base(message)
        {

        }
    }

    public class PatientBirthDateException : Exception
    {
        public PatientBirthDateException(string message) : base(message)
        {

        }
    }

    public class PatientGenderException : Exception
    {
        public PatientGenderException(string message) : base(message)
        {

        }
    }

    public class ShotItemCodeException : Exception
    {
        public ShotItemCodeException(string message) : base(message)
        {

        }
    }

    public class ShotItemNameException : Exception
    {
        public ShotItemNameException(string message) : base(message)
        {

        }
    }
}
