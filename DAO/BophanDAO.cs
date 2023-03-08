using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class BophanDAO
    {
        RestaurantManagerContext db= new RestaurantManagerContext();
        public BophanDAO() { }

        public BoPhan bophantheoma(int mabp)
        {
            var bophan = db.BoPhans.SingleOrDefault(bp => bp.MaBoPhan == mabp);
            return (BoPhan)bophan;
        }
        public List<BoPhan> dsBoPhan()
        {
            var bophan = from bp in db.BoPhans
                         select bp;
            List<BoPhan> list= new List<BoPhan>();
            foreach(var item in bophan)
            {
                list.Add(item);
            }
            return list;
        }
        public void thembophan(BoPhan bophan)
        {
            db.BoPhans.Add(bophan);
            db.SaveChanges();
        }
        public void xoabophan(int mabp)
        {
            var bophan = db.BoPhans.SingleOrDefault(bp => bp.MaBoPhan == mabp);
            db.BoPhans.Remove(bophan);
            db.SaveChanges();
        }
        public void suabophan(int mabp,string tenbophan)
        {
            var bophan = db.BoPhans.SingleOrDefault(bp => bp.MaBoPhan == mabp);
            bophan.TenBoPhan = tenbophan;
            db.SaveChanges();
        }
    }
}
