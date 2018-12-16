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
    /*
    public class LinkRoomReservationDB
    {
        public static List<LinkRoomReservation> GetAllLinkRoomReservation()
        {
            List<LinkRoomReservation> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM LinkRoomReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<LinkRoomReservation>();

                            LinkRoomReservation linkRoomReservation = new LinkRoomReservation();

                            linkRoomReservation.IdLinkRoomReservation = (int)dr["IdLinkRoomReservation"];
                            linkRoomReservation.PriceRoom = (decimal)dr["PriceRoom"];
                            linkRoomReservation.IdReservation = (int)dr["IdReservation"];
                            linkRoomReservation.IdRoom = (int)dr["IdRoom"];

                            results.Add(linkRoomReservation);
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

        public static int AddLinkRoomReservation(decimal PriceRoom,int IdReservation, int IdRoom)
        {
            int result = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into LinkRoomReservation (PriceRoom, IdReservation, IdRoom) values(@PriceRoom, @IdReservation, @IdRoom)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@PriceRoom", PriceRoom);
                    cmd.Parameters.AddWithValue("@IdReservation", IdReservation);
                    cmd.Parameters.AddWithValue("@IdRoom", IdRoom);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static int DeleteLinkRoomReservation(int IdLinkRoomReservation)
        {
            int result = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from LinkRoomReservation where IdLinkRoomReservation = @IdLinkRoomReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdLinkRoomReservation", IdLinkRoomReservation);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }*/
}
