using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardR.ValidationHelpers;

namespace BoardR.BoardItems
{

    internal class EventLog
    {
        private string description;
        private DateTime time;


        public string Description
        {
            get
            {
                return description;
            }

            private set
            {
                ValidateEventDescription(value);
                description = value;

            }

        }
        public DateTime Time
        {
            get { return time; }
        }

        public EventLog(string description)
        {
            Description = description;
            time = DateTime.Now;
        }

        public string ViewInfo()
        {
            return $"[{Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}] {Description}";

        }
    }
}
