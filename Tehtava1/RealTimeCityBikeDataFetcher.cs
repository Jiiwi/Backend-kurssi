using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tehtava1 {
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher {
        static HttpClient client = new HttpClient ();
        public async Task<int> GetBikeCountInStation (string stationName) {

            try {
                
                foreach(var character in stationName.ToCharArray()){
                    if(Char.IsDigit(character)){
                        throw new ArgumentException();
                    }
                }

                HttpResponseMessage message = await client.GetAsync ("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");

                string messageText = System.Text.Encoding.UTF8.GetString (message.Content.ReadAsByteArrayAsync ().Result);

                BikeRentalStationList stationList = (BikeRentalStationList) JsonConvert.DeserializeObject<BikeRentalStationList> (messageText);

                int bikes = 0;
                bool found = false;

                foreach (var station in stationList.stations) {
                    if (station.name == stationName) {
                        bikes = station.bikesAvailable;
                        found = true;
                        break;
                    }
                }

                if (!found) {
                    throw new NotFoundException ();
                }

                return bikes;

            } catch (ArgumentException ex) {
                Console.WriteLine ("Invalid argumet: " + ex.Message);
                return 0;
            } catch (NotFoundException ex) {
                Console.WriteLine (ex.Message);
                return 0;
            }
        }
    }
}