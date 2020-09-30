using System;
using System.Collections.Generic;

namespace WorkHour.Data.Models
{
    public partial class ProjectDescription
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int CustomerId { get; set; }
        public bool Deleted { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
