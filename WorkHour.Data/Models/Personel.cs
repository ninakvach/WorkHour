using System;
using System.Collections.Generic;

namespace WorkHour.Data.Models
{
    public partial class Personel
    {
        public Personel()
        {
            Work = new HashSet<Work>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mission { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Work> Work { get; set; }
    }
}
