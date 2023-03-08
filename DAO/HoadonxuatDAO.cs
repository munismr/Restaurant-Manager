using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace RestaurantManager.DAO
{

    public class HoadonxuatDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();

        public HoaDonXuat hdxchuathanhtoantheoban(int maban)
        {          
            var hoadonxuat=db.HoaDonXuats.SingleOrDefault(hdx=>hdx.MaBan==maban && hdx.ThoiGianVao == hdx.ThoiGianRa);
            return (HoaDonXuat)hoadonxuat;
        }
        public HoaDonXuat hdxtheoma(int ma)
        {
            var hoadonxuat = db.HoaDonXuats.SingleOrDefault(hdx => hdx.MaHoaDonXuat == ma );
            return (HoaDonXuat)hoadonxuat;
        }

        public void themhdx(int maban, int manv, double tongtien, int giamgia, int makh)
        {
            HoaDonXuat hdx = new HoaDonXuat();
            hdx.MaBan = maban;
            hdx.MaNhanVien = manv;
            hdx.TongTien = tongtien;
            hdx.ThoiGianVao = DateTime.Now;
            hdx.ThoiGianRa = DateTime.Now;
            hdx.GianGia = giamgia;
            hdx.MaKhachHang = makh;
            db.HoaDonXuats.Add(hdx);
            db.SaveChanges();
        }
        public void taohdx(HoaDonXuat hdx)
        {
            db.HoaDonXuats.Add(hdx);
            db.SaveChanges();
         
            
        }
        public void xoahdx(HoaDonXuat hdx)
        {
            db.HoaDonXuats.Remove(hdx);
            db.SaveChanges();


        }
        public void suahdx(int mahd,int manv, int makh, double tongtien, DateTime time)
        {
            var hoadonxuat = db.HoaDonXuats.SingleOrDefault(hdx => hdx.MaHoaDonXuat == mahd);
            hoadonxuat.MaNhanVien = manv;
            hoadonxuat.MaKhachHang = makh;
            hoadonxuat.TongTien = tongtien;
            hoadonxuat.ThoiGianRa = time;
            db.SaveChanges();
        }
        public List<HoaDonXuat> dshdxtheongay(DateTime time)
        {
            var HDx = from hdx in db.HoaDonXuats
                      where hdx.ThoiGianVao.Date == time
                      select hdx;
            return HDx.ToList();
        }
        public List<HoaDonXuat> dshdxtheongayvanv(DateTime time, int manv)
        {
            var HDx = from hdx in db.HoaDonXuats
                      where hdx.ThoiGianVao.Date == time && hdx.MaNhanVien==manv
                      select hdx;
            return HDx.ToList();
        }
    }
}
