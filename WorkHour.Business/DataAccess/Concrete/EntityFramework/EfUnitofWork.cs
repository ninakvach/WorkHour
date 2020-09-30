using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkHour.Business.DataAccess.Abstract;
using WorkHour.Data.Models;

namespace WorkHour.Business.DataAccess.Concrete.EntityFramework
{
    public class EfUnitofWork : IUnitofWork
    {
        private WorkHourContext _context;
        public EfUnitofWork(WorkHourContext context)
        {
            _context = context ?? throw new ArgumentNullException("dbcontext can not be null");
        }
        public WorkHourContext Context
        {
            get
            {
                return _context;

            }
        }



        private IRepository<Claim> _claim;

       
        public IRepository<Claim> Claims
        {
            get
            {
                return _claim ?? (_claim = new EFGenericRepository<Claim>(_context));
            }
        }
        private IRepository<Work> _work;
        public IRepository<Work> Works
        {
            get
            {
                return _work ?? (_work = new EFGenericRepository<Work>(_context));
            }
        }
        private IRepository<Customer> _customer;
        public IRepository<Customer> Customers
        {
            get
            {
                return _customer ?? (_customer = new EFGenericRepository<Customer>(_context));
            }
        }
        private IRepository<Personel> _personel;
        public IRepository<Personel> Personels
        {
            get
            {
                return _personel ?? (_personel = new EFGenericRepository<Personel>(_context));
            }
        }
        private IRepository<Activity> _activity;
        public IRepository<Activity> Activities
        {
            get
            {
                return _activity ?? (_activity = new EFGenericRepository<Activity>(_context));
            }
        }
        private IRepository<BusinessList> _businessList;
        public IRepository<BusinessList> Business
        {
            get
            {
                return _businessList ?? (_businessList = new EFGenericRepository<BusinessList>(_context));
            }
        }

        private IRepository<ProjectDescription> _projectDescription;
        public IRepository<ProjectDescription> ProjectDescriptions
        {
            get
            {
                return _projectDescription ?? (_projectDescription = new EFGenericRepository<ProjectDescription>(_context));
            }
        }
        public void dispose()
        {
            _context.Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
