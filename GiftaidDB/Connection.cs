﻿using System;
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
        

    }
}