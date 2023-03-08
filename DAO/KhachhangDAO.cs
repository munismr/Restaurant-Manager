using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class KhachhangDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public List<KhachHang> dskh()
        {
            var khachhang = from kh in db.KhachHangs
                            select kh;
            return khachhang.ToList();
        }
        public KhachHang khtheoma(int ma)
        {
            var khachhang = db.KhachHangs.SingleOrDefault(kh=>kh.MaKhachHang==ma);
            return (KhachHang)khachhang;
        }
        public void themkh(string ten, string dc, string sdt, string email)
        {
            KhachHang kh = new KhachHang();
            kh.TenKhachHang = ten;
            kh.DiaChi = dc;
            kh.DienThoai =  sdt;
            kh.Email = email;
            db.KhachHangs.Add(kh);
            db.SaveChanges();
        }
        public void suakh(int ma,string ten, string dc, string sdt, string email)
        {
            var kh = db.KhachHangs.SingleOrDefault(k => k.MaKhachHang == ma);
            kh.TenKhachHang = ten;
            kh.DiaChi = dc;
            kh.DienThoai = sdt;
            kh.Email = email;
            
            db.SaveChanges();
        }

    }
}
