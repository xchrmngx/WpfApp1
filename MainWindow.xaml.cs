using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        trenyaEntities5 db = new trenyaEntities5();
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
                var data = db.fio.FirstOrDefault();
                if (data != null)
                {
                    string value = data.фио;
                    textbox.Text = value;
                    label.Content = value;
                }
            var data2 = db.fio.ToList();
            var comboBoxItems = data2.Select(x => new ComboBoxItem { Content = x.фио});
            combobox.ItemsSource = comboBoxItems;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            var data = db.fio.FirstOrDefault(x => x.фио == proverka.Text);

            if (data == null)
            {
                MessageBox.Show("f"); // Данные не найдены
            }
            else
            {
                if (data.фио == proverka.Text)
                {
                    MessageBox.Show("a"); // Данные совпадают
                }
            }

        }
    }
}
