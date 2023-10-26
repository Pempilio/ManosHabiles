using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManosHabilesProf
{
    public partial class misAnuncios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load and display the list of advertisements in GridView.
                BindAdvertisementData();
            }
        }

        protected void BindAdvertisementData()
        {
            // Assuming you have a valid database connection (con), retrieve the advertisements
            // associated with the logged-in user and bind them to the GridView.
            int userId = GetLoggedInUserId(); // Replace with logic to get user ID
            using (SqlConnection connection = new SqlConnection("your_connection_string"))
            {
                connection.Open();
                string query = "SELECT cAnuncio, descripcion FROM Anuncio WHERE cCliente = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the selected advertisement's description in Label1
            Label1.Text = GridView1.SelectedRow.Cells[2].Text; // Assuming description is in the third cell
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Implement logic to delete the selected advertisement.
            int selectedAdvertisementId = int.Parse(GridView1.SelectedRow.Cells[1].Text);
            if (DeleteAdvertisement(selectedAdvertisementId))
            {
                // Show a success message in Label2
                Label2.Text = "Advertisement deleted successfully.";
                // Refresh the GridView after deletion
                BindAdvertisementData();
                // Clear Label1 after deletion
                Label1.Text = string.Empty;
            }
            else
            {
                Label2.Text = "An error occurred while deleting the advertisement.";
            }
        }

        private int GetLoggedInUserId()
        {
            // Replace with your logic to get the logged-in user's ID
            // You might use a session variable or any other authentication method.
            return 123; // Replace with the actual user ID.
        }

        private bool DeleteAdvertisement(int advertisementId)
        {
            // Implement logic to delete the selected advertisement from the database.
            // Return true if the deletion is successful; otherwise, return false.
            // This would typically involve an SQL DELETE statement.
            try
            {
                using (SqlConnection connection = new SqlConnection("your_connection_string"))
                {
                    connection.Open();
                    string query = "DELETE FROM Anuncio WHERE cAnuncio = @AdvertisementId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AdvertisementId", advertisementId);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}