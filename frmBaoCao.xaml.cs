
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
    /// Interaction logic for frmBaoCao.xaml
    /// </summary>
    public partial class frmBaoCao : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        HoadonxuatDAO hdxDao= new HoadonxuatDAO();
        PhanquyenDAO pqDao= new PhanquyenDAO();
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void datedoanhthu_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selected = (DateTime)datedoanhthu.SelectedDate;

            
            datagirdoanhthu.Items.Clear();
            List<HoaDonXuat> list = hdxDao.dshdxtheongay(selected);
           
            double tong = 0;
            foreach (var item in list)
            {
                var nhanvien =pqDao.nhanvientheoma(item.MaNhanVien);
                datagirdoanhthu.Items.Add(new
                {
                    Mahoadon = item.MaHoaDonXuat,
                    Manhanvien = item.MaNhanVien,
                    Tennhanvien= nhanvien.TenNhanVien,
                    Tongtien = item.TongTien,
                });
                tong += item.TongTien;
            }
            txttongdt.Text=tong.ToString();
        }

        private void datenlt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
            
        }
    }
}
