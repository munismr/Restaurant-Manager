
using RestaurantManager.DAO;
using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantManager
{
    /// <summary>
    /// Interaction logic for frmNhanVien.xaml
    /// </summary>
    public partial class frmNhanVien : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        BophanDAO dao = new BophanDAO();
        PhanquyenDAO pqDao= new PhanquyenDAO();
        //bo phan
        private void btthembophan_Click(object sender, RoutedEventArgs e)
        {           
                BoPhan bp = new BoPhan();
                bp.TenBoPhan = txttenbophan.Text;
                dao.thembophan(bp);
                hienthiBoPhan();            
        }
        public void hienthiBoPhan()
        {
            List<BoPhan> list = dao.dsBoPhan(); ;
            datagirdbophan.Items.Clear(); ;
            foreach (var bp in list)
            {   
                datagirdbophan.Items.Add(new
                {
                    Mabophan = bp.MaBoPhan,
                    Tenbophan = bp.TenBoPhan,
                });
            }
        }

        private void datagirdbophan_Loaded(object sender, RoutedEventArgs e)
        {
            hienthiBoPhan();
        }

        private void datagirdbophan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = datagirdbophan.SelectedItem;
            if (selecteditem != null)
            {
                var anonymoustype = selecteditem.GetType();
                if (anonymoustype.GetProperty("Mabophan") != null && anonymoustype.GetProperty("Tenbophan") != null)
                {
                    int mabophan = (int)anonymoustype.GetProperty("Mabophan").GetValue(selecteditem, null);
                    string tenbophan = (string)anonymoustype.GetProperty("Tenbophan").GetValue(selecteditem, null);
                    txttenbophan.Text = tenbophan;
                }
            }
        }

        private void btsuabophan_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem = datagirdbophan.SelectedItem;
            if (selecteditem != null)
            {
                var anonymoustype = selecteditem.GetType();
                if (anonymoustype.GetProperty("Mabophan") != null && anonymoustype.GetProperty("Tenbophan") != null)
                {
                    int mabophan = (int)anonymoustype.GetProperty("Mabophan").GetValue(selecteditem, null);
                    dao.suabophan(mabophan, txttenbophan.Text);
                    hienthiBoPhan();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bộ phận muốn sửa");
            }
        }
        //private void btxoabophan_Click(object sender, RoutedEventArgs e)
        //{
        //    var selecteditem = datagirdbophan.SelectedItem;
        //    if (selecteditem != null)
        //    {
        //        var anonymoustype = selecteditem.GetType();
        //        if (anonymoustype.GetProperty("Mabophan") != null)
        //        {
        //            int mabophan = (int)anonymoustype.GetProperty("Mabophan").GetValue(selecteditem, null);
        //            dao.xoabophan(mabophan);
        //            hienthiBoPhan();

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn 1 bộ phận muốn xóa");
        //    }
        //}

       //phan quyen
        public void loadphanquyen()
        {
            List<NguoiDung> listnd = pqDao.dsnguoidung();
            datagridphanquyen.Items.Clear();
            foreach (var item in listnd)
            {
                NhanVien nv = pqDao.nhanvientheond(item.MaNguoiDung);
                datagridphanquyen.Items.Add(new
                {
                    Manguoidung = item.MaNguoiDung,
                    Taikhoan = item.TenNguoiDung,
                    Matkhau = item.MatKhau,
                    Tennhanvien = nv.TenNhanVien,
                });
            }
        }
        private void datagridphanquyen_Loaded(object sender, RoutedEventArgs e)
        {

            loadphanquyen();
        }

        private void cbnhanvien_Loaded(object sender, RoutedEventArgs e)
        {

            List<NhanVien> list = pqDao.dsnhanvien();
            
            cbnhanvien.ItemsSource = list;
            cbnhanvien.DisplayMemberPath = "TenNhanVien";
        }

        private void cbnhanvien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NhanVien nv = (NhanVien)cbnhanvien.SelectedItem;
            QuyenForm quyenform = pqDao.quyentheonv(nv.MaNhanVien);

            txttk.Text = "";
            txtmk.Text = "";
            
            ckNhanVien.IsChecked = false;
            ckNguyenLieu.IsChecked = false;
            ckHoaDon.IsChecked = false;
            ckBaoCao.IsChecked = false;
            ckTimKiem.IsChecked = false;
            if (quyenform != null)
            {
                NguoiDung nguoidung = pqDao.nguoidungtheoma(quyenform.MaNguoiDung);
                txttk.Text = nguoidung.TenNguoiDung;
                txtmk.Text = nguoidung.MatKhau.ToString();
                List<QuyenForm> list = pqDao.dsquyentheonv(nv.MaNhanVien);              
                hienthiquyen(list);
            }


        }
        public void hienthiquyen(List<QuyenForm> quyenform)
        {          
            foreach (var item in quyenform)
            {                
                if (item.TenForm == "frmNhanVien")
                {
                    ckNhanVien.IsChecked = true;
                }
                if (item.TenForm == "frmNguyenLieu")
                {
                    ckNguyenLieu.IsChecked = true;
                }
                if (item.TenForm == "frmHoaDon")
                {
                    ckHoaDon.IsChecked = true;
                }
                if (item.TenForm == "frmBaoCao")
                {
                    ckBaoCao.IsChecked = true;
                }
                if (item.TenForm == "frmTimKiem")
                {
                    ckTimKiem.IsChecked = true;
                }
            }
        }
        public void loaddanhsachquyen()
        {

        }

        private void datagridphanquyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ckNhanVien.IsChecked = false;
            ckNguyenLieu.IsChecked = false;
            ckHoaDon.IsChecked = false;
            ckBaoCao.IsChecked = false;
            ckTimKiem.IsChecked = false;
            var selecteditem = datagridphanquyen.SelectedItem;
            if (selecteditem != null)
            {
                var anonymoustype = selecteditem.GetType();
                if (anonymoustype.GetProperty("Manguoidung") != null )
                {
                    int manguoidung = (int)anonymoustype.GetProperty("Manguoidung").GetValue(selecteditem, null);


                    NhanVien nhanvien = pqDao.nhanvientheond(manguoidung);
                    cbnhanvien.SelectedItem = nhanvien;
                    
                    
 
                }
            }
        }

       

        private void btthem_Click(object sender, RoutedEventArgs e)
        {
            NhanVien nv = (NhanVien)cbnhanvien.SelectedItem;
            QuyenForm quyenform = pqDao.quyentheonv(nv.MaNhanVien);
            
            if (quyenform == null)
            {
                try
                {
                    bool ktra = pqDao.ktranguoidung(txttk.Text);
                    if (ktra == true)
                    {
                        pqDao.themnguoidung(txttk.Text, txtmk.Text);
                        NguoiDung nd = pqDao.nguoidungtheoten(txttk.Text);
                        pqDao.themquyenform("Đăng nhập", nv.MaNhanVien, nd.MaNguoiDung);

                        if (ckNhanVien.IsChecked == true)
                        {
                            pqDao.themquyenform("frmNhanVien", nv.MaNhanVien, nd.MaNguoiDung);

                        }
                        if (ckNguyenLieu.IsChecked == true)
                        {
                            pqDao.themquyenform("frmNguyenLieu", nv.MaNhanVien, nd.MaNguoiDung);

                        }
                        if (ckHoaDon.IsChecked == true)
                        {
                            pqDao.themquyenform("frmHoaDon", nv.MaNhanVien, nd.MaNguoiDung);

                        }
                        if (ckBaoCao.IsChecked == true)
                        {
                            pqDao.themquyenform("frmBaoCao", nv.MaNhanVien, nd.MaNguoiDung);

                        }
                        if (ckTimKiem.IsChecked == true)
                        {
                            pqDao.themquyenform("frmTimKiem", nv.MaNhanVien, nd.MaNguoiDung);

                        }
                        loadphanquyen();

                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Có lỗi vui lòng thử lại");
                }
                
                
            }
            else
            {
                try
                {
                    List<QuyenForm> list = pqDao.dsquyentheonv1(nv.MaNhanVien);
                    NguoiDung nd = pqDao.nguoidungtheoten(txttk.Text);
                    if (ckNhanVien.IsChecked == true)
                    {
                        pqDao.themquyenform("frmNhanVien", nv.MaNhanVien, nd.MaNguoiDung);

                    }
                    if (ckNguyenLieu.IsChecked == true)
                    {
                        pqDao.themquyenform("frmNguyenLieu", nv.MaNhanVien, nd.MaNguoiDung);

                    }
                    if (ckHoaDon.IsChecked == true)
                    {
                        pqDao.themquyenform("frmHoaDon", nv.MaNhanVien, nd.MaNguoiDung);

                    }
                    if (ckBaoCao.IsChecked == true)
                    {
                        pqDao.themquyenform("frmBaoCao", nv.MaNhanVien, nd.MaNguoiDung);

                    }
                    if (ckTimKiem.IsChecked == true)
                    {
                        pqDao.themquyenform("frmTimKiem", nv.MaNhanVien, nd.MaNguoiDung);

                    }
                    foreach (var item in list)
                    {
                        pqDao.xoaquyen(item);
                    }
                    
                    loadphanquyen();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Có lỗi vui lòng thử lại");
                }
            }
        }

        //nhanvien

        private void tabhosonhanvien_Loaded(object sender, RoutedEventArgs e)
        {            
            List<BoPhan> listbophan = dao.dsBoPhan();           
            cbbophan.ItemsSource = listbophan;
            cbbophan.DisplayMemberPath = "TenBoPhan";
            cbbophan1.ItemsSource = listbophan;
            cbbophan1.DisplayMemberPath = "TenBoPhan";
        }



        public void loadnhanvien()
        {
            BoPhan bp = (BoPhan)cbbophan.SelectedItem;
            List<NhanVien> nhanvien = pqDao.dsnhanvientheobp(bp.MaBoPhan);
            datagridnhanvien.Items.Clear();
            foreach (var nv in nhanvien)
            {
                datagridnhanvien.Items.Add(new
                {
                    Manhanvien = nv.MaNhanVien,
                    Tennhanvien = nv.TenNhanVien,
                    Diachi = nv.DiaChi,
                    Email = nv.Email,
                    Dienthoai = nv.DienThoai,
                });
            }
        }

        private void cbbophan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadnhanvien();
        }

        private void btthemnv_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                BoPhan bp = (BoPhan)cbbophan1.SelectedItem;
                if(bp != null)
                {
                    int index = cbbophan1.SelectedIndex;
                    NhanVien nv = new NhanVien();

                    nv.TenNhanVien = txttennhanvien.Text;
                    nv.MaBoPhan = bp.MaBoPhan;
                    nv.DiaChi = txtdiachi.Text;
                    nv.Email = txtemail.Text;
                    nv.DienThoai = int.Parse(txtdienthoai.Text);
                    pqDao.themnv(nv);

                    txttennhanvien.Text = "";
                    txtdiachi.Text = "";
                    txtemail.Text = "";
                    txtdienthoai.Text = "";
                    cbbophan.SelectedIndex = 0;
                    cbbophan.SelectedIndex = index;
                    MessageBox.Show("Đã thêm thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }

        }



        private void datagridnhanvien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagridnhanvien.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int Manhanvien = (int)anonymousType.GetProperty("Manhanvien").GetValue(selectedItem, null);
                NhanVien nhanvien = pqDao.nhanvientheoma(Manhanvien);

                BoPhan bophan =dao.bophantheoma(nhanvien.MaBoPhan);
                txttennhanvien.Text = nhanvien.TenNhanVien;
                cbbophan1.SelectedItem = bophan;
                txtdiachi.Text = nhanvien.DiaChi;
                txtemail.Text = nhanvien.Email;
                txtdienthoai.Text = nhanvien.DienThoai.ToString();


            }
        }
        private void btsuanv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagridnhanvien.SelectedItem;
                if (selectedItem != null)
                {
                    BoPhan bp = (BoPhan)cbbophan1.SelectedItem;
                    var anonymousType = selectedItem.GetType();
                    int Manhanvien = (int)anonymousType.GetProperty("Manhanvien").GetValue(selectedItem, null);
                    pqDao.suanhanvien(Manhanvien, txttennhanvien.Text, bp.MaBoPhan, txtdiachi.Text, txtemail.Text, int.Parse(txtdienthoai.Text));
                    
                    MessageBox.Show("Đã sửa thành công");
                    loadnhanvien();

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên muốn sửa");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        private void btxoanv_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var selectedItem = datagridnhanvien.SelectedItem;
            //    if (selectedItem != null)
            //    {
            //        var anonymousType = selectedItem.GetType();
            //        int Manhanvien = (int)anonymousType.GetProperty("Manhanvien").GetValue(selectedItem, null);
            //        QuyenForm q = pqDao.quyentheonv(Manhanvien);
            //        if (q != null)
            //        {
            //            NhanVien nhanvien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == Manhanvien);
            //            var quyenform = from qf in db.QuyenForms
            //                            where qf.MaNhanVien == nhanvien.MaNhanVien
            //                            select qf;
            //            var quyen = db.QuyenForms.FirstOrDefault(q => q.MaNhanVien == nhanvien.MaNhanVien);
            //            var nguoidung = db.NguoiDungs.SingleOrDefault(nd => nd.MaNguoiDung == quyen.MaNguoiDung);

            //            foreach (var item in quyenform)
            //            {
            //                db.QuyenForms.Remove(item);

            //            }
            //            db.SaveChanges();
            //            db.NhanViens.Remove(nhanvien);
            //            db.SaveChanges();
            //            db.NguoiDungs.Remove(nguoidung);
            //            db.SaveChanges();
            //            MessageBox.Show("Đã xóa thành công");
            //            loadnhanvien();
            //        }
            //        else
            //        {
            //            pqDao.xoanhanvien(Manhanvien);
            //            MessageBox.Show("Đã xóa thành công");
            //            loadnhanvien();
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng chọn nhân viên muốn xóa");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    MessageBox.Show("Có lỗi vui lòng thử lại");
            //}
            
           
        }

        private void btthoatnv_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
