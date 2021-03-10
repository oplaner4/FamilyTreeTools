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

        [JsonProperty]
        public Guid Id { get; protected set; }

        public string FullName { get; private set; }

        public Human SetFullName(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw new ArgumentNullException("Empty full name not allowed.", nameof(arg));
            }

            FullName = arg;
            return this;
        }

        public StatusOptions Status { get; set; }

        public DateTime BirthDate { get; private set; }

        [JsonProperty]
        public DateTime? DeathDate { get; private set; }

        public bool IsDead()
        {
            return DeathDate != null;
        }

        public Human SetDeathDate(DateTime arg)
        {
            if (arg < BirthDate)
            {
                throw new ArgumentException("The death date before birth date.", nameof(arg));
            }

            DeathDate = arg;
            return this;
        }
    }
}
