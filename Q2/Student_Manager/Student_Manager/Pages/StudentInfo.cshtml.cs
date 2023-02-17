using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Student_Manager.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            var name = Request.Form["Name"];
            ViewData["username"] = "Hello " + name + " here are your details";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source=DESKTOP-INBQF41;Initial Catalog=Information_Manager;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM Student";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "<br/>";
                
            }

            Response.WriteAsync(Output);

            //ViewData["data"] = Output;

            cnn.Close();
        

}
    }
}