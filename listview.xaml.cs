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
using word = Microsoft.Office.Interop.Word;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для listview.xaml
    /// </summary>
    public partial class listview : Window
    {
        listviewEntities2 db = new listviewEntities2();
        List<Table_1> books;

        public listview()
        {
            InitializeComponent();
            books = db.Table_1.ToList<Table_1>();

            for (int i = 0; i < books.Count; i++)
            {
                WrapPanel wp = new WrapPanel();
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                Label lb = new Label();

                wp.Height = 300;
                wp.Width = 200;

                lb.Content = books[i].imya.ToString();

                string savePath = "C:\\Users\\nvidi\\OneDrive\\Рабочий стол\\коды\\треня\\WpfApp1\\res";
                savePath = savePath + "\\" + books[i].image.ToString() + ".png";
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(savePath);
                bm.EndInit();
                img.Source = bm;

                img.MouseDown += new MouseButtonEventHandler(MyImage_MouseDown);

                img.Height = 250;
                img.Width = 200;

                img.Uid = books[i].id.ToString();

                wp.Children.Add(img);
                wp.Children.Add(lb);
                listView1.Items.Add(wp);
            }
        }

        private void MyImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mousePoint = Mouse.GetPosition(this);
            IInputElement element = InputHitTest(mousePoint);
            string elementName = (element as FrameworkElement)?.Uid;

            int id = Convert.ToInt32(elementName);

            var book = books.Find(x => x.id == id);
            string savePath = "C:\\Users\\nvidi\\OneDrive\\Рабочий стол\\коды\\треня\\WpfApp1\\res";
            savePath = savePath + "\\" + book.image.ToString() + ".png";
            BitmapImage bm = new BitmapImage();
            bm.BeginInit();
            bm.UriSource = new Uri(savePath);
            bm.EndInit();
            imgBook.Source = bm;
            BookName.Content = book.imya.ToString();
            ContentBook.Text = book.text.ToString();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            // Создать экземпляр приложения Word
            
        }
    }
}