
using FindaHall.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FindaHall.Api_Operations
{
    public partial class ApiOperation
    {
        internal List<HallDetails> GetHallDetails(int userky)
        {

            HttpResponseMessage response = httpClient.GetAsync("api/GetHallDetails?userky="+userky+"").Result;
            List<HallDetails> hall = new List<HallDetails>();
            if (response.IsSuccessStatusCode)
            {
                string jstr = response.Content.ReadAsStringAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<HallDetails>));
                List<HallDetails> deserializeditems = new List<HallDetails>();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jstr));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializeditems.GetType());
                deserializeditems = ser.ReadObject(ms) as List<HallDetails>;
                hall = deserializeditems;
            }
            return hall;
        }
        internal List<HallDetails> GetSelectedHAllDetails(int userky, string city, string street, string hallnm)
        {
            HttpResponseMessage response = httpClient.GetAsync("api/GetSelectedHAllDetails?userky=" + userky + "&city=" + city + "&street=" + street + "&hall=" + hallnm + "").Result;
            List<HallDetails> hall = new List<HallDetails>();
            if (response.IsSuccessStatusCode)
            {
                string jstr = response.Content.ReadAsStringAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<HallDetails>));
                List<HallDetails> deserializeditems = new List<HallDetails>();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jstr));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializeditems.GetType());
                deserializeditems = ser.ReadObject(ms) as List<HallDetails>;
                hall = deserializeditems;
            }
            return hall;
        }
        internal Availability GetHallAvbDetails(int userky, string hallid)
        {
            HttpResponseMessage response = httpClient.GetAsync("api/GetHallAvbDetails?userky=" + userky + "&hallid=" + hallid + "").Result;
            Availability hall = new Availability();
            if (response.IsSuccessStatusCode)
            {
                string jstr = response.Content.ReadAsStringAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Availability));
                Availability deserializeditems = new Availability();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jstr));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializeditems.GetType());
                deserializeditems = ser.ReadObject(ms) as Availability;
                hall = deserializeditems;
            }
            return hall;
        }

        internal List<BookingDetails> GetHallbookingDates(int userky, string hallid)
        {
            HttpResponseMessage response = httpClient.GetAsync("api/GetHallbookingDates?userky=" + userky + "&hallid=" + hallid + "").Result;
            List<BookingDetails> dates = new List<BookingDetails>();
            if (response.IsSuccessStatusCode)
            {
                string jstr = response.Content.ReadAsStringAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<BookingDetails>));
                List<BookingDetails> deserializeditems = new List<BookingDetails>();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jstr));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializeditems.GetType());
                deserializeditems = ser.ReadObject(ms) as List<BookingDetails>;
                dates = deserializeditems;
            }
            return dates;
        }

    }

}