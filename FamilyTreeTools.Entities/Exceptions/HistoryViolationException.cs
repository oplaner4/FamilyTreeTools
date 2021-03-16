using System;

namespace FamilyTreeTools.Entities.Exceptions
{
    public class HistoryViolationException : Exception
    {
        public HistoryViolationException()
        {
        }

        public HistoryViolationException(string message)
            : base(message)
        {
        }

        public HistoryViolationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
