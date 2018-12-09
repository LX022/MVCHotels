using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class RoomDB
    {
        public static List<Room> GetAllRooms()
        {
            List<Room> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Room";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Room>();

                            Room room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];
                            room.Number = (int)dr["Number"];
                            room.Description = (string)dr["Description"];
                            room.Type = (int)dr["Type"];
                            room.Price = (decimal)dr["Price"];
                            room.HasTV = (bool)dr["HasTV"];
                            room.HasHairDryer = (bool)dr["HasHairDryer"];
                            room.IdHotel = (int)dr["IdHotel"];

                            results.Add(room);
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

        public static Room GetRoom(int IdRoom)
        {
            Room room = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Room where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            room = new Room();

                            room.IdRoom = (int)dr["IdRoom"];
                            room.Number = (int)dr["Number"];
                            room.Description = (string)dr["Description"];
                            room.Type = (int)dr["Type"];
                            room.Price = (decimal)dr["Price"];
                            room.HasTV = (bool)dr["HasTV"];
                            room.HasHairDryer = (bool)dr["HasHairDryer"];
                            room.IdHotel = (int)dr["IdHotel"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return room;
        }
    }
}
