using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == textbox1.Text)
            {
                MessageBox.Show("капча введена правильно");
                button3.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("капча неправильна, попробуйте еще раз");
                Random rnd = new Random();
                double a = rnd.Next(20);
                textbox.Text = a.ToString();
            }
        }
        private void button_Click1(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            double a = rnd.Next(20);
            textbox.Text = a.ToString();
            button1.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Visible;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}
