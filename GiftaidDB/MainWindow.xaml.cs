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
using Npgsql;
namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        #region ConnectionStuff
        NpgsqlConnection conn = new NpgsqlConnection("Server=185.116.213.89;Port=5432;User Id=connor;Password=poop;Database=oxfam;"); //Connection string for the Npgsql connecton adapter this needs to be moved to an external source.
        
        public void OpenConn() //A method to handle the connection to the database including error logging.
        {
            try
            {
                conn.Open(); //Opens the connection.
            }
            catch(Exception Error)
            {
                MessageBox.Show(Error.ToString()); //Displays any errors that have occured to the user via  a messagebox.
                this.CloseConn(); //Closes the connection incase the error happened after the connection was made.
            }
        }

        public void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString()); //Displays any errors that prevented the connection from closing typically the connection already being closed.
                
            }
        }


        #endregion

        private void Input_Loaded(object sender, RoutedEventArgs e) //sets textbox length for textboxes so it cant cause errors when inputing.
        {
            tbItemID.MaxLength = 50;
            tbItemID.MaxLines = 1;
            
            tbGiftAid_Number.MaxLength = 14;
            tbGiftAid_Number.MaxLines = 1;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {

            if(tbItemID.Text.ToString() != "" && tbGiftAid_Number.Text.ToString() != "")
            {
                try
                {
                    this.OpenConn();
                    //sql statement
                    string sql = "INSERT INTO GiftAid(item_id,giftaid_number,status,created_date,last_modified_date) Values('" + tbItemID.Text.ToString() + "','" + tbGiftAid_Number.Text.ToString() + "','" + cbStatus.Text.ToString() + "','now','now');";
                    NpgsqlCommand insertCommand = new NpgsqlCommand(sql, conn);
                    int success = insertCommand.ExecuteNonQuery();
                    MessageBox.Show(Convert.ToString(success));
                    this.CloseConn();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    this.CloseConn();
                }
            }
            else
            {
                MessageBox.Show("Please make sure you have filled out all text fields correctly");
            }
            
 

          
        }

        private void btViewer_Click(object sender, RoutedEventArgs e) // Displays the second window with the datagrid on
        {
            GiftaidViewer GaViewer = new GiftaidViewer();
            GaViewer.Show();          
        }

        private void tbRemove_KeyDown(object sender, KeyEventArgs e) //prevents user from entering anything but numbers in the id text field since its numbers only 
        {
           switch(e.Key)
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
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if(tbRemove.Text.ToString() != "")
            {
                try
                {
                    this.OpenConn();
                    string sql = "DELETE FROM giftaid WHERE id = "+tbRemove.Text.ToString()+"";
                    NpgsqlCommand deleteCommand = new NpgsqlCommand(sql, conn);
                    int success = deleteCommand.ExecuteNonQuery();
                    MessageBox.Show(Convert.ToString(success));
                    this.CloseConn();
                }
                catch(Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    this.CloseConn();
                }
            }
            else
            {
                MessageBox.Show("Please enter the id of the record you would like to remove in the field bellow");
            }
        }
    }
    
}
