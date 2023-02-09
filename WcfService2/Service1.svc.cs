using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string constr = ConfigurationManager.ConnectionStrings["pt_edi_test"].ConnectionString;

        /// <summary>
        /// Mendapatkan data user
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public String GetDataUser(int userid)
        {
            string json = "";
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("getDataUser", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", userid);

                        using (MySqlDataAdapter sa = new MySqlDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sa.Fill(dt);

                            json = JsonConvert.SerializeObject(dt);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                json =  ex.ToString();
            }
            

            return json;
        }

        /// <summary>
        /// Insert Data User baru
        /// </summary>
        /// <param name="user_data"></param>
        /// <returns></returns>
        public string SetDataUser(DataUser user_data)
        {
            string json = "";
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("setDataUser", con))
                    {
                        //DataUser user = new DataUser();

                        //user = JsonConvert.DeserializeObject<DataUser>(user_data);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", user_data.userid);
                        cmd.Parameters.AddWithValue("@namalengkap", user_data.namalengkap);
                        cmd.Parameters.AddWithValue("@username", user_data.username);
                        cmd.Parameters.AddWithValue("@password", user_data.password);
                        cmd.Parameters.AddWithValue("@status", user_data.status);

                        using (MySqlDataAdapter sa = new MySqlDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sa.Fill(dt);

                            json = JsonConvert.SerializeObject(dt);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                json = ex.ToString();
            }


            return json;
        }

        /// <summary>
        /// Menghapus data user
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string DelDataUser(int userid)
        {
            string json = "";
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("delDataUser", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", userid);

                        using (MySqlDataAdapter sa = new MySqlDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sa.Fill(dt);

                            json = JsonConvert.SerializeObject(dt);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                json = ex.ToString();
            }


            return json;
        }

    }
}
