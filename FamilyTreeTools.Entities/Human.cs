using Newtonsoft.Json;
using System;

namespace FamilyTreeTools.Entities
{
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
            SetFullName(fullName);
            Status = StatusOptions.Unmarried;

            if (birthDate > DateTime.Now)
            {
                throw new ArgumentException("The birth date not in past.", nameof(birthDate));
            }

            BirthDate = birthDate;
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
                    throw new Exception("Trying to set empty guid.");
                }

                _Id = value;
            }
        }

        private string _FullName { get; set; }

        [JsonProperty]
        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                SetFullName(value);
            }
        }

        public Human SetFullName(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw new ArgumentNullException("Empty full name not allowed.", nameof(arg));
            }

            _FullName = arg;
            return this;
        }

        public StatusOptions Status { get; set; }

        [JsonProperty]
        public DateTime BirthDate { get; set; }

        private DateTime? _DeathDate { get; set; }

        [JsonProperty]
        public DateTime? DeathDate {
            get {
                return _DeathDate;
            }
            set {
                SetDeathDate(value);
            }
        }

        public bool IsDead()
        {
            return _DeathDate != null;
        }

        public Human SetDeathDate(DateTime? arg)
        {
            if (arg < BirthDate)
            {
                throw new ArgumentException("The death date before birth date.", nameof(arg));
            }

            _DeathDate = arg;
            return this;
        }
    }
}
