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
using Word = Microsoft.Office.Interop.Word;

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
        private void Repwo(string subToReplace, string text, Word.Document worddoc)
        {
            var range = worddoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: subToReplace, ReplaceWith: text);
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var wordApp = new Word.Application();
                // Make Word application visible (optional)
                wordApp.Visible = true;
                // Create a new blank document
                var wordDoc = wordApp.Documents.Add();
                // Add text to the document
                string text = textbox.Text;
                string text2 = textbox2.Text;
                int i = 1;
                wordDoc.Content.Text = "Номер чека: " + i++.ToString() + "\n" + text + "\n" + text2;
                // Save the document as "MyDocument.docx"
                wordDoc.SaveAs2(@"C:\\Users\\nvidi\\Desktop\\Номер чека .docx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
