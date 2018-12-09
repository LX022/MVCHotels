using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Room> Rooms = new List<Room>
        //{
        //    new Room {IdRoom = 10, Number = 1001, Description="a", Type=1, Price=100, HasHairDryer=true, HasTV=false, IdHotel=1}
        //};

            //BLL.ReservationManager.CreatReservation(Rooms, new DateTime(2017, 12, 16), new DateTime(2017, 12, 19), 3, "C", "Y");


            //    //List<int> id = ReservationManager.GetActiveReservations(new DateTime(2017, 12, 19), new DateTime(2017, 12, 20));

            //    //for (int i = 0; i < id.Count; i++)
            //    //{
            //    //    Console.WriteLine(id[i]);
            //    //}

            //    //List<int> busyrooms = LinkRoomReservationManager.GetBusyRooms(id);

            //    DateTime Start = new DateTime(2017, 11, 08);
            //    DateTime End = new DateTime(2017, 12, 12);

            List<Room> rooms = BLL.RoomManager.RoomRecu(23);

            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine(rooms[i].Number);
            }

            //    //for (int i = 0; i < availableRooms.Count; i++)
            //    //{
            //    //    Console.WriteLine(availableRooms[i]);
            //    //}

            //    //DateTime d = new DateTime(2017, 12, 8);
            //    //DateTime e = new DateTime(2017, 12, 12);

            //    //DateTime rd = new DateTime(2017, 12, 08);
            //    //DateTime re = new DateTime(2017, 12, 11);

            //    //int result = 0;

            //    //if ((d >= rd && d < re) || (e > rd && e < re))
            //    //{
            //    //    result = 1;
            //    //}

            //    //Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
