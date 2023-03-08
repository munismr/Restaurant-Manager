
using Microsoft.Data.SqlClient.Server;
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
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public string tennguoidung { get; set; }
        PhanquyenDAO pqDao= new PhanquyenDAO();
        HoadonxuatDAO hdxDao= new HoadonxuatDAO();
        BanDAO bDao= new BanDAO();
        NhommaDAO nmaDao= new NhommaDAO();
        MonanDAO maDao= new MonanDAO();
        chitiethdxDAO cthdxDao= new chitiethdxDAO();
        public frmMain()
        {
            InitializeComponent();
            
        }
        
       
        public void loadban()
        {         
            string imagePaths = "C:\\Users\\anior\\Pictures\\banan.png"; // đường dẫn tuyệt đối tới tệp ảnh
            BitmapImage bitmap = new BitmapImage(new Uri(imagePaths, UriKind.Absolute));
            dgvban.Items.Clear();
            List<Ban> li = bDao.dsban();         
            foreach (var item in li)
            {
                var hoadonxuat = hdxDao.hdxchuathanhtoantheoban(item.MaBan);              
                if (hoadonxuat ==null)
                {
                    bDao.suaban(item.MaBan, "trống");
                }
                else
                {
                    bDao.suaban(item.MaBan, "đủ");
                }               
            }
            var ban2 = bDao.dsban();
            foreach (Ban table in ban2)
            {
                dgvban.Items.Add(new { ImagePaths = bitmap, Maban = table.MaBan, Status = table.Status });
            }
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            loadban();
        }

        private void MenuNhanVien_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = pqDao.quyentheotennd(tennguoidung);          
            bool quyen = false;
            foreach (var item in list)
            {
                if (item == "frmNhanVien")
                {
                    quyen = true;
                    break;
                }
                else
                {
                    quyen = false;
                }
            }
            if (quyen == true)
            {
                
                frmNhanVien frmNV = new frmNhanVien();
                frmNV.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền");
            }

        }

        private void MenuNguyenLieu_Click(object sender, RoutedEventArgs e)
        {


            List<string> list = pqDao.quyentheotennd(tennguoidung);
            bool quyen = false;
            foreach (var item in list)
            {
                if (item == "frmNguyenLieu")
                {
                    quyen = true;
                    break;
                }
                else
                {
                    quyen = false;
                }
            }
            if (quyen == true)
            {
                frmNguyenLieu frmNL = new frmNguyenLieu();
                frmNL.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền");
            }

        }

        private void MenuHoaDon_Click(object sender, RoutedEventArgs e)
        {


            List<string> list = pqDao.quyentheotennd(tennguoidung);
            bool quyen = false;
            foreach (var item in list)
            {
                if (item == "frmHoaDon")
                {
                    quyen = true;
                    break;
                }
                else
                {
                    quyen = false;
                }
            }
            if (quyen == true)
            {
                this.Hide();
                frmHoaDon frmHD = new frmHoaDon();
                frmHD.maban = "";
                frmHD.ShowDialog();
                loadban();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền");
            }


        }

        private void MenuBaoCao_Click(object sender, RoutedEventArgs e)
        {


            List<string> list = pqDao.quyentheotennd(tennguoidung);
            bool quyen = false;
            foreach (var item in list)
            {
                if (item == "frmBaoCao")
                {
                    quyen = true;
                    break;
                }
                else
                {
                    quyen = false;
                }
            }
            if (quyen == true)
            {
                frmBaoCao frmBC = new frmBaoCao();
                frmBC.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền");
            }

        }

        private void cbnhommonan_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<NhomMonAn> list = nmaDao.dsnhomma();
            
            cbnhommonan.Items.Clear();
            cbnhommonan.ItemsSource = list;
            cbnhommonan.DisplayMemberPath = "TenNhomMonAn";
        }

        private void cbnhommonan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NhomMonAn nma = (NhomMonAn)cbnhommonan.SelectedItem;
            
            List<MonAn> list = maDao.dsmonantheonhom(nma.MaNhomMonAn);
            
            cbmonan.ItemsSource = list;
            cbmonan.DisplayMemberPath = "TenMonAn";
        }

        private void datagriddsmonan_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuTimKiem_Click(object sender, RoutedEventArgs e)
        {

            List<string> list = pqDao.quyentheotennd(tennguoidung);
            bool quyen = false;
            foreach (var item in list)
            {
                if (item == "frmTimKiem")
                {
                    quyen = true;
                    break;
                }
                else
                {
                    quyen = false;
                }
            }
            if (quyen == true)
            {
                frmTimKiem frmTK = new frmTimKiem();
                frmTK.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền");
            }

        }

        private void btthemmon_Click(object sender, RoutedEventArgs e)
        {
            MonAn ma=(MonAn)cbmonan.SelectedItem;
            
            if (ma != null)
            {
                var hoadonxuat = hdxDao.hdxchuathanhtoantheoban(int.Parse(txtban.Text));
                var chitiethdx = cthdxDao.cthdxtheohdxvamonan(hoadonxuat.MaHoaDonXuat, ma.MaMonAn);
                if (chitiethdx == null)
                {                
                    cthdxDao.themcthdx(hoadonxuat.MaHoaDonXuat, ma.MaMonAn, 1, int.Parse(ma.DonGia.ToString()));
                }
                else
                {
                    cthdxDao.suacthdx(hoadonxuat.MaHoaDonXuat, ma.MaMonAn, chitiethdx.SoLuong+1, int.Parse(ma.DonGia.ToString()));
                }
                loadcthdx(int.Parse(txtban.Text));

            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin");
            }
            }

        private void txtthanhtien_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        public void datban(int maban)
        {
            hdxDao.themhdx(maban, 1, 0, 0, 1);
            
        }

        public void loadcthdx(int maban)
        {
            var hoadonxuat = hdxDao.hdxchuathanhtoantheoban(maban);      
            List<ChiTietHoaDonXuat> lis =cthdxDao.cthdxtheohdx(hoadonxuat.MaHoaDonXuat);           
            double tong = 0;
            datagriddsmonan.Items.Clear();
            foreach (var item in lis)
            {
                var monan = maDao.matheoma(item.MaMonAn);
                datagriddsmonan.Items.Add(new
                {
                    Tenmon = monan.TenMonAn,
                    Soluong = item.SoLuong,
                    Dongia = monan.DonGia,
                });
                tong += (item.SoLuong * monan.DonGia);

            }
            
            txtthanhtien.Text = tong.ToString();
            
        }
        public void loadchitietban(int maban)
        {
            var ban = bDao.bantheoma(maban);
            if (ban.Status == "trống")
            {
                MessageBoxResult result = MessageBox.Show("Bàn này trống, bạn có muốn đặt bàn không?", "Thông báo", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    txtban.Text = maban.ToString();
                    datban(maban);
                    loadcthdx(maban);
                    
                    loadban();
                }

            }
            else
            {
                txtban.Text = maban.ToString();
                loadcthdx(maban);
            }
        }
        private void dgvban_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedItem = dgvban.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int maban = (int)anonymousType.GetProperty("Maban").GetValue(selectedItem, null);
                loadchitietban(maban);



            }
        }

        private void btlaphoadon_Click(object sender, RoutedEventArgs e)
        {
            if (txtban.Text != "")
            {
                frmHoaDon frmHD = new frmHoaDon();
                frmHD.maban = txtban.Text;
                frmHD.tabHD.SelectedItem = frmHD.tabhoadonxuat;
                frmHD.ShowDialog();
                loadban();
            }

           
            
        }
    }
}
