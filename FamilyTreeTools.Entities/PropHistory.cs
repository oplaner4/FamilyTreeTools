﻿using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class PropHistory<T>
    {
        public delegate void CorrectValueChecker(T value, DateTime since);

        [JsonConstructor]
        public PropHistory(CorrectValueChecker checker = null)
        {
            Changes = new Dictionary<DateTime, T>();
            Checker = checker;
        }

        private Dictionary<DateTime, T> _Changes { get; set; }

        [JsonProperty]
        public Dictionary<DateTime, T> Changes
        {
            get
            {
                return _Changes;
            }
            set
            {
                _Changes = value ?? throw new Exception("Trying to set null changes.");
            }
        }

        private CorrectValueChecker Checker { get; set; }

        public PropHistory<T> AddChange(T value, DateTime since)
        {
            if (Changes.ContainsKey(since))
            {
                throw new HistoryViolationException("Trying to replace an existing change.");
            }

            if (since > DateTime.Now)
            {
                throw new HistoryViolationException("A new change is going to happen in the future.");
            }

            Checker?.Invoke(value, since);
            Changes.Add(since, value);
            return this;
        }

        public DateTime GetLatestChangeDate()
        {
            return Changes.Keys.Max();
        }

        public T ValueAt(DateTime d)
        {
            try
            {
                DateTime useChange = Changes.Keys.Where(since => d >= since).OrderBy(since => d - since).First();
                return Changes[useChange];
            }
            catch (InvalidOperationException e)
            {
                throw new ArgumentException("Unable to find a value in the history", nameof(d), e);
            }
        }
    }
}
