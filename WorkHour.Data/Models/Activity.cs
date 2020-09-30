using System;
using System.Collections.Generic;

namespace WorkHour.Data.Models
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string CreateUser { get; set; }
        public int PersonelId { get; set; }
        public string Explanation { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public string Status { get; set; }
        public int BusinessId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public int TotalTime { get; set; }

        public virtual BusinessList Business { get; set; }
    }
}
