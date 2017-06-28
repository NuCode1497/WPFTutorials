using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL2.Models;
using System.Data.Entity;

namespace AutoLotDAL2.Repos
{
    public class CarRepo:BaseRepo<Car>,IRepo<Car>
    {
        public CarRepo()
        {
            Table = Context.Inventory;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Car() { CarId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Car() { CarId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
