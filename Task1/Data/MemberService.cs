using Microsoft.Data.SqlClient;
using System.Data;


namespace Task1.Data
{
    public class MemberService 
    {
		private string connectionString = "Data Source=DESKTOP-QTRRLJQ\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;Encrypt=False;User ID=xyz;pwd=top$secret";
		public List<Member> GetMembers()
		{
			List<Member> members = new List<Member>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("select * from members",connection);
				SqlCommand cmd = new SqlCommand("SP_GetMembers", connection);
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Member member = new Member();
					member.MemberId= sdr.GetInt32(0);
					member.FirstName = sdr.GetString(1);
					member.LastName = sdr.GetString(2);
					member.ContactNo = sdr.GetInt32(3);
					members.Add(member);
				}
				connection.Close();
			}
			return members;
		}
		public bool InsertMember(Member member)
		{
			bool r = false;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("insert into Members(Fname,Lname,Phone)values('"+member.Fname+"','"+member.Lname+"','"+member.Phone+"')",connection);
				SqlCommand cmd = new SqlCommand("SP_InsertMember", connection);
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mFirstName",
					SqlDbType = SqlDbType.VarChar,
					Value = member.FirstName,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mLastName",
					SqlDbType = SqlDbType.VarChar,
					Value = member.LastName,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mContactNo",
					SqlDbType = SqlDbType.Int,
					Value = member.ContactNo,
					Direction = ParameterDirection.Input,
				});
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				int res = cmd.ExecuteNonQuery();
				if (res > 0)
				{
					r = true;
				}
				connection.Close();
			}
			return r;
		}
		public bool UpdateMember(Member member)
		{
			bool r = false;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("insert into Members(Fname,Lname,Phone)values('"+member.Fname+"','"+member.Lname+"','"+member.Phone+"')",connection);
				SqlCommand cmd = new SqlCommand("SP_UpdateMember", connection);
				cmd.Parameters.Add( new SqlParameter
				{
					ParameterName = "@mFirstName",
					SqlDbType = SqlDbType.VarChar,
					Value = member.FirstName,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mLastName",
					SqlDbType = SqlDbType.VarChar,
					Value = member.LastName,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mId",
					SqlDbType = SqlDbType.Int,
					Value = member.MemberId,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mContactNo",
					SqlDbType = SqlDbType.Int,
					Value = member.ContactNo,
					Direction = ParameterDirection.Input,
				});
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				int res = cmd.ExecuteNonQuery();
				if (res > 0)
				{
					r = true;
				}
				connection.Close();
			}
			return r;
		}

		public bool DeleteMember(Member member)
		{
			bool r = false;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("insert into Members(Fname,Lname,Phone)values('"+member.Fname+"','"+member.Lname+"','"+member.Phone+"')",connection);
				SqlCommand cmd = new SqlCommand("SP_DeleteMember", connection);

				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@mId",
					SqlDbType = SqlDbType.Int,
					Value = member.MemberId,
					Direction = ParameterDirection.Input,
				});

				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				int res = cmd.ExecuteNonQuery();
				if (res > 0)
				{
					r = true;
				}
				connection.Close();
			}
			return r;
		}
	}
}

