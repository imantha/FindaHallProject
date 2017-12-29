using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindaHall.Models;
using Microsoft.AspNetCore.Mvc;
using FindaHall.Api_Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FindaHall.Controllers
{
    
    public class MapController : Controller
    {
        int userky = 1;
        ApiOperation dbOpr;
        IConfiguration _iconfiguration;
        public MapController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            string url = _iconfiguration.GetSection("APIConnectionStrings").GetSection("URI").Value;
            dbOpr = new ApiOperation(url);

        }

        public IActionResult Index(string txtname)
        {
            double latitude = 0, longitude = 0;
            string[] addressarr = txtname.Split(',');
            string city = "";
            string street = "";
            string hallnm = "%";
            if (addressarr.Length >= 3)
            {
                hallnm = addressarr[0];
                city = addressarr[1];
                street = addressarr[2];
            }
            else if(addressarr.Length >=2){
                city = addressarr[0];
                street = addressarr[1];
            }
            List<HallDetails> hall = dbOpr.GetSelectedHAllDetails(userky, city.Trim(), street.Trim(), hallnm.Trim());
            List<MapLocation> mapLoclist = new List<MapLocation>();
            foreach (HallDetails item in hall)
            {                
                latitude = Double.Parse(item.latitude);
                longitude = Double.Parse(item.longitude);
                MapLocation mapLoc = new MapLocation
                {
                    H_ID = item.H_ID,
                    Name = item.Hall_Name,
                    latitude = latitude,
                    longitude = longitude,
                    City = city.Trim(),
                    Street = street.Trim(),
                    Country = "Australia",
                    Price = int.Parse(item.Price)
                };
                mapLoclist.Add(mapLoc);

            }
            return View(mapLoclist);
        }
      
    }
}