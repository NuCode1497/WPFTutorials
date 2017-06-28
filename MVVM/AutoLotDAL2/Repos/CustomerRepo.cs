using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL2.Models;
using System.Data.Entity;

namespace AutoLotDAL2.Repos
{
    public class CustomerRepo : BaseRepo<Customer>, IRepo<Customer>
    {
        public CustomerRepo()
        {
            Table = Context.Customers;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Customer() { CustId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Customer() { CustId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
