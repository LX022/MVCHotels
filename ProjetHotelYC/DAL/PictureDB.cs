using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class PictureDB
    {
        public static List<Picture> GetPictures(int IdRoom)
        {
            List<Picture> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Picture WHERE IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Picture>();

                            Picture picture = new Picture();

                            picture.IdPicture = (int)dr["IdPicture"];
                            picture.Url = (string)dr["Url"];
                            picture.IdRoom = (int)dr["IdRoom"];
                            
                            results.Add(picture);
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return results;
        }
    }
}
