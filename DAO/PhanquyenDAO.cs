using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class PhanquyenDAO
    {
        RestaurantManagerContext db= new RestaurantManagerContext();

        public PhanquyenDAO() { }
        public NguoiDung nguoidungtheoma(int mand)
        {
            var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == mand);
            
            return (NguoiDung)nguoidung;
        }
        public  List<NguoiDung> dsnguoidung() {
            var nguoidung = from nd in db.NguoiDungs
                            select nd;
            List<NguoiDung> list= new List<NguoiDung>();
            list=nguoidung.ToList();
            return list;
        }
        public List<NhanVien> dsnhanvien()
        {
            var nhanvien=from nv in db.NhanViens
                         select nv;
            List<NhanVien> list=nhanvien.ToList();
            return list;
        }
        public NhanVien nhanvientheond(int mand)
        {
            var quyenform = db.QuyenForms.SingleOrDefault(qf => qf.MaNguoiDung == mand && qf.TenForm == "Đăng nhập");
            NhanVien nv = new NhanVien();
            if (quyenform != null)
            {
                var nhanvien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == quyenform.MaNhanVien);
                nv = (NhanVien)nhanvien;
                
            }
            return nv;

        }
        public NguoiDung nguoidungtheonv(int manv)
        {
            var quyenform = db.QuyenForms.SingleOrDefault(qf => qf.MaNguoiDung == manv && qf.TenForm == "Đăng nhập");
            NguoiDung nd = new NguoiDung();
            if (quyenform != null)
            {
                var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == quyenform.MaNguoiDung);
                nd = (NguoiDung)nguoidung;

            }
            return nd;

        }
        public QuyenForm quyentheonv(int manv)
        {
            var quyenform = db.QuyenForms.SingleOrDefault(qf => qf.MaNhanVien == manv && qf.TenForm == "Đăng nhập");
            return (QuyenForm)quyenform;
        }
        public List<QuyenForm> dsquyentheonv(int manv)
        {
            var quyenform = from qf in db.QuyenForms
                            where qf.MaNhanVien == manv
                            select qf;
            List<QuyenForm> list = quyenform.ToList();
            return list;
        }
        public void xoaquyen(QuyenForm qf)
        {
            db.QuyenForms.Remove(qf);
            db.SaveChanges();
        }
        public List<QuyenForm> dsquyentheonv1(int manv)
        {
            var quyenform = from qf in db.QuyenForms
                            where qf.MaNhanVien == manv && qf.TenForm!="Đăng nhập"
                            select qf;
            List<QuyenForm> list = quyenform.ToList();
            return list;
        }
        public bool ktranguoidung(string ten)
        {
            var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.TenNguoiDung == ten);
            if (nguoidung == null)
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public NguoiDung nguoidungtheoten(string ten)
        {
            var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.TenNguoiDung == ten);
            return (NguoiDung)nguoidung;
        }

        public void themnguoidung(string ten, string matkhau)
        {
            
                NguoiDung nd = new NguoiDung();
                nd.TenNguoiDung = ten;
                nd.MatKhau = matkhau;
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
                
        }

        public void themquyenform(string tenform, int manv, int mand)
        {
            QuyenForm quyen = new QuyenForm();
            quyen.TenForm = tenform;
            quyen.MaNhanVien = manv;
            quyen.MaNguoiDung = mand;
            db.QuyenForms.Add(quyen);
            db.SaveChanges();
        }

        public bool quyenthemformvanv(string tenform, int manv)
        {
            var quyenform = db.QuyenForms.SingleOrDefault(qf => qf.MaNhanVien == manv && qf.TenForm == tenform);
            if (quyenform != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void xoaquyentheoformvanv(string tenform, int manv)
        {
            var quyenform = db.QuyenForms.SingleOrDefault(qf => qf.MaNhanVien == manv && qf.TenForm == tenform);
            if (quyenform != null)
            {
                db.QuyenForms.Remove(quyenform);
            }
            
        }

        public List<NhanVien> dsnhanvientheobp(int mabp)
        {
            var nhanvien = from nv in db.NhanViens
                           where nv.MaBoPhan == mabp
                           select nv;
            List<NhanVien> list = nhanvien.ToList();
            return list;
        }

        public void themnv(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }

        public NhanVien nhanvientheoma(int manv)
        {
            var nhanvien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == manv);
            return (NhanVien)nhanvien;
        }

        public void suanhanvien(int manv,string ten,int bo, string diachi, string email, int dt)
        {
            var nhanvien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == manv);
            nhanvien.TenNhanVien = ten;
            nhanvien.MaBoPhan = bo;
            nhanvien.DiaChi = diachi;
            nhanvien.Email = email;
            nhanvien.DienThoai = dt;
            db.SaveChanges();
        }
        public void xoanhanvien(int manv)
        {
            var nhanvien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == manv);
            db.NhanViens.Remove(nhanvien);
            db.SaveChanges();
        }

        public void xoanguoidung(int mand)
        {
            var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == mand);
            db.NguoiDungs.Remove(nguoidung);
            db.SaveChanges();
        }

        public List<string> quyentheotennd(string tennguoidung)
        {
            var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.TenNguoiDung == tennguoidung);
            var quyenform = from qf in db.QuyenForms
                            where qf.MaNguoiDung == nguoidung.MaNguoiDung
                            select qf;
            List<string> list = new List<string>();
            foreach (var item in quyenform)
            {
                list.Add(item.TenForm);
            }
            return list;
        }

       

    }
}
