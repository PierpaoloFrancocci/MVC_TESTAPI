using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace BusinessLayer
{
    public class CalledAPIBL
    {
        
        string Conn
        { 
            get{return ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;}            
        }
        public IEnumerable<CalledAPI> CalledAPIs
        {
            get
            {
                

                List<CalledAPI> CalledApis =new List<CalledAPI>();

                using (SqlConnection con = new SqlConnection(Conn))
                {
                    SqlCommand cmd=new SqlCommand("usp_GetCalledAPI",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CalledAPI calledAPI = new CalledAPI();
                        calledAPI.ID = Convert.ToInt32(rdr["ID"]);
                        calledAPI.StringIn=rdr["StringIn"].ToString();
                        calledAPI.StringCode = rdr["StringCode"].ToString();
                        calledAPI.KeyCode = rdr["KeyCode"].ToString();
                        calledAPI.dtAgg =Convert.ToDateTime( rdr["dtAgg"].ToString());

                        CalledApis.Add(calledAPI);
                    }
                }
                return CalledApis;
            }
        }
        public void Save(CalledAPI Api)
        {
            using (SqlConnection con = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("usp_CreateCalledAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                SqlParameter paramStringIn = new SqlParameter();
                paramStringIn.ParameterName = "@StringIn";
                paramStringIn.Value = Api.StringIn??"";
                cmd.Parameters.Add(paramStringIn);

                SqlParameter paramStringCode = new SqlParameter();
                paramStringCode.ParameterName = "@StringCode";
                paramStringCode.Value = Api.StringCode??"";
                cmd.Parameters.Add(paramStringCode);

                SqlParameter paramKeyCode = new SqlParameter();
                paramKeyCode.ParameterName = "@KeyCode";
                paramKeyCode.Value = Api.KeyCode??"";
                cmd.Parameters.Add(paramKeyCode);


                con.Open();
                cmd.ExecuteNonQuery();
                
            }

        }
    }
}
