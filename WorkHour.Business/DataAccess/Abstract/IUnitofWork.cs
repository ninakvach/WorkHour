using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkHour.Data.Models;

namespace WorkHour.Business.DataAccess.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        WorkHourContext Context { get; }
        IRepository<Activity> Activities { get; }

        IRepository<Work> Works { get; }
        IRepository<Claim> Claims { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Personel> Personels { get; }
        IRepository<ProjectDescription> ProjectDescriptions { get; }
        IRepository<BusinessList> Business { get; }
        
    }
}
