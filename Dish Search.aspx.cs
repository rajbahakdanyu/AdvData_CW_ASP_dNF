using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvData_CW_ASP_dNF
{
    public partial class Dish_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(ddlName.SelectedValue.ToString());

            String queryString = @"SELECT 
                                    dh.dish, dh.description, r.restaurant, r.address, rd.price, rd.status, l.loyalty_points
                                    FROM dish dh
                                    JOIN restaurantdish rd on rd.dish_id = dh.dish_id
                                    JOIN restaurant r on r.restaurant_id = rd.restaurant_id
                                    JOIN loyalty l on l.loyalty_id = rd.loyalty_id
                                    WHERE dh.dish_id = " + id;

            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = queryString;
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}