using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class NhaccDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public List<NhaCungCap> dsnhacc()
        {
            var nhacc = from ncc in db.NhaCungCaps
                        select ncc;
            return nhacc.ToList();
        }
        public NhaCungCap ncctheoma(int ma)
        {
            var nhacc = db.NhaCungCaps.SingleOrDefault(ncc => ncc.MaNhaCungCap == ma);
            return (NhaCungCap)nhacc;
        }
        public void themncc(string ten, string dc, string sdt,string email)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.TenNhaCungCap = ten;
            nhaCungCap.DiaChi = dc;
            nhaCungCap.DienThoai = sdt;
            nhaCungCap.Email = email;
            db.NhaCungCaps.Add(nhaCungCap);
            db.SaveChanges();
        }
        public void suancc(int ma,string ten, string dc, string sdt, string email)
        {
            var nhacc = db.NhaCungCaps.SingleOrDefault(ncc => ncc.MaNhaCungCap == ma);
            nhacc.TenNhaCungCap = ten;
            nhacc.DiaChi = dc;
            nhacc.DienThoai = sdt;
            nhacc.Email = email;
            
            db.SaveChanges();
        }
    }
    
}
