using System.Threading.Tasks;

namespace Tehtava1
{
    public interface ICityBikeDataFetcher
    {
         Task<int> GetBikeCountInStation(string stationName);
    }
}