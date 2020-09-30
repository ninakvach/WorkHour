using System;
using System.Collections.Generic;

namespace WorkHour.Data.Models
{
    public partial class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public string Area { get; set; }
        public int PersonelId { get; set; }
        public bool Deleted { get; set; }
        public bool WorkConfirmation { get; set; }
        public string Explanation { get; set; }

        public virtual Personel Personel { get; set; }
    }
}
