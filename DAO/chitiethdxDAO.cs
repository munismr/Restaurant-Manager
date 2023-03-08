using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class chitiethdxDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public ChiTietHoaDonXuat cthdxtheohdxvamonan(int mahdx, int mamonan)
        {
            var chitiethdx = db.ChiTietHoaDonXuats.SingleOrDefault(cthdx => cthdx.MaHoaDonXuat == mahdx && cthdx.MaMonAn == mamonan);
            return (ChiTietHoaDonXuat)chitiethdx;
        }

        public void themcthdx(int mahdx, int mamonan,int soluong,int dongia)
        {
            ChiTietHoaDonXuat cthdx = new ChiTietHoaDonXuat();
            cthdx.MaHoaDonXuat = mahdx;
            cthdx.MaMonAn = mamonan;
            cthdx.SoLuong = soluong;
            cthdx.DonGia = dongia;
            db.ChiTietHoaDonXuats.Add(cthdx);
            db.SaveChanges();
        }
        public void suacthdx(int mahdx, int mamonan, int soluong, int dongia)
        {
            var chitiethdx = db.ChiTietHoaDonXuats.SingleOrDefault(cthdx => cthdx.MaHoaDonXuat == mahdx && cthdx.MaMonAn == mamonan);
            chitiethdx.MaHoaDonXuat = mahdx;
            chitiethdx.MaMonAn = mamonan;
            chitiethdx.SoLuong =soluong;
            chitiethdx.DonGia = dongia;
            
            db.SaveChanges();
        }
        public List<ChiTietHoaDonXuat> cthdxtheohdx(int mahdx)
        {
            var chitiethdx=from cthdx in db.ChiTietHoaDonXuats
                      where cthdx.MaHoaDonXuat==mahdx   
                      select cthdx;
            return chitiethdx.ToList();
        }
        public void xoacthdx(ChiTietHoaDonXuat cthdx)
        {
            db.ChiTietHoaDonXuats.Remove(cthdx);
            db.SaveChanges();
        }
        public ChiTietHoaDonXuat cthdxtheoma(int ma)
        {
            var chitiethdx = db.ChiTietHoaDonXuats.SingleOrDefault(cthdx=>cthdx.MaChiTietHoaDonXuat==ma);
            return (ChiTietHoaDonXuat)chitiethdx;
        }
    }
}
