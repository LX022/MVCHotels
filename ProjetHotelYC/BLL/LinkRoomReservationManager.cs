﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Net.Http;
using Newtonsoft.Json;

namespace BLL
{
   public class LinkRoomReservationManager
    {
        static string linkRoomReservationURL = "http://localhost:3749/api/LinkRoomReservations/";

        //Get All LinkRoomReservation API
        public static List<LinkRoomReservation> GetAllLinkRoomReservation()
        {
            List<LinkRoomReservation> linksRoom;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(linkRoomReservationURL);
                linksRoom = JsonConvert.DeserializeObject<List<LinkRoomReservation>>(response.Result);
            }
            return linksRoom;
        }
        //-------------------------------------------------------------------------------------------------
        //écrit dans LinkRoomReservation lors d'un ajout de réservation
        public static Boolean AddLinkRoomReservation(Decimal PriceRoom,int IdReservation, int IdRoom)
        {

            LinkRoomReservation toAdd = new LinkRoomReservation(PriceRoom, IdReservation, IdRoom);

            using (HttpClient httpClient = new HttpClient())
            {
                string serialize = JsonConvert.SerializeObject(toAdd);
                StringContent frame = new StringContent(serialize, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(linkRoomReservationURL, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }
        //-------------------------------------------------------------------------------------------------
        public static void DeleteLinkRoomReservation(int IdLinkRoomReservation)
        {

            string linkRoomReservationurl = linkRoomReservationURL + IdLinkRoomReservation;


            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.DeleteAsync(linkRoomReservationurl).Result;

            }
        }
        //-------------------------------------------------------------------------------------------------
        //Renvoie les ids des chambres occupées selon une liste d'id de réservation
        public static List<int> GetBusyRooms(List<int> IdActiveReservations)
        {
            List<int> IdBusyRooms = new List<int>();
            List<LinkRoomReservation> LinkRoomReservations = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach (LinkRoomReservation lrr in LinkRoomReservations)
            {
                if (IdActiveReservations.Contains(lrr.IdReservation))
                    IdBusyRooms.Add(lrr.IdRoom);
            }

            return IdBusyRooms;
        }

        public static decimal GetPrice(int IdReservation)
        {
            decimal price=0;

            List < LinkRoomReservation > lrr = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach(LinkRoomReservation l in lrr)
            {
                if (l.IdReservation == IdReservation)
                    price = l.PriceRoom;
            }

            return price;
        }

        public static List<int> GetReservationRoomsId(int IdReservation)
        {
            List<int> ListIdRoom = new List<int>();
            List<LinkRoomReservation> AllLrr = BLL.LinkRoomReservationManager.GetAllLinkRoomReservation();

            foreach(LinkRoomReservation lrr in AllLrr)
            {
                if (lrr.IdReservation == IdReservation)
                    ListIdRoom.Add(lrr.IdRoom);
            }

            return ListIdRoom;
        }
    }
}
