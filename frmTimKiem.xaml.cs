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
    /// Interaction logic for frmTimKiem.xaml
    /// </summary>
    public partial class frmTimKiem : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        HoadonnhapDAO hdnDao= new HoadonnhapDAO();
        HoadonxuatDAO hdxDao= new HoadonxuatDAO();
        PhanquyenDAO pqDao= new PhanquyenDAO();
        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void datagirdtkhdn_Loaded(object sender, RoutedEventArgs e)
        {
            //datagirdtkhdn.Items.Add(new
            //{
            //    Sohd = 129,
            //    Thoigian = "2/25/2023 10:37:58 PM",
            //    Nhanvien = "Vũ Thị Dung",
            //    Nhacc = "Kim Lân",
            //    Tongtien = 203000,
            //});
        }

        private void datagridtkhdx_Loaded(object sender, RoutedEventArgs e)
        {
            //datagridtkhdx.Items.Clear();
            //datagridtkhdx.Items.Add(new
            //{
            //    Sohd = 127,
            //    Thoigian = "2/25/2023 10:43:15 PM",
            //    Nhanvien = "Kim Hoàn",
            //    Khachhang = "Vũ Thị Kim",
            //    Tongtien = 129000,
            //});
        }

        private void bttimhdn_Click(object sender, RoutedEventArgs e)
        {
            DateTime selected = (DateTime)datetkhdn.SelectedDate;
            NhanVien nv = (NhanVien)txttennvnhap.SelectedItem;
            if(selected!=null && nv!=null)
            {
                datagirdtkhdn.Items.Clear();
                var Hoadonnhap = hdnDao.hdntheotgvanv(selected, nv.MaNhanVien);
                foreach (var item in Hoadonnhap)
                {
                    datagirdtkhdn.Items.Add(new
                    {
                        Sohd = item.MaHoaDonNhap,
                        Thoigian = item.ThoiGian,
                        Nhanvien = nv.TenNhanVien,
                        
                        Tongtien = item.TongTien,
                    });
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            
        }

        private void txttennvnhap_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<NhanVien> list = pqDao.dsnhanvien();
            
            txttennvnhap.ItemsSource=list;
            txttennvnhap.DisplayMemberPath = "TenNhanVien";
        }

        private void bttimhdx_Click(object sender, RoutedEventArgs e)
        {
            DateTime selected = (DateTime)datehdx.SelectedDate;
            NhanVien nv = (NhanVien)txttennvxuat.SelectedItem;
            if (selected != null && nv != null)
            {
                datagridtkhdx.Items.Clear();
                var Hoadonxuat = hdxDao.dshdxtheongayvanv(selected,nv.MaNhanVien);
                foreach (var item in Hoadonxuat)
                {
                    datagridtkhdx.Items.Add(new
                    {
                        Sohd = item.MaHoaDonXuat,
                        Thoigian = item.ThoiGianVao,
                        Nhanvien = nv.TenNhanVien,

                        Tongtien = item.TongTien,
                    });
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        private void txttennvxuat_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<NhanVien> list = pqDao.dsnhanvien();
            
            txttennvxuat.ItemsSource = list;
            txttennvxuat.DisplayMemberPath = "TenNhanVien";
        }
    }
}
