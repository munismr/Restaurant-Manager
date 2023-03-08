
using RestaurantManager.DAO;
using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for frmHoaDon.xaml
    /// </summary>
    public partial class frmHoaDon : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        NhaccDAO nccDao= new NhaccDAO();
        PhanquyenDAO pqDao= new PhanquyenDAO();
        NguyenlieuDAO nlDao= new NguyenlieuDAO();
        ChitiethdnDAO cthdnDao= new ChitiethdnDAO();
        HoadonnhapDAO hdnDao= new HoadonnhapDAO();
        HoadonxuatDAO hdxDao= new HoadonxuatDAO();
        KhachhangDAO khDao = new KhachhangDAO();
        BanDAO bDao = new BanDAO();
        MonanDAO maDao = new MonanDAO();
        chitiethdxDAO cthdxDao= new chitiethdxDAO();
        DinhluongDAO dlDao= new DinhluongDAO();
        public frmHoaDon()
        {
            InitializeComponent();
        }
        //hoa don nhap
        private void cbnhacc_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<NhaCungCap> list = nccDao.dsnhacc();
            
            cbnhacc.ItemsSource = list;
            cbnhacc.DisplayMemberPath = "TenNhaCungCap";
        }

        private void cbnhanviennhap_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<NhanVien> list = pqDao.dsnhanvien();
            
            cbnhanviennhap.ItemsSource = list;
            cbnhanviennhap.DisplayMemberPath = "TenNhanVien";
        }

        private void tabhoadonnhap_Loaded(object sender, RoutedEventArgs e)
        {
            txtthoigian.Text = DateTime.Now.ToString();
        }

        private void cbnguyenlieunhap_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<NguyenLieu> list = nlDao.dsnguyenlieu();
          
            cbnguyenlieunhap.ItemsSource = list;
            cbnguyenlieunhap.DisplayMemberPath = "TenNguyenLieu";
        }


        private void btnhap_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                NguyenLieu nln = (NguyenLieu)cbnguyenlieunhap.SelectedItem;
                if (nln != null)
                {
                    ChiTietHoaDonNhap cthdn = new ChiTietHoaDonNhap();
                    NguyenLieu nguyenlieu = nlDao.nguyenlieutheoma(nln.MaNguyenLieu);
                    cthdn.MaHoaDonNhap = int.Parse(txtmahdnhap.Text);
                    cthdn.MaNguyenLieu = nln.MaNguyenLieu;
                    cthdn.SoLuong = int.Parse(txtsoluongnhap.Text);
                    cthdn.DonGia = int.Parse(txtgianhap.Text);
                    cthdnDao.themcthdn(cthdn);
                    nlDao.suanl(nln.MaNguyenLieu, nguyenlieu.TenNguyenLieu, nguyenlieu.MaNhomNguyenLieu, nguyenlieu.DonGia, nguyenlieu.DonViTinh, nguyenlieu.SoLuong + int.Parse(txtsoluongnhap.Text));                  
                    loadnguyenlieunhap();
                    tongtien();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }



        }

        private void bttaohoadon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NhanVien nv = (NhanVien)cbnhanviennhap.SelectedItem;
                NhaCungCap ncc = (NhaCungCap)cbnhacc.SelectedItem;
                if(nv!=null && ncc != null)
                {
                    HoaDonNhap hdn = new HoaDonNhap();
                    hdn.MaNhanVien = nv.MaNhanVien;
                    hdn.MaNhaCungCap = ncc.MaNhaCungCap;
                    hdn.ThoiGian = DateTime.Parse(txtthoigian.Text);
                    hdn.TongTien = 0;
                    hdnDao.themhdn(hdn);
                    MessageBox.Show("Đã tạo hóa đơn");
                    txtmahdnhap.Text = hdn.MaHoaDonNhap.ToString();
                    bttaohoadon.IsEnabled = false;
                    btnhap.IsEnabled = true;
                    btxoa.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }




        }

        private void cbnguyenlieunhap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NguyenLieu nl = (NguyenLieu)cbnguyenlieunhap.SelectedItem;
            txtgianhap.Text = nl.DonGia.ToString();


        }

        public void loadnguyenlieunhap()
        {
            
            List<ChiTietHoaDonNhap> list = cthdnDao.cthdntheohdn(int.Parse(txtmahdnhap.Text));
            
            datagirdnlnhap.Items.Clear();
            foreach (var d in list)
            {
                var nguyenlieu = nlDao.nguyenlieutheoma(d.MaNguyenLieu);
                datagirdnlnhap.Items.Add(new
                {
                    Macthdn = d.MaChiTietHoaDonNhap,
                    Manguyenlieu = nguyenlieu.MaNguyenLieu,
                    Tennguyenlieu = nguyenlieu.TenNguyenLieu,
                    Dongia = nguyenlieu.DonGia,
                    Soluong = d.SoLuong,
                    Thanhtien = nguyenlieu.DonGia * d.SoLuong,
                });
            }
;
        }
        private void datagirdnlnhap_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void btreset_Click(object sender, RoutedEventArgs e)
        {
            bttaohoadon.IsEnabled = true;
            datagirdnlnhap.Items.Clear();
            txtmahdnhap.Text = "";
            txtthoigian.Text = DateTime.Now.ToString();
            txtsoluongnhap.Text = "";
            btnhap.IsEnabled = false;
            btxoa.IsEnabled = false;
        }

        private void datagirdnlnhap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagirdnlnhap.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int Manguyenlieu = (int)anonymousType.GetProperty("Manguyenlieu").GetValue(selectedItem, null);

                var nguyenlieu = nlDao.nguyenlieutheoma(Manguyenlieu);

                cbnguyenlieunhap.SelectedItem = nguyenlieu;


            }
        }

        private void btxoa_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = datagirdnlnhap.SelectedItem;
            if (selectedItem != null)
            {
               
                var anonymousType = selectedItem.GetType();
                int Macthdn = (int)anonymousType.GetProperty("Macthdn").GetValue(selectedItem, null);
                var chitiethdn = cthdnDao.cthdntheoma(Macthdn);
                var nguyenlieu = nlDao.nguyenlieutheoma(chitiethdn.MaNguyenLieu);
                cthdnDao.xoacthdn(chitiethdn);
                nlDao.suanl(nguyenlieu.MaNguyenLieu, nguyenlieu.TenNguyenLieu, nguyenlieu.MaNhomNguyenLieu, nguyenlieu.DonGia, nguyenlieu.DonViTinh, nguyenlieu.SoLuong - int.Parse(chitiethdn.SoLuong.ToString()));
               
                loadnguyenlieunhap();
                tongtien();
            }
        }
        public void tongtien()
        {
            
            double tong = 0;
            List<ChiTietHoaDonNhap> list = cthdnDao.cthdntheohdn(int.Parse(txtmahdnhap.Text));

           
            foreach (var ct in list)
            {
                tong += (ct.SoLuong * ct.DonGia);
            }
            txttongthanhtien.Text = tong.ToString();
        }

        private void btluuhdn_Click(object sender, RoutedEventArgs e)
        {
            
            hdnDao.suahdn(int.Parse(txtmahdnhap.Text), int.Parse(txttongthanhtien.Text));
            MessageBox.Show("Lưu hóa đơn thành công");

        }

        //hoa don xuat
        public string maban { get; set; }
        

        private void bttaohdx_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Ban b = (Ban)cbban.SelectedItem;
                
                KhachHang kh = (KhachHang)cbkhachhang.SelectedItem;
                NhanVien nv = (NhanVien)cbnhanvienxuat.SelectedItem;
                if (b != null && nv != null && kh != null)
                {

                    var Hoadonxuat = hdxDao.hdxchuathanhtoantheoban(b.MaBan);
                    if (Hoadonxuat == null)
                    {
                        HoaDonXuat hdx = new HoaDonXuat();
                        hdx.MaBan = b.MaBan;
                        hdx.MaNhanVien = nv.MaNhanVien;
                        hdx.TongTien = 0;
                        hdx.ThoiGianVao = DateTime.Parse(txtthoigian.Text);
                        hdx.ThoiGianRa = DateTime.Parse(txtthoigian.Text);
                        hdx.GianGia = int.Parse(txtgiamgia.Text);
                        hdx.MaKhachHang = kh.MaKhachHang;
                        hdxDao.taohdx(hdx);
                        MessageBox.Show("Đã tạo hóa đơn");
                        txthdxuat.Text = hdx.MaHoaDonXuat.ToString();
                        btresethdx.IsEnabled = true;
                        bttaohdx.IsEnabled = false;
                        btnhapma.IsEnabled = true;
                        btxoama.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Bàn này đã đủ, vui lòng chọn bàn khác");
                    }


                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Tạo không thành công, vui lòng làm mới và tạo lại");
            }

        }
        public void loadkhachhang()
        {
            
            List<KhachHang> list = khDao.dskh() ;
            
            cbkhachhang.ItemsSource = list;
            cbkhachhang.DisplayMemberPath = "TenKhachHang";
        }
        private void cbkhachhang_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        public void loadnhanvienxuat()
        {
            
            List<NhanVien> list = pqDao.dsnhanvien() ;
            
            cbnhanvienxuat.ItemsSource = list;
            cbnhanvienxuat.DisplayMemberPath = "TenNhanVien";
        }
        private void cbnhanvienxuat_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void loadban()
        {
            
            List<Ban> list = bDao.dsban() ;
            
            cbban.ItemsSource = list;
            cbban.DisplayMemberPath = "MaBan";
        }
        private void cbban_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtthoigianxuat_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        public void loadmonan()
        {
            
            List<MonAn> list = maDao.dsmonan(); ;
            
            cbmonan.ItemsSource = list;
            cbmonan.DisplayMemberPath = "TenMonAn";
        }
        private void cbmonan_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void cbmonan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonAn ma = (MonAn)cbmonan.SelectedItem;
            txtgiamonan.Text = ma.DonGia.ToString();
        }

        private void btnhapma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChiTietHoaDonXuat cthdx = new ChiTietHoaDonXuat();
                MonAn ma = (MonAn)cbmonan.SelectedItem;
                if(ma != null)
                {
                    cthdxDao.themcthdx(int.Parse(txthdxuat.Text), ma.MaMonAn, int.Parse(txtslmonan.Text), int.Parse(txtgiamonan.Text));
                    
                    var dinhluong = from dl in db.DinhLuongs
                                    where dl.MaMonAn == ma.MaMonAn
                                    select dl;
                    List<DinhLuong> listdl = dlDao.dltheoma(ma.MaMonAn);
                    
                    foreach(var item in listdl)
                    {
                        var nguyenlieu = nlDao.nguyenlieutheoma(item.MaNguyenLieu);
                        nlDao.suanl(item.MaNguyenLieu, nguyenlieu.TenNguyenLieu, nguyenlieu.MaNhomNguyenLieu, nguyenlieu.DonGia, nguyenlieu.DonViTinh, nguyenlieu.SoLuong - int.Parse(txtslmonan.Text) * item.SoLuong);
                    }
                    
                    loadmonanxuat();
                    tongtienxuat();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }   
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        public void loadmonanxuat()
        {
            
            List<ChiTietHoaDonXuat> list = cthdxDao.cthdxtheohdx(int.Parse(txthdxuat.Text));
            
            datagridcthdx.Items.Clear();
            foreach (var d in list)
            {
                var monan = maDao.matheoma(d.MaMonAn);
                datagridcthdx.Items.Add(new
                {
                    Macthdx = d.MaChiTietHoaDonXuat,
                    Mamonan = monan.MaMonAn,
                    Tenmonan = monan.TenMonAn,
                    Soluong = d.SoLuong,
                    Dongia = monan.DonGia,
                    Thanhtien = d.SoLuong * monan.DonGia,
                });
            }

        }

        private void btxoama_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = datagridcthdx.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int Macthdx = (int)anonymousType.GetProperty("Macthdx").GetValue(selectedItem, null);
                var chitiethdx = cthdxDao.cthdxtheoma(Macthdx);
                cthdxDao.xoacthdx(chitiethdx);
                
                List<DinhLuong> listdl = dlDao.dltheoma(chitiethdx.MaMonAn);
                
                foreach (var item in listdl)
                {
                    var nguyenlieu = nlDao.nguyenlieutheoma(item.MaNguyenLieu);
                    nlDao.suanl(item.MaNguyenLieu, nguyenlieu.TenNguyenLieu, nguyenlieu.MaNhomNguyenLieu, nguyenlieu.DonGia, nguyenlieu.DonViTinh, nguyenlieu.SoLuong + chitiethdx.SoLuong * item.SoLuong);
                    
                }
               
                loadmonanxuat();
                tongtienxuat();
            }
        }
        public void tongtienxuat()
        {
            
            double tong = 0;
            List<ChiTietHoaDonXuat> list = cthdxDao.cthdxtheohdx(int.Parse(txthdxuat.Text));

            
            foreach (var ct in list)
            {
                tong += (ct.SoLuong * ct.DonGia);
            }
            txttongtienthanhtoan.Text = (tong-tong*int.Parse(txtgiamgia.Text)/100).ToString();
        }

        

        

        private void btluuhdx_Click(object sender, RoutedEventArgs e)
        {
            NhanVien nv = (NhanVien)cbnhanvienxuat.SelectedItem;
            KhachHang kh = (KhachHang)cbkhachhang.SelectedItem;
            if (nv != null && kh != null && txtgiamgia.Text != "") 
            {
                hdxDao.suahdx(int.Parse(txthdxuat.Text), nv.MaNhanVien, kh.MaKhachHang, int.Parse(txttongtienthanhtoan.Text), DateTime.Now);
               
                MessageBox.Show("Lưu hóa đơn thành công");
                bttaohdx.IsEnabled = true;
                txtgiamgia.Text = "";

                datagridcthdx.Items.Clear();
                txthdxuat.Text = "";
                txtthoigianxuat.Text = DateTime.Now.ToString();
                txtslmonan.Text = "";
                btnhapma.IsEnabled = false;
                btxoama.IsEnabled = false;

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        private void btresethdx_Click(object sender, RoutedEventArgs e)
        {
            
                var hoadonxuat = hdxDao.hdxtheoma(int.Parse(txthdxuat.Text)); 
                var chitiethdx = cthdxDao.cthdxtheohdx(int.Parse(txthdxuat.Text));
                if (chitiethdx.Count() != 0)
                {
                    foreach (var item in chitiethdx)
                    {
                        cthdxDao.xoacthdx(item);
                    }

                    hdxDao.xoahdx(hoadonxuat);
                  
                    bttaohdx.IsEnabled = true;
                    txtgiamgia.Text = "";

                    datagridcthdx.Items.Clear();
                    txthdxuat.Text = "";
                    txtthoigianxuat.Text = DateTime.Now.ToString();
                    txtslmonan.Text = "";
                    btnhapma.IsEnabled = false;
                    btxoama.IsEnabled = false;
                }
                else
                {
                    hdxDao.xoahdx(hoadonxuat);
                    db.SaveChanges();
                    bttaohdx.IsEnabled = true;
                    txtgiamgia.Text = "";

                    datagridcthdx.Items.Clear();
                    txthdxuat.Text = "";
                    txtthoigianxuat.Text = DateTime.Now.ToString();
                    txtslmonan.Text = "";
                    btnhapma.IsEnabled = false;
                    btxoama.IsEnabled = false;

                }
            
           
        }

        public void loadhoadon(int maban)
        {
            var Hoadonxuat = hdxDao.hdxchuathanhtoantheoban(maban);
                
            txtgiamgia.Text = Hoadonxuat.GianGia.ToString() ;
            txthdxuat.Text = Hoadonxuat.MaHoaDonXuat.ToString();
            txtthoigianxuat.Text = Hoadonxuat.ThoiGianVao.ToString();
            
            List<ChiTietHoaDonXuat> list = cthdxDao.cthdxtheohdx(Hoadonxuat.MaHoaDonXuat);
            
            double tong = 0;
            datagridcthdx.Items.Clear();
            foreach (var d in list)
            {
                var monan = maDao.matheoma(d.MaMonAn);
                datagridcthdx.Items.Add(new
                {
                    Macthdx = d.MaChiTietHoaDonXuat,
                    Mamonan = monan.MaMonAn,
                    Tenmonan = monan.TenMonAn,
                    Soluong = d.SoLuong,
                    Dongia = monan.DonGia,
                    Thanhtien = d.SoLuong * monan.DonGia,
                });
                tong += d.SoLuong * monan.DonGia;
            }
            txttongtienthanhtoan.Text = (tong-tong*int.Parse(txtgiamgia.Text)).ToString() ;


        }
        private void tabhoadonxuat_Loaded(object sender, RoutedEventArgs e)
        {
            if (maban != "")
            {
                bttaohdx.IsEnabled = false;
                loadban();
                loadkhachhang();
                loadmonan();
                loadnhanvienxuat();
                btnhapma.IsEnabled = true;
                btxoama.IsEnabled = true;
                var ban = bDao.bantheoma(int.Parse(maban));
                cbban.SelectedItem = ban;
                btresethdx.IsEnabled = true;
                loadhoadon(int.Parse(maban));



            }
            else
            {
                txtthoigianxuat.Text = DateTime.Now.ToString();
                loadban();
                loadkhachhang();
                loadmonan();
                loadnhanvienxuat();
            }
        
           
        }
        
    }
}
    
