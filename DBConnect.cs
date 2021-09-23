using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Data;

namespace Student_Record
{
    class DBConnect
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        public static bool IsInternetAvailable()
        {
            try
            {
                int description;
                return InternetGetConnectedState(out description, 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private MySqlConnection connection;
        private MySqlConnection NoDBconnection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public static DataSet DS = new DataSet();

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = EncDec.ToInsecureString(EncDec.DecryptString(Properties.Settings.Default.serverIP));
            database = Properties.Settings.Default.databaseName;
            uid = EncDec.ToInsecureString(EncDec.DecryptString(Properties.Settings.Default.serverUID));
            password = EncDec.ToInsecureString(EncDec.DecryptString(Properties.Settings.Default.ServerPSW));
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";SslMode=none;convert zero datetime=True";
            string NoDBconnectionString= "SERVER=" + server + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";SslMode=none;convert zero datetime=True";
            connection = new MySqlConnection(connectionString);
            NoDBconnection = new MySqlConnection(NoDBconnectionString);
        }

        private bool OpenConnection()
        {
            if (IsInternetAvailable())
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show(ex.Message);
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                        default:
                            MessageBox.Show(ex.Message);
                            break;
                    }
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Connection Failed! Check Your Internet Connectivity.");
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(String Q)
        {
            
            if (this.OpenConnection() == true)
            {
                
                MySqlCommand cmd = new MySqlCommand(Q,connection);


                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        public void Update(String Q)
        {

            if (this.OpenConnection() == true)
            {
                
                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = Q,
                    
                    Connection = connection
                };

                try
                {
                    cmd.ExecuteNonQuery();
                }

                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                this.CloseConnection();
            }
        }

        public void Delete(String Q)
        {

            if (this.OpenConnection() == true)
            {
                
                MySqlCommand cmd = new MySqlCommand(Q, connection);


                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        public void FillDataSet(String Q1, String Q2)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Q1, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(DS, Q2);
                this.CloseConnection();
            }
        }

        public List<string>[] Select(string Q, Int16 column)
        {

            string query = Q;

            List<string>[] list = new List<string>[column];
            for (int i = 0; i < column; i++)
                list[i] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    for (int i = 0; i < column; i++)

                        list[i].Add(dataReader[i] + "");

                }

                dataReader.Close();

                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        public void backup(String s)
        {
            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);
                cmd.Connection = connection;
                try
                {
                    mb.ExportToFile(s);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
            
        }

        public void restore(String s)
        {
            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);
                cmd.Connection = connection;
                try
                {
                    mb.ImportFromFile(s);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        public void createdb(String Q)
        {
            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(Q, NoDBconnection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   