using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class BanDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public void suaban(int maban,string status)
        {
            var ban = db.Bans.SingleOrDefault(b => b.MaBan == maban);
            ban.Status=status;
            db.SaveChanges();
        }
        public List<Ban> dsban() {
            var ban = from b in db.Bans
                      select b;
            List<Ban> list = ban.ToList() ;
            return list ;
        }
        public Ban bantheoma(int maban)
        {
            var ban= db.Bans.SingleOrDefault(b=>b.MaBan== maban);
            return (Ban)ban;
        }
    }
}
