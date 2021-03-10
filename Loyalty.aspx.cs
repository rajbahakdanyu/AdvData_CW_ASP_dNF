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
    public partial class Loyalty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                calEnd.Visible = false;
                calStart.Visible = false;
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
            cmd.CommandText = "SELECT * FROM Loyalty";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("loyalty");
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
            txtId.Text = txtPoints.Text = txtStart.Text = txtEnd.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtId.Text);
            int points = Int32.Parse(txtPoints.Text);
            String start = txtStart.Text.ToString();
            String end = txtEnd.Text.ToString();

            String queryString = $"INSERT INTO loyalty (loyalty_id, loyalty_points, start_date, end_date) VALUES ({id} , {points}, TO_DATE('{start}', 'dd/mm/yyyy'), TO_DATE('{end}', 'dd/mm/yyyy'))";

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
            int points = Convert.ToInt32((row.Cells[2].Controls[0] as TextBox).Text);
            String start = (row.Cells[3].Controls[0] as TextBox).Text;
            String end = (row.Cells[4].Controls[0] as TextBox).Text;

            string queryString = $"UPDATE loyalty SET loyalty_points = {points}, start_date = TO_DATE('{start}', 'dd/mm/yyyy HH:MI:SS AM'), end_date = TO_DATE('{end}', 'dd/mm/yyyy HH:MI:SS AM') WHERE loyalty_id = {id}";

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

            string queryString = $"DELETE FROM loyalty WHERE loyalty_id = {id}";

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

        protected void btnStart_Click(object sender, ImageClickEventArgs e)
        {
            if (calStart.Visible)
            {
                calStart.Visible = false;
            }
            else
            {
                calStart.Visible = true;
            }
        }

        protected void btnEnd_Click(object sender, ImageClickEventArgs e)
        {
            if (calEnd.Visible)
            {
                calEnd.Visible = false;
            }
            else
            {
                calEnd.Visible = true;
            }
        }

        protected void calEnd_SelectionChanged(object sender, EventArgs e)
        {
            txtEnd.Text = calEnd.SelectedDate.ToString("dd/MM/yyyy");
            calEnd.Visible = false;
        }

        protected void calStart_SelectionChanged(object sender, EventArgs e)
        {
            txtStart.Text = calStart.SelectedDate.ToString("dd/MM/yyyy");
            calStart.Visible = false;
        }

        protected void calStart_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void calEnd_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}