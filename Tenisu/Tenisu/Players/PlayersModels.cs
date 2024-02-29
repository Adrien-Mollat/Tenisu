namespace Tenisu
{
    public class PlayerList
    {
        public List<Player> players { get; set; }
    }

    public class Player
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string shortname { get; set; }
        public string sex { get; set; }
        public Country country { get; set; }
        public string picture { get; set; }
        public Data data { get; set; }

        public Player(int id, string firstname, string lastname, string shortname, string sex, Country country, string picture, Data data)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.shortname = shortname;
            this.sex = sex;
            this.country = country;
            this.picture = picture;
            this.data = data;
        }
    }

    public class Country
    {
        public string picture { get; set; }
        public string code { get; set; }

        public Country(string picture, string code)
        {
            this.picture = picture;
            this.code = code;
        }
    }

    public class Data
    {
        public int rank { get; set; }
        public int points { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public int age { get; set; }
        public int[] last { get; set; }

        public Data(int rank, int points, int weight, int height, int age, int[] last)
        {
            this.rank = rank;
            this.points = points;
            this.weight = weight;
            this.height = height;
            this.age = age;
            this.last = last;
        }
    }

    public class GeneralInfos
    {
        public Country bestRatioCountry { get; set; }
        public double averageIMC { get; set; }
        public int heightMedian { get; set; }

        public GeneralInfos(Country bestRatioCountry, double averageIMC, int heightMedian)
        {
            this.bestRatioCountry = bestRatioCountry;
            this.averageIMC = averageIMC;
            this.heightMedian = heightMedian;
        }
    }
}
