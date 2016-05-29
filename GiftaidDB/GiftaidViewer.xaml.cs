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
using PostgreSQL_Connection;


namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for GiftaidViewer.xaml
    /// </summary>
    public partial class GiftaidViewer : Window
    {
        Connection giftaidConnection = new Connection();
        NpgsqlConnection conn;

        public GiftaidViewer()
        {
            InitializeComponent();
        }
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
       

        private void Viewer_Initialized(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(giftaidConnection.CreateConnString("Connection.xml"));
            try
            {
                giftaidConnection.OpenConn(conn);
                //sql statement
                string sql = "SELECT * FROM giftaid";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgGiftaid.ItemsSource = dt.DefaultView;
                giftaidConnection.CloseConn(conn);
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
                giftaidConnection.CloseConn(conn);
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
                    giftaidConnection.OpenConn(conn);
                    //sql statement
                    if (tbSearch.Text != "")
                    {
                        sql = "SELECT * FROM giftaid WHERE item_id ILIKE '%" + tbSearch.Text.ToString() + "%'";


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
                    giftaidConnection.CloseConn(conn);
                }
                catch(Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    giftaidConnection.CloseConn(conn);
                }
            }
        }
    }
}
