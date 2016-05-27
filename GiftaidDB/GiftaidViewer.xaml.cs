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
using Npgsql;
using System.Data;


namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for GiftaidViewer.xaml
    /// </summary>
    public partial class GiftaidViewer : Window
    {
        public GiftaidViewer()
        {
            InitializeComponent();
        }
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        #region ConnectionStuff
        NpgsqlConnection conn = new NpgsqlConnection("Server=185.116.213.89;Port=5432;User Id=connor;Password=poop;Database=oxfam;"); //Connection string for the Npgsql connecton adapter this needs to be moved to an external source.

        public void OpenConn() //A method to handle the connection to the database including error logging.
        {
            try
            {
                conn.Open(); //Opens the connection.
            }
            catch (Exception Error)
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
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString()); //Displays any errors that prevented the connection from closing typically the connection already being closed.

            }
        }


        #endregion






        private void Viewer_Initialized(object sender, EventArgs e)
        {
          try
            {
                this.OpenConn();
                //sql statement
                string sql = "SELECT * FROM giftaid";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgGiftaid.ItemsSource = dt.DefaultView;
                this.CloseConn();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
                this.CloseConn();
            }
        }

        private void dgGiftaid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string sql = "";

            if (e.Key == Key.Return)  
            {
                try
                {
                    this.OpenConn();
                    //sql statement
                    if (tbSearch.Text != "")
                    {
                        sql = "SELECT * FROM giftaid WHERE item_id LIKE '" + tbSearch.Text.ToString() + "'";
                    }
                    else
                    {
                        sql = "SELECT * FROM giftaid";
                    }
                    
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    dgGiftaid.ItemsSource = dt.DefaultView;
                    this.CloseConn();
                }
                catch(Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    this.CloseConn();
                }
            }
        }
    }
}
