using System;
using System.Collections.Generic;

namespace WorkHour.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ProjectDescription = new HashSet<ProjectDescription>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ProjectDescription> ProjectDescription { get; set; }
    }
}
