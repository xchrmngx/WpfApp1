using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
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
            users = db.Пользователь.ToList();
            capcha();
            GetRegistryTime();
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
                //создаем набор символов, из которых будет формироваться капча
                String allowchar = " ";
                allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                allowchar = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
                allowchar = "1,2,3,4,5,6,7,8,9,0";
                char[] a = { ',' };
                //Записываем набор символов в массив
                String[] ar = allowchar.Split(a);

                String pwd = "";//переменная в которой будет хранится значение капчи
                string temp = " ";//переменная, в которую будет записываться рандомный символ из массива
                Random r = new Random();

                int kol = 6;//количество символов в капче

                for (int i = 0; i < kol; i++)
                { //генерируем рандомный символ массива
                  //берем элемента массива и задаем рандомный индекс с элемента
                  //диапазон рандома начинается с 0 и зананчивается длинной массива символов
                    temp = ar[(r.Next(0, ar.Length))];
                    pwd += temp;
                }
                //вывод сформированного текста в поле
                label2.Content = pwd;

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}
