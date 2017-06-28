using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL2.Models;
using System.Data.Entity;

namespace AutoLotDAL2.Repos
{
    public class CreditRiskRepo : BaseRepo<CreditRisk>, IRepo<CreditRisk>
    {
        public CreditRiskRepo()
        {
            Table = Context.CreditRisks;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new CreditRisk() { CustId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new CreditRisk() { CustId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
