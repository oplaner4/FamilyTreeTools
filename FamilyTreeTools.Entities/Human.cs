using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Linq;

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

        /// <summary>
        /// This constructor is used only during deserialization.
        /// </summary>
        [JsonConstructor]
        public Human()
        { }

        protected virtual void Initialize()
        {
            FullName = new PropHistory<string>((value, _) =>
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new HistoryViolationException("An empty full name.");
                }
            });
        }

        public Human(string birthFullName, DateTime birthDate)
        {
            Initialize();

            SetBirthDate(birthDate);
            Status = new PropHistory<StatusOptions>().AddChange(StatusOptions.Unmarried, BirthDate);
            FullName.AddChange(birthFullName, BirthDate);
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
                    throw new NullReferenceException("Trying to set an empty guid.");
                }

                _Id = value;
            }
        }

        private PropHistory<string> _FullName { get; set; }

        [JsonProperty]
        public PropHistory<string> FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                _FullName = value ?? throw new NullReferenceException("Trying to set null fullname.");
            }
        }

        private PropHistory<StatusOptions> _Status { get; set; }

        [JsonProperty]
        public PropHistory<StatusOptions> Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value ?? throw new NullReferenceException("Trying to set null status.");
            }
        }

        private DateTime _BirthDate { get; set; }

        [JsonProperty]
        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                SetBirthDate(value);
            }
        }

        private Human SetBirthDate(DateTime arg)
        {
            if (arg > DateTime.Now)
            {
                throw new HistoryViolationException("Birth date is in the future.");
            }

            _BirthDate = arg;
            return this;
        }

        private DateTime? _DeathDate { get; set; }

        [JsonProperty]
        public DateTime? DeathDate
        {
            get
            {
                return _DeathDate;
            }
            set
            {
                Died(value);
            }
        }

        public bool IsDead(DateTime at)
        {
            return DeathDate <= at;
        }

        public Human Died(DateTime? arg)
        {
            if (arg < BirthDate)
            {
                throw new HistoryViolationException("Death date is before the birth date.");
            }

            if (arg > DateTime.Now)
            {
                throw new HistoryViolationException("Death date is in the future.");
            }

            _DeathDate = arg;
            return this;
        }

        public bool BeforeBirthday(DateTime at)
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

        public bool IsBorn(DateTime at, bool canBeDead = false)
        {
            return BirthDate <= at && (canBeDead || !IsDead(at));
        }

        public bool WasEverMarried()
        {
            return Status.Changes.Values.Any(v => v == StatusOptions.Married);
        }

        public bool WasMarried(DateTime at)
        {
            return Status.Value(at) == StatusOptions.Married;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}, *{1}{3} ({2})",
                FullName.Value(BirthDate),
                BirthDate.ToString("dd/MM/yyyy"),
                GetAge(),
                DeathDate.HasValue ?
                    string.Format(
                        ", +{0}",
                        DeathDate.Value.ToString("dd/MM/yyyy")
                    ) : string.Empty
            );
        }
    }
}
