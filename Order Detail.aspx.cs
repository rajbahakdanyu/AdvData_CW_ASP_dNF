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
    public partial class Order_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(ddlName.SelectedValue.ToString());

            String queryString = @"SELECT 
                                    ord.date_time, dh.dish, od.order_unit, rd.price, r.restaurant, d.longitude, d.latitude, d.description
                                    FROM orders ord
                                    JOIN orderdetail od on od.order_no = ord.order_no
                                    JOIN restaurantdish rd on rd.restaurant_dish_id = od.restaurant_dish_id
                                    JOIN dish dh on dh.dish_id = rd.dish_id
                                    JOIN restaurant r on r.restaurant_id = rd.restaurant_id
                                    JOIN delivery d on d.delivery_id = ord.delivery_id
                                    WHERE ord.customer_id = " + id;

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