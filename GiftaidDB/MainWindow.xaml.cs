using System;
using System.IO;
using System.Data;
using System.Drawing;
using BarcodeLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using PostgreSQL_Connection;
namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connection giftaidConnection = new Connection();
        public MainWindow()
        {
            InitializeComponent();
        }

      
        


        NpgsqlConnection conn; //Create connection that i'm going to set with the loaded event.
        private void Input_Loaded(object sender, RoutedEventArgs e) //sets textbox length for textboxes so it cant cause errors when inputing. presents a error insturcting user to add the file with a correct psql string then closes app as its useless without a connection to psql.
        {

           if(File.Exists("Connection.xml")) //Check if file exists as the application won't load without it.
            {
                conn = giftaidConnection.CreateConn("Connection.xml");
            }
           else
            {
                MessageBox.Show("Please make sure Connection.xml is in the directory and contains a valid psql element see ConnectionExample..","The Connection File Is Missing",MessageBoxButton.OK,MessageBoxImage.Error ); 
                Application.Current.Shutdown();
            }


            

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
                    giftaidConnection.OpenConn(conn);
                    //sql statement
                    string sql = "INSERT INTO GiftAid(item_id,giftaid_number,status,created_date,last_modified_date) Values('" + tbItemID.Text.ToString() + "','" + tbGiftAid_Number.Text.ToString() + "','" + cbStatus.Text.ToString() + "','now','now');";
                    NpgsqlCommand insertCommand = new NpgsqlCommand(sql, conn);
                    int success = insertCommand.ExecuteNonQuery();
                    if(success == 1)
                    {
                        MessageBox.Show("Success!!!");
                    }
                    else if(success < 1)
                    {
                        MessageBox.Show("Something went wrong:(");
                    }
                    giftaidConnection.CloseConn(conn);
                    tbItemID.Focus();
                    tbItemID.Text = "";
                    tbGiftAid_Number.Text = "";





                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    giftaidConnection.CloseConn(conn);
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
                    giftaidConnection.Delete(conn, Convert.ToInt32(tbRemove.Text));

                }
                catch(Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    giftaidConnection.OpenConn(conn);
                }
            }
            else
            {
                MessageBox.Show("Please enter the id of the record you would like to remove in the field bellow");
            }
        }

        private void tbItemID_KeyDown(object sender, KeyEventArgs e) //Sets the focus to the next field makes it easier to input the data.
        {
            if(e.Key == Key.Return )
            {
                tbGiftAid_Number.Focus();
            }
        }

        private void tbGiftAid_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                cbStatus.Focus();
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

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbRemove.Text.ToString() != "")
            {
                giftaidConnection.Update(conn, cbStatus.Text.ToString(), Convert.ToInt32(tbRemove.Text));
            }
            else
            {
                MessageBox.Show("Please enter the id of the record you would like to Update in the field bellow");
            }
        }

        private void tbRemove_PreviewKeyDown(object sender, KeyEventArgs e) //needed a seperate event to handle space  before the other event could.
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btBarcode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Barcode_Generator giftaidBarcodeGenerator = new Barcode_Generator();
                if (File.Exists("Connection.xml"))
                {
                    conn = giftaidConnection.CreateConn("Connection.xml");
                }

                Barcode giftaidBarcode = new Barcode()
                {
                    IncludeLabel = true,
                    Alignment = AlignmentPositions.CENTER,
                    LabelPosition = LabelPositions.BOTTOMCENTER,
                    Width = 150,
                    Height = 150,
                    RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                if(tbRemove.Text != "")
                {
                    giftaidConnection.OpenConn(conn);
                    string sql = "SELECT * FROM giftaid WHERE ID = " + tbRemove.Text + "";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];

                    giftaidBarcodeGenerator.BarcodePicbox.Image = giftaidBarcode.Encode(TYPE.ITF14, "" + dt.Rows[0][2] + "");
                    giftaidBarcodeGenerator.Show();
                    giftaidConnection.CloseConn(conn);
                }
                else
                {
                    MessageBox.Show("Please make sure you have entered a valid id into the Id textbox bellow","Barcode-Generator",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Make sure the id of the row entered into the textbox exists in table","Barcode-Generator",MessageBoxButton.OK,MessageBoxImage.Error);
               
            }
        }

        private void btBarcode_Printer_Click(object sender, RoutedEventArgs e)
        {
            Barcode_Printer barcodeprint = new Barcode_Printer();
            barcodeprint.Show();
        }
    }
    
}
