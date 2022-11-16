using Microsoft.Data.SqlClient;
using System.Data;

namespace Task1.Data
{
	public class VideoService
	{
		private string connectionString = "Data Source=DESKTOP-QTRRLJQ\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;Encrypt=False;User ID=xyz;pwd=top$secret";
		public List<Video> GetAllVideos()
		{
			List<Video> videos = new List<Video>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("SP_GetVideos", connection);
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Video video = new Video();
					video.VideoId = sdr.GetInt32(0);
					video.Title = sdr.GetString(1);
					video.BId = sdr.GetInt32(2);
					videos.Add(video);
				}
				connection.Close();
			}
			return videos;
		}
	}
}
