
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
    /// Interaction logic for frmNguyenLieu.xaml
    /// </summary>
    public partial class frmNguyenLieu : Window
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        NhomnlDAO nnlDao = new NhomnlDAO();
        NguyenlieuDAO nlDao = new NguyenlieuDAO();
        NhommaDAO nmaDao= new NhommaDAO();
        MonanDAO maDao= new MonanDAO();
        DinhluongDAO dlDao = new DinhluongDAO();
        NhaccDAO nccDao=new NhaccDAO();
        KhachhangDAO khDao = new KhachhangDAO();
        public frmNguyenLieu()
        {
            this.InitializeComponent();
            InitializeComponent();
        }

       

        private void btthoat_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }



       

        private void cbnhommonan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void datagirdmonan_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        

        private void btthoatmonan_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



       

        public void loadnnl()
        {
            var nhomnl = nnlDao.dsnnl();
            datagirdnhomnl.Items.Clear();
            foreach (var item in nhomnl)
            {
                datagirdnhomnl.Items.Add(new
                {
                    Manhomnguyenlieu = item.MaNhomNguyenLieu,
                    Tennhomnguyenlieu = item.TenNhomNguyenLieu,
                });
            }
        }
        private void datagirdnhomnl_Loaded(object sender, RoutedEventArgs e)
        {
            loadnnl();
        }

        private void btthemnnl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool themnnl = nnlDao.themnnl(txttennnl.Text);
                if (themnnl == true) {                                      
                    loadnnl();
                    loadcbnhomnl();
                    MessageBox.Show("Đã thêm thành công");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại nhóm nguyên liệu này");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }

        }

        private void datagirdnhomnl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagirdnhomnl.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int mannl = (int)anonymousType.GetProperty("Manhomnguyenlieu").GetValue(selectedItem, null);
                string tennnl = (string)anonymousType.GetProperty("Tennhomnguyenlieu").GetValue(selectedItem, null);
                txttennnl.Text = tennnl;
               
                loadnguyenlieu(mannl);

            }
        }

        private void btsuannl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagirdnhomnl.SelectedItem;
                if (selectedItem != null)
                {
                    var anonymousType = selectedItem.GetType();
                    string tennnl = (string)anonymousType.GetProperty("Tennhomnguyenlieu").GetValue(selectedItem, null);
                    nnlDao.suannl(tennnl, txttennnl.Text);
                    loadnnl();
                    loadcbnhomnl();
                    MessageBox.Show("Đã sửa thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhóm nguyên liệu muốn sửa");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        //private void btxoannl_Click(object sender, RoutedEventArgs e)
        //{
        //    var selectedItem = datagirdnhomnl.SelectedItem;
        //    if (selectedItem != null)
        //    {
        //        var anonymousType = selectedItem.GetType();
        //        int mannl = (int)anonymousType.GetProperty("Manhomnguyenlieu").GetValue(selectedItem, null);
        //        string tennnl = (string)anonymousType.GetProperty("Tennhomnguyenlieu").GetValue(selectedItem, null);
        //        nlDao.xoanltheonhom(mannl);
        //        nnlDao.xoannl(tennnl);
        //        loadnnl();
        //        loadcbnhomnl();
        //        MessageBox.Show("Đã xóa thành công");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn nhóm nguyên liệu muốn xóa");
        //    }
        //}
        public void loadnguyenlieu(int Manll)
        {

            var nguyenlieu = nlDao.dsnguyenlieutheonhom(Manll);
            datagirdnl.Items.Clear();
            foreach (var nl in nguyenlieu)
            {
                datagirdnl.Items.Add(new
                {
                    Manguyenlieu = nl.MaNguyenLieu,
                    Tennguyenlieu = nl.TenNguyenLieu,
                    Donvitinh = nl.DonViTinh,
                    Dongia = nl.DonGia,
                    Soluong = nl.SoLuong,
                });
            }
        }
        private void datagirdnl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btthemnl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NhomNguyenLieu nnl = (NhomNguyenLieu)cbnhom.SelectedItem;
                if(nnl != null)
                {
                    bool themnl = nlDao.themnl(txttennl.Text, nnl.MaNhomNguyenLieu, int.Parse(txtdongia.Text), txtdvt.Text, int.Parse(txtsoluong.Text));

                    if (themnl == true)
                    {
                        MessageBox.Show("Đã thêm thành công");
                        txttennl.Text = "";
                        txtdongia.Text = "";
                        txtdvt.Text = "";
                        txtsoluong.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại nguyên liệu này");
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
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        public void loadcbnhomnl()
        {

            List<NhomNguyenLieu> list = nnlDao.dsnnl();
            
            cbnhom.ItemsSource = list;
            cbnhom.DisplayMemberPath = "TenNhomNguyenLieu";
        }
        private void cbnhom_Loaded(object sender, RoutedEventArgs e)
        {
            loadcbnhomnl();
            loadnnl();
        }

        

        private void btsuanl_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                NhomNguyenLieu nnl = (NhomNguyenLieu)cbnhom.SelectedItem;
                if (nnl != null)
                {
                    var selectedItem = datagirdnl.SelectedItem;
                    if (selectedItem != null)
                    {

                        var anonymousType = selectedItem.GetType();
                        int manl = (int)anonymousType.GetProperty("Manguyenlieu").GetValue(selectedItem, null);

                        nlDao.suanl(manl, txttennl.Text, nnl.MaNhomNguyenLieu, int.Parse(txtdongia.Text), txtdvt.Text, int.Parse(txtsoluong.Text));
                        datagirdnhomnl.SelectedItem = nnl;
                        MessageBox.Show("Đã sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn nhóm nguyên liệu muốn sửa");
                    }
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

        private void datagirdnl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagirdnl.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int manl = (int)anonymousType.GetProperty("Manguyenlieu").GetValue(selectedItem, null);
                var nguyenlieu = nlDao.nguyenlieutheoma(manl);
                var nhomnl = nnlDao.nnltheoma(nguyenlieu.MaNhomNguyenLieu);
                txttennl.Text = nguyenlieu.TenNguyenLieu;
                cbnhom.SelectedItem = nhomnl;
                txtdongia.Text = nguyenlieu.DonGia.ToString();
                txtdvt.Text = nguyenlieu.DonViTinh;
                txtsoluong.Text = nguyenlieu.SoLuong.ToString();
            }
        }
        //private void btxoanl_Click(object sender, RoutedEventArgs e)
        //{
        //    var selectedItem = datagirdnl.SelectedItem;
        //    if (selectedItem != null)
        //    {
                
        //        var anonymousType = selectedItem.GetType();
        //        int manl = (int)anonymousType.GetProperty("Manguyenlieu").GetValue(selectedItem, null);
        //        var nguyenlieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == manl);
        //        db.NguyenLieus.Remove(nguyenlieu);

        //        db.SaveChanges();
                
        //        MessageBox.Show("Đã xóa thành công");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn nhóm nguyên liệu muốn xóa");
        //    }
        //}

        //monan va nhom mon an
        public void loadnma()
        {
            var nhomma = nmaDao.dsnhomma();
            datagirdnhomma.Items.Clear();
            foreach (var item in nhomma)
            {
                datagirdnhomma.Items.Add(new
                {
                    Manhommonan = item.MaNhomMonAn,
                    Tennhommonan = item.TenNhomMonAn,
                });
            }
        }
        private void datagirdnhomma_Loaded(object sender, RoutedEventArgs e)
        {
            loadnma();
        }

        private void btthemnma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool themnma = nmaDao.themnma(txttennma.Text);
                if (themnma == true)
                {
                    
                    loadnma();
                    loadcbnhomma();
                    MessageBox.Show("Đã thêm thành công");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại nhóm món ăn này");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }

        }

        private void datagirdnhomma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagirdnhomma.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int manma = (int)anonymousType.GetProperty("Manhommonan").GetValue(selectedItem, null);
                string tennma = (string)anonymousType.GetProperty("Tennhommonan").GetValue(selectedItem, null);
                txttennma.Text = tennma;

                loadmonan(manma);

            }
        }

        private void btsuanma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagirdnhomma.SelectedItem;
                if (selectedItem != null)
                {
                    var anonymousType = selectedItem.GetType();
                    string tennma = (string)anonymousType.GetProperty("Tennhommonan").GetValue(selectedItem, null);
                    nmaDao.suannm(tennma, txttennma.Text);
                    
                    loadnma();
                    loadcbnhomma();
                    MessageBox.Show("Đã sửa thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhóm món ăn muốn sửa");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void btxoanma_Click(object sender, RoutedEventArgs e)
        {
            //var selectedItem = datagirdnhomma.SelectedItem;
            //if (selectedItem != null)
            //{
            //    var anonymousType = selectedItem.GetType();
            //    string tennma = (string)anonymousType.GetProperty("Tennhommonan").GetValue(selectedItem, null);
            //    var nhomma = db.NhomMonAns.SingleOrDefault(nma => nma.TenNhomMonAn == tennma);
            //    db.NhomMonAns.Remove(nhomma);
            //    db.SaveChanges();
            //    loadnma();
            //    loadcbnhomma();
            //    MessageBox.Show("Đã xóa thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn nhóm món ăn muốn xóa");
            //}
        }
        public void loadmonan(int Manma)
        {

            var monan = maDao.dsmonantheonhom(Manma);
            datagirdma.Items.Clear();
            foreach (var ma in monan)
            {
                datagirdma.Items.Add(new
                {
                    Mamonan = ma.MaMonAn,
                    Tenmonan = ma.TenMonAn,
                    
                    Dongia = ma.DonGia,
                    Donvitinh = ma.DonViTinh,

                });
            }
        }
        private void datagirdma_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btthemma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NhomMonAn nma = (NhomMonAn)cbnhomma.SelectedItem;
                if (nma != null)
                {
                    bool themma = maDao.themma(txttenma.Text, nma.MaNhomMonAn, int.Parse(txtgiama.Text), txtdvtma.Text);
                    if (themma == true)
                    {

                      
                        MessageBox.Show("Đã thêm thành công");
                        txttenma.Text = "";
                        txtgiama.Text = "";
                        txtdvtma.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại món ăn này này");
                    }

                }

                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        public void loadcbnhomma()
        {
            
            List<NhomMonAn> list = nmaDao.dsnhomma();
            
            cbnhomma.ItemsSource = list;
            cbnhomma.DisplayMemberPath = "TenNhomMonAn";
        }
        private void cbnhomma_Loaded(object sender, RoutedEventArgs e)
        {
            loadcbnhomma();
            loadnma();
        }



        private void btsuama_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NhomMonAn nma = (NhomMonAn)cbnhomma.SelectedItem;
                if(nma != null)
                {
                    var selectedItem = datagirdma.SelectedItem;
                    if (selectedItem != null)
                    {

                        var anonymousType = selectedItem.GetType();
                        int mama = (int)anonymousType.GetProperty("Mamonan").GetValue(selectedItem, null);

                        maDao.suama(mama, txttenma.Text, nma.MaNhomMonAn, int.Parse(txtgiama.Text), txtdvtma.Text);

                        datagirdnhomma.SelectedItem = nma;
                        MessageBox.Show("Đã sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn món ăn muốn sửa");
                    }
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

        private void datagirdma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagirdma.SelectedItem;
            if (selectedItem != null)
            {

                var anonymousType = selectedItem.GetType();
                int mama = (int)anonymousType.GetProperty("Mamonan").GetValue(selectedItem, null);
                var monan = maDao.matheoma(mama);
                var nhomma = nmaDao.nmatheoma(monan.MaNhomMonAn);
                txttenma.Text = monan.TenMonAn;
                cbnhomma.SelectedItem = nhomma;
                txtgiama.Text = monan.DonGia.ToString();
                txtdvtma.Text = monan.DonViTinh;
                
            }
        }
        private void btxoama_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var selectedItem = datagirdma.SelectedItem;
            //    if (selectedItem != null)
            //    {

            //        var anonymousType = selectedItem.GetType();
            //        int mama = (int)anonymousType.GetProperty("Mamonan").GetValue(selectedItem, null);
            //        var monan = db.MonAns.SingleOrDefault(ma => ma.MaMonAn == mama);
            //        db.MonAns.Remove(monan);

            //        db.SaveChanges();

            //        MessageBox.Show("Đã xóa thành công");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng chọn monan muốn xóa");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    MessageBox.Show("Có lỗi vui lòng thử lại");
            //}
        }

        //dinhluong
        private void datagirdnguyenlieudl_Loaded(object sender, RoutedEventArgs e)
        {

            var nguyenlieu = nlDao.dsnguyenlieu();
            datagirdnguyenlieudl.Items.Clear();
            foreach (var nl in nguyenlieu)
            {
                datagirdnguyenlieudl.Items.Add(new
                {
                    Manguyenlieu = nl.MaNguyenLieu,
                    Tennguyenlieu = nl.TenNguyenLieu,
                    Donvitinh = nl.DonViTinh,

                });
            }
        }

        private void cbmonandl_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<MonAn> list = maDao.dsmonan();
           
            cbmonandl.ItemsSource = list;
            cbmonandl.DisplayMemberPath = "TenMonAn";
        }

        private void cbmonandl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadmonandl();
        }

        private void btthemnldl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagirdnguyenlieudl.SelectedItem;
                MonAn ma = (MonAn)cbmonandl.SelectedItem;
                if (selectedItem != null && ma != null)
                {

                    var anonymousType = selectedItem.GetType();
                    int Manldl = (int)anonymousType.GetProperty("Manguyenlieu").GetValue(selectedItem, null);
                    var dinhluong = dlDao.dltheonlvama(Manldl, ma.MaMonAn);
                    if (dinhluong == null)
                    {
                        dlDao.themdl(Manldl, ma.MaMonAn, 1);
                        
                    }
                    else
                    {
                        dlDao.suadl(dinhluong.MaDinhLuong,Manldl, ma.MaMonAn,  dinhluong.SoLuong + 1);
                       
                    }
                    loadmonandl();



                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 món ăn");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Có lỗi vui lòng thử lại");
            }
        }

        public void loadmonandl()
        {
            MonAn ma=(MonAn)cbmonandl.SelectedItem;
            
            List<DinhLuong> list= dlDao.dltheoma(ma.MaMonAn);
            
            datagirldl.Items.Clear();
            foreach (var item in list)
            {
                var nguyenlieu=nlDao.nguyenlieutheoma(item.MaNguyenLieu);
                datagirldl.Items.Add(new
                {
                    Manguyenlieu = nguyenlieu.MaNguyenLieu,
                    Tennguyenlieu = nguyenlieu.TenNguyenLieu,
                    Soluong = item.SoLuong,
                });
            }
        }

        private void btxoanldl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagirldl.SelectedItem;
                MonAn ma = (MonAn)cbmonandl.SelectedItem;
                if (selectedItem != null && ma!=null)
                {

                    var anonymousType = selectedItem.GetType();
                    int Manldl = (int)anonymousType.GetProperty("Manguyenlieu").GetValue(selectedItem, null);
                    dlDao.xoadl(Manldl, ma.MaMonAn);
                    loadmonandl();



                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Có lỗi vui lòng thử lại");
            }
        }

        //nhacungcap

        public void loadncc()
        {
            var nhacc = nccDao.dsnhacc();
            datagirdncc.Items.Clear();
            foreach (var ncc in nhacc)
            {
                datagirdncc.Items.Add(new
                {
                    Mancc = ncc.MaNhaCungCap,
                    Tenncc = ncc.TenNhaCungCap,
                    Diachi = ncc.DiaChi,
                    Dienthoai=ncc.DienThoai,
                    Email=ncc.Email,
                });
            }
        }
        private void datagirdncc_Loaded(object sender, RoutedEventArgs e)
        {
            loadncc();
        }
        private void datagirdncc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagirdncc.SelectedItem;
            if (selectedItem != null)
            {
                var anonymousType = selectedItem.GetType();
                int Manhacungcap = (int)anonymousType.GetProperty("Mancc").GetValue(selectedItem, null);
                var nhacc = nccDao.ncctheoma(Manhacungcap);
                txttenncc.Text = nhacc.TenNhaCungCap;
                txtdcncc.Text = nhacc.DiaChi;
                txtdtncc.Text = nhacc.DienThoai;
                txtemailncc.Text = nhacc.Email;

            }

        }

        private void btthemncc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                nccDao.themncc(txttenncc.Text, txtdcncc.Text, txtdtncc.Text, txtemailncc.Text);
                txtdtncc.Text = "";
                txttenncc.Text = "";
                txtdcncc.Text = "";
                txtemailncc.Text = "";
                loadncc();
                MessageBox.Show("Thêm thành công");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void btsuancc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagirdncc.SelectedItem;
                if (selectedItem != null)
                {
                    var anonymousType = selectedItem.GetType();
                    int Manhacungcap = (int)anonymousType.GetProperty("Mancc").GetValue(selectedItem, null);
                    nccDao.suancc(Manhacungcap, txttenncc.Text, txtdcncc.Text, txtdtncc.Text, txtemailncc.Text);
                    
                    loadncc();
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("vui lòng chọn nhà cung cấp muốn sửa!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("vui lòng nhập đủ thông tin!");
            }


        }

        //khach hang
        public void loadkhachhang()
        {
            var khachhang = khDao.dskh() ;
            datagirdkhachhang.Items.Clear();
            foreach (var kh in khachhang)
            {
                datagirdkhachhang.Items.Add(new
                {
                    Makh = kh.MaKhachHang,
                    Tenkh = kh.TenKhachHang,
                    Diachi = kh.DiaChi,
                    Dienthoai=kh.DienThoai,
                    Email=kh.Email,
                });
            }
        }



        private void datagirdkhachhang_Loaded(object sender, RoutedEventArgs e)
        {
            loadkhachhang();
        }

        private void btthemkh_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                khDao.themkh(txttenkh.Text, txtdckh.Text, txtdtkh.Text, txtemailkh.Text);
                
                loadkhachhang();
                MessageBox.Show("Thêm thành công");
                txttenkh.Text = "";
                txtdckh.Text = "";
                txtdtkh.Text = "";
                txtemailkh.Text = "";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void btsuakh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = datagirdkhachhang.SelectedItem;
                if (selectedItem != null)
                {
                    var anonymousType = selectedItem.GetType();
                    int Makh = (int)anonymousType.GetProperty("Makh").GetValue(selectedItem, null);
                    khDao.suakh(Makh,txttenkh.Text, txtdckh.Text, txtdtkh.Text, txtemailkh.Text);
                    loadkhachhang();
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("vui lòng chọn khách hàng muốn sửa!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("vui lòng nhập đủ thông tin!");
            }

        }

        private void datagirdkhachhang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = datagirdkhachhang.SelectedItem;
            if (selecteditem != null)
            {
                var anonymoustype = selecteditem.GetType();
                int makh = (int)anonymoustype.GetProperty("Makh").GetValue(selecteditem, null);
                var khachhang = khDao.khtheoma(makh);
                txttenkh.Text = khachhang.TenKhachHang;
                txtdckh.Text = khachhang.DiaChi;
                txtdtkh.Text = khachhang.DienThoai;
                txtemailkh.Text = khachhang.Email;

            }
        }

    }
}
