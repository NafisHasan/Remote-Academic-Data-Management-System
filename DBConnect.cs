using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
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
            catch (Exception ex)
            {
                return false;
            }
        }
        private MySqlConnection connection;
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
            server = "198.154.99.221";
            database = "GUB";
            uid = "nafis";
            password = "DBanhk1234.";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
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
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
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

        //Close connection
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

        //Insert statement
        public void Insert(String Q)
        {
        //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(Q, connection);

                //Execute command
                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(String Q)
        {

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand
                {
                    //Assign the query using CommandText
                    CommandText = Q,
                    //Assign the connection using Connection
                    Connection = connection
                };

                try
                {
                    //Execute query
                    cmd.ExecuteNonQuery();
                }

                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(String Q)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Q, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void FillDataSet(String Q1,String Q2)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(Q1, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(DS, Q2);
                this.CloseConnection();
            }
        }

        public List<string>[] Select(string Q,Int16 column)
        {

            string query = Q;

            //Create a list to store the result
            List<string>[] list = new List<string>[column];
            for (int i = 0; i < column; i++)
                list[i] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

               
                while (dataReader.Read())
                {
                    for (int i = 0; i < column; i++)

                        list[i].Add(dataReader[i] + "");

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }


    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   