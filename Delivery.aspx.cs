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
    public partial class Delivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Delivery";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("delivery");
            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtId.Text = txtLongitude.Text = txtLatitude.Text = txtDescription.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtId.Text);
            int longi = Int32.Parse(txtLongitude.Text);
            int lati = Int32.Parse(txtLatitude.Text);
            String description = txtDescription.Text.ToString();

            String queryString = $"INSERT INTO delivery (delivery_id, longitude, latitude, description) VALUES ({id} , {longi}, {lati}, '{description}')";

            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, conn);
                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                finally
                {
                    conn.Close();
                    Clear();
                }
            }

            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int lati = Convert.ToInt32((row.Cells[2].Controls[0] as TextBox).Text);
            int longi = Convert.ToInt32((row.Cells[3].Controls[0] as TextBox).Text);
            String description = (row.Cells[4].Controls[0] as TextBox).Text;

            string queryString = $"UPDATE delivery SET latitude = {lati}, longitude = {longi}, description = '{description}' WHERE delivery_id = {id}";

            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, conn);
                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string queryString = $"DELETE FROM delivery WHERE delivery_id = {id}";

            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, conn);
                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}