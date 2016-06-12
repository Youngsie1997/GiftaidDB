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

namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for IdDialog.xaml
    /// </summary>
    public partial class IdDialog : Window
    {
        public IdDialog(string question, string defaultAnswer = "")
        {
            InitializeComponent();
            lblQuestion.Content = question;
            txtID.Text = defaultAnswer;
        }

        private void inputwindow_ContentRendered(object sender, EventArgs e)
        {
            txtID.SelectAll();
            txtID.Focus();
            txtID.MaxLength = 6;
        }

        private void btdialogOk_Click(object sender, RoutedEventArgs e)
        {
           DialogResult = true;
        }

        public int Id
        {
            get { return Convert.ToInt32(txtID.Text); }
        }

        private void txtID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }

            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.NumLock:
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.Back:
                case Key.Return:
                    break;
                default:
                    e.Handled = true;
                    break;

            }
        }
    }
}
