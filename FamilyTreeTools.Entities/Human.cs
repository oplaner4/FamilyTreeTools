using Newtonsoft.Json;
using System;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Human
    {
        public enum StatusOptions
        {
            Unmarried,
            Married,
        }

        [JsonConstructor]
        public Human ()
        { }

        public Human(string fullName, DateTime birthDate) {

            SetBirthDate(birthDate);

            Status = new PropHistory<StatusOptions>().AddChange(StatusOptions.Unmarried, BirthDate);
            FullName = new PropHistory<string>((value, _) =>
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Empty full name is not allowed.");
                }
            }).AddChange(fullName, BirthDate);
            Id = Guid.NewGuid();
        }

        private Guid _Id { get; set; }

        [JsonProperty]
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (value == Guid.Empty)
                {
                    throw new Exception("Trying to set an empty guid.");
                }

                _Id = value;
            }
        }

        [JsonProperty]
        public PropHistory<string> FullName { get; set; }

        [JsonProperty]
        public PropHistory<StatusOptions> Status { get; set; }

        private DateTime _BirthDate { get; set; }

        [JsonProperty]
        public DateTime BirthDate {
            get {
                return _BirthDate;
            }
            set {
                SetBirthDate(value);
            }
        }

        private Human SetBirthDate(DateTime arg)
        {
            if (arg > DateTime.Now)
            {
                throw new ArgumentException("The birth date is in the future.", nameof(arg));
            }

            _BirthDate = arg;
            return this;
        }

        private DateTime? _DeathDate { get; set; }

        [JsonProperty]
        public DateTime? DeathDate {
            get {
                return _DeathDate;
            }
            set {
                Died(value);
            }
        }

        public bool IsDeadAt (DateTime d)
        {
            return DeathDate <= d;
        }

        public bool AfterDeath(DateTime d)
        {
            return d > DeathDate;
        }

        public Human Died(DateTime? arg)
        {
            if (arg < BirthDate)
            {
                throw new ArgumentException("The death date is before the birth date.", nameof(arg));
            }

            if (arg > DateTime.Now)
            {
                throw new ArgumentException("The death date is in the future.", nameof(arg));
            }

            _DeathDate = arg;
            return this;
        }

        public bool BeforeBirthday (DateTime at)
        {
            return at.Month < BirthDate.Month || (at.Month == BirthDate.Month && at.Day < BirthDate.Day);
        }

        public int GetAge(DateTime? at = null)
        {
            DateTime d = at ?? DateTime.Now;

            int result = d.Year - BirthDate.Year;

            if (BeforeBirthday(d))
            {
                result--;
            }

            return result;
        }
    }
}
