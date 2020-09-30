using System;
using System.Collections.Generic;

namespace WorkHour.Data.Models
{
    public partial class BusinessList
    {
        public BusinessList()
        {
            Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string BusinessName { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public string Explanation { get; set; }
        public string TaskExplanation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatorPersonel { get; set; }
        public DateTime CreationDate { get; set; }
        public int PersonelId { get; set; }
        public bool Deleted { get; set; }
        public int CustomerId { get; set; }
        public int ProjectDescriptionId { get; set; }
        public int BusinessPriority { get; set; }
        public int StatusId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime LastDateStudied { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}
