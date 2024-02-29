using Newtonsoft.Json;
using System.Diagnostics;

namespace Tenisu.Players
{
    public static class PlayersMethods
    {
        internal static List<Player> GetPlayersData()
        {
            List<Player> playersData = new List<Player>();

            string url = "https://data.latelier.co/training/tennis_stats/headtohead.json";
            
            string jsonString = string.Empty;

            try
            {
                HttpClient request = new HttpClient();
                request.BaseAddress = new Uri(url);
                HttpResponseMessage response = request.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    jsonString = result.ToString();
                    var jsonPlayers = JsonConvert.DeserializeObject<PlayerList>(jsonString);
                    if (jsonPlayers != null)
                    {
                        playersData = jsonPlayers.players;
                    }
                }
            }
            catch (Exception ex)
            {
                jsonString = "Error Occured at the API Endpoint. Error: " + ex.Message;
                Debug.WriteLine(jsonString);
            }

            return playersData;
        }

        internal static IResult GetPlayerSortedByRank()
        {
            List<Player> playerList = GetPlayersData();
            var players = playerList.OrderBy(x => x.data.rank);

            if (players != null)
            {
                return Results.Ok(players);
            }
            return Results.NotFound();
        }

        internal static IResult GetPlayerById(int id)
        {

            List<Player> playerList = GetPlayersData();
            var player = playerList.Find(x => x.id == id);

            if (player != null) {
                return Results.Ok(player);
            }
            return Results.NotFound();
        }

        public static Country GetBestCountry(List<Player> playerList)
        {
            Dictionary<Country, int> countryPoints = new Dictionary<Country, int>();
            try
            {
                foreach (Player player in playerList)
                {
                    if (countryPoints.ContainsKey(player.country))
                    {
                        countryPoints[player.country] += player.data.points;
                    }
                    else
                    {
                        countryPoints.Add(player.country, player.data.points);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return countryPoints.MaxBy(kvp => kvp.Value).Key;
        }

        public static double GetAverageIMC(List<Player> playerList)
        {
            double averageweight = 0;
            double averageheight = 0;
            double averageImc = 0;

            try
            {
                foreach (Player player in playerList)
                {
                    averageweight += player.data.weight;
                    averageheight += player.data.height;
                }
                averageweight = (averageweight/1000) / playerList.Count;
                averageheight = (averageheight / 100) / playerList.Count;
                averageImc = Math.Round(averageweight / Math.Pow(averageheight, 2), 1);
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return averageImc;
        }

        public static int GetHeightMedian(List<Player> playerList)
        {
            List<int> heightList = new List<int>();

            try
            {
                heightList = playerList.Select(x => x.data.height).ToList();
                heightList.Sort();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            int midIndex = heightList.Count / 2;
            if (heightList.Count % 2 == 0)
            {
                return (heightList[midIndex-1] + heightList[midIndex])/2;
            } else
            {
                return (heightList[midIndex]);
            }

        }

        internal static IResult GetGeneralInfos()
        {
            List<Player> playerList = GetPlayersData();
            
            var bestCountry = GetBestCountry(playerList);
            var averageImc = GetAverageIMC(playerList);
            var heightMedian = GetHeightMedian(playerList);

            GeneralInfos genInfos = new GeneralInfos(bestCountry, averageImc, heightMedian);

            if (bestCountry != null)
            {
                return Results.Ok(genInfos);
            }
            return Results.NotFound();
        }
    }
}
