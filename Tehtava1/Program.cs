using System;
using System.Threading.Tasks;

namespace Tehtava1 {
    class Program {
        static void Main (string[] args) {
            bool realtime = true; 

            if(args.Length >= 2){
                if(args[1] == "realtime"){
                    realtime = true;
                } else if (args[1] == "offline"){
                    realtime = false;
            }   
            } else if (args.Length == 0){
                return;
            }

            Console.WriteLine(args[0]);


            string input = args[0];

            ICityBikeDataFetcher fetcher;

            if(realtime){
                fetcher = new RealTimeCityBikeDataFetcher();
            } else {
                fetcher = new OfflineCityBikeDataFetcher();
            }

            var task = fetcher.GetBikeCountInStation (input);

            task.Wait ();

            int count = task.Result;

            Console.WriteLine ("Bikes available: " + count.ToString ());

        }
    }
}