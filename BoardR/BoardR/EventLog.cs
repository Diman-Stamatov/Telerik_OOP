using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardR.ValidationHelpers;

namespace BoardR
{
    
    internal class EventLog
    {
        private string description;
        private DateTime time;
        

        public string Description
        {
            get
            {
                return this.description;
            }

            private set
            {
                ValidateEventDescription(value);
                this.description = value;

            }

        }
        public DateTime Time
        {
            get { return this.time; }
        }

        public EventLog(string description)
        {
            this.Description= description;
            this.time = DateTime.Now;
        }

        public string ViewInfo()
        {
            return $"[{this.Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}] {this.Description}";

        }
    }
}
