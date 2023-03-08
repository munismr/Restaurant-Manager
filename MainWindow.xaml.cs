
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nguoidung = from nd in db.NguoiDungs
                            select nd;
            bool dangnhap = true;
            foreach (var n in nguoidung)
            {
                if (txtuser.Text == n.TenNguoiDung && txtpassword.Password == n.MatKhau)
                {

                    frmMain frmm = new frmMain();
                    frmm.tennguoidung = txtuser.Text;
                    frmm.ShowDialog();
                   
                    dangnhap = true;
                    break;
                }
                else
                {
                    dangnhap = false;
                }
            }
            if (dangnhap == false)
            {
                MessageBox.Show("thông tin tài khoản hoặc mật khẩu không chính xác!");
            }

            
        }


    }
}
