using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace Buscador
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvResults.PageSize = 10;
                CargarDatos();
            }
        }

        private readonly string con = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("ListarUsuarios", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                connection.Open();
                adapter.Fill(datatable);
                connection.Close();

                gvResults.DataSource = datatable;
                gvResults.DataBind();

                if (datatable.Rows.Count == 0)
                {
                    lblNoResult.Visible = true;
                    gvResults.Visible = false;
                }
                else
                {
                    lblNoResult.Visible = false;
                    gvResults.Visible = true;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscar=txtTerminoBusqueda.Text.Trim();

            using(SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("BuscarUsuarios", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TerminoBusqueda", buscar);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();

                connection.Open();
                adapter.Fill(datatable);
                connection.Close();

                gvResults.DataSource = datatable;
                gvResults.DataBind();

                if (datatable.Rows.Count == 0)
                {
                    lblNoResult.Visible = true;
                    gvResults.Visible = false;
                }
                else
                {
                    lblNoResult.Visible = false;
                    gvResults.Visible = true;
                }
            }
        }

        protected void gvResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResults.PageIndex = e.NewPageIndex;
            CargarDatos();
        }
    }
}