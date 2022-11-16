using Microsoft.Data.SqlClient;
using System.Data;

namespace Task1.Data
{
    public class BorrowDetailsServices
    {
        private string connectionString = "Data Source=DESKTOP-QTRRLJQ\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;Encrypt=False;User ID=xyz;pwd=top$secret";
        public List<BorrowDetails> GetAllBorrowDetails()
        {
            List<BorrowDetails> borrows = new List<BorrowDetails>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBorrowDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    BorrowDetails borrowdetails = new BorrowDetails();
                    borrowdetails.BorrowId = sdr.GetInt32(0);
                    borrowdetails.MemId = sdr.GetInt32(1);
                    borrowdetails.BorrowDate = sdr.GetDateTime(2);
                    borrowdetails.RecieveDate = sdr.GetDateTime(3);
                    borrows.Add(borrowdetails);
                }
                connection.Close();
            }
            return borrows;
        }
    }
}
