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
using PostgreSQL_Connection;
using Npgsql;
using System.Data;

namespace GiftaidDB
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Connection giftaidConnection = new Connection();
        NpgsqlConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(giftaidConnection.CreateConnString("Connection.xml"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUserName.MaxLength = 20;
            tbPassword.MaxLength = 20;
            
        }

        private void tbUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbUserName.Text == "" || tbPassword.Password == "")
            {
                MessageBox.Show("Please provide UserName and Password","Login Window",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            try
            {
                giftaidConnection.OpenConn(conn);
                string sql = "SELECT * FROM login WHERE UserName='" + tbUserName.Text + "' and Password='" + tbPassword.Password + "' ";
                
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                ds.Reset();
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                giftaidConnection.CloseConn(conn);
                if (count == 1)
                {
                    MessageBox.Show("Login Successful", "Login Window", MessageBoxButton.OK, MessageBoxImage.None);
                    string sql2 = "UPDATE login SET last_login='now' WHERE ID='" + ds.Tables[0].Rows[0][0] + "'";
                    giftaidConnection.NonQuery(conn,Convert.ToInt32(ds.Tables[0].Rows[0][0]), sql2);
                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed :(", "Login Window", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.ToString());
                giftaidConnection.CloseConn(conn);
            }
           

        }
    }

}
