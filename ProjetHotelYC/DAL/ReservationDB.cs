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
    /*
    public class ReservationDB
    {
        public static Reservation GetReservation(int IdReservation)
        {
            Reservation reservation = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Reservation where IdReservation = @IdReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdReservation", IdReservation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            reservation = new Reservation();

                            reservation.IdReservation = (int)dr["IdReservation"];
                            reservation.DateStart = (DateTime)dr["DateStart"];
                            reservation.DateEnd = (DateTime)dr["DateEnd"];
                            reservation.Name = (string)dr["Name"];
                            reservation.FirstName = (string)dr["FirstName"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return reservation;
        }
        public static List<Reservation> GetAllReservations()
        {
            List<Reservation> results = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Reservation>();

                            Reservation reservation = new Reservation();

                            reservation.IdReservation = (int)dr["IdReservation"];
                            reservation.DateStart = (DateTime)dr["DateStart"];
                            reservation.DateEnd = (DateTime)dr["DateEnd"];
                            reservation.Name = (string)dr["Name"];
                            reservation.FirstName = (string)dr["FirstName"];

                            results.Add(reservation);
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

        public static int AddReservation(DateTime DateStart, DateTime DateEnd, string Name, string FirstName)
        {
            int result = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Reservation(DateStart, DateEnd, Name, FirstName) values(@DateStart, @DateEnd, @Name, @FirstName); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DateStart", DateStart);
                    cmd.Parameters.AddWithValue("@DateEnd", DateEnd);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);

                    cn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static int  DeleteReservation(int IdReservation)
        {
            int result = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseDataAccess"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Reservation where IdReservation = @IdReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdReservation", IdReservation);

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
