using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Npgsql;
namespace PostgreSQL_Connection
{
   
    class Connection
    {
        
        string server;
        string port;
        string userid;
        string password;
        string database;

        public string CreateConnString(string xml)
        {
            XmlReader connectionXmlReader = XmlReader.Create(xml);

            while(connectionXmlReader.Read())
            {
                if (connectionXmlReader.NodeType == XmlNodeType.Element && connectionXmlReader.Name == "psql")
                {
                   if(connectionXmlReader.HasAttributes)
                    {
                        server = connectionXmlReader.GetAttribute("Server");
                        port = connectionXmlReader.GetAttribute("Port");
                        userid = connectionXmlReader.GetAttribute("UserId");
                        password = connectionXmlReader.GetAttribute("Password");
                        database = connectionXmlReader.GetAttribute("Database");

                    }
                }
            }

            string conn = ("Server=" + server + ";Port=" + port + ";User Id=" + userid + ";Password=" + password + ";Database=" + database + ";");
            return conn;
        }

        public void OpenConn(NpgsqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch(Exception Error)
            {
                throw Error;
            } 
        }

        public void CloseConn(NpgsqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch(Exception Error)
            {
                throw Error;
            }
        }
        
        public void Update(NpgsqlConnection conn,string status,int id) //Update command using id
        {
            try
            {
                OpenConn(conn);
                string sql = "UPDATE giftaid SET status = '" + status + "',last_modified_date = 'now' WHERE ID = " + id + " ";
                NpgsqlCommand updateCommand = new NpgsqlCommand(sql, conn);
                int Success = updateCommand.ExecuteNonQuery();
                if (Success >= 1)
                {
                    MessageBox.Show("Successfully updated row " + id + "", "Update Command Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong :( \n Double check the ID is correct", "Update Command Result", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                CloseConn(conn);
            }
            catch(Exception Error)
            {
                throw Error;
            }
        }

    }
}
