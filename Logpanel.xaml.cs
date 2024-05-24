using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для Logpanel.xaml
    /// </summary>
    public partial class Logpanel : Window
    {
        public Logpanel()
        {
            InitializeComponent();
        }
        trenyaEntities5 db = new trenyaEntities5();
        List<users> regusers = new List<users>();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var user = db.users.FirstOrDefault(x => x.login == textbox1.Text && x.password == textbox2.Text);

            if (user == null) 
            {
                MessageBox.Show("Данные неверны");
            }
            else if (user.password == textbox2.Text && user.login == textbox1.Text)
            {
                if (user.type == 1)
                {
                    User1 okno = new User1(user);
                    okno.Show();
                    Close();
                }
                else if (user.type == 2) 
                {
                    User2 okno2 = new User2(user);
                    okno2.Show();
                    Close();
                }
                else if (user.type == 3)
                {
                    User3 okno3 = new User3(user);
                    okno3.Show();
                    Close();
                }
            }
        }


        private void button_reg_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(type_box.Text);
            var user = db.users.FirstOrDefault(x => x.login == login_box.Text && x.password == pass_box.Text && x.FIO == fio_box.Text && x.type == a);
            if (login_box.Text != "" && pass_box.Text != "" && fio_box.Text != "")
            {
                users users = new users
                {
                    login = login_box.Text,
                    password = pass_box.Text,
                    FIO = fio_box.Text,
                    type = a
                };
                db.users.Add(users);
                regusers.Add(user);
                db.SaveChanges();
                MessageBox.Show("Пользователь добавлен");
            }
            
        }
    }
}
