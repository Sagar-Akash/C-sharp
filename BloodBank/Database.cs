using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BloodBank
{
    class Database
    {
        MySqlConnection MyConn2 = new MySqlConnection("datasource=localhost;username=root;database=bloodbank;password=");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet();
        public static void register(string Name, string BloodGroup,string Location,string Age,string Phone,string Email,string Password, string tableName)
        {
                try
                {
                    string connectionString = "datasource = localhost; username = root; password=; database = bloodbank";
                    string query = "insert into "+tableName+"(`Name`, `BloodGroup`, `Location`, `Age`, `Phone`, `Email`, `Password`) " +
                    "values('" + Name + "','" + BloodGroup + "','" + Location + "','" + Age + "','" + Phone + "','" + Email + "','" + Password + "');";
                    MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                    MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                    MySqlDataReader mySqlDataReader;
                    mySqlConnection.Open();
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    MessageBox.Show("Sucessfully Registered!!");
                    mySqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        /*public  String Login(String phone, String password, String table)
        {
            try
            {
                ds = new DataSet();
                adapter = new MySqlDataAdapter("select * from `" + table + "` where Phone ='" + phone + "' and Password ='" + password + "';", MyConn2);
                adapter.Fill(ds, table);
                if (ds.Tables[table].Rows.Count > 0)
                {
                    string name = "";
                    // return ds.Tables[table].Rows[0].;
                    foreach (DataRow dr in ds.Tables[table].Rows)
                    {
                        name = dr["id"].ToString();
                    }
                    MyConn2.Close();
                    return name;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        */

        public static string[] login(string tableName, string phone, string password)
        {
            int id;
            string name,mobile;
            string[] data = new string[3];
            try
            {
                string connection = "datasource=localhost;username=root;password=; database=bloodbank";
                MySqlConnection con = new MySqlConnection(connection);
                MySqlCommand command = con.CreateCommand();
                command.CommandText = String.Format("SELECT * FROM {0} WHERE Phone=@phone and Password=@password", tableName);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@password", password);
                con.Open();
                var dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    id = Convert.ToInt32(dr.GetString(0));
                    name = dr.GetString(1);
                    mobile = dr.GetString(5);
                    data[0] = id.ToString();
                    data[1] = name;
                    data[2] = mobile;
                    
                    MessageBox.Show("Login Successfull\n " + name);
                }
                else
                {
                    //label4.Visible = true;
                    MessageBox.Show("wrong Username/password inside \n ");
                }
                dr.Close();
                con.Close();
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

       public static DataTable search(string bg, string area)
        {
            string Query="";
            if(bg !="" && area !="")
            {
                Query = "SELECT Name,BloodGroup,Location,Age,Phone,Email,Lattitude,Longitude FROM `donordata` WHERE((Location = '" + area + "'and BloodGroup = '" + bg + "')and Phone in (SELECT Phone from donorstatus where donorstatus.Status like 'on due'))";
            }
            else if(bg !="" && area == "")
            {
                Query = "SELECT Name,BloodGroup,Location,Age,Phone,Email,Lattitude,Longitude FROM `donordata` WHERE ((BloodGroup='" + bg + "')and Phone in (SELECT Phone from donorstatus where donorstatus.Status like 'on due'))";
            }
            else if(bg == "" && area != "")
            {
                Query = "SELECT Name,BloodGroup,Location,Age,Phone,Email,Lattitude,Longitude FROM `donordata` WHERE ((Location='" + area + "')and Phone in (SELECT Phone from donorstatus where donorstatus.Status like 'on due'))";
            }
            try
            {
                string MyConnection2 = "datasource = localhost; username = root; password=; database = bloodbank";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                MyConn2.Open(); 
                   DataTable dTable = new DataTable();
                  MyAdapter.Fill(dTable);
                MyConn2.Close();
                //  grid.DataSource = dTable;
                //gridview_data();
                 return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
