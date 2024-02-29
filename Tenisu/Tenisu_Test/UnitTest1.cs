using Tenisu;
using Tenisu.Players;

namespace Tenisu_Tests
{
    public class UnitTest1
    {
        List<Player> playerList = new List<Player>()
        {
            new Player(1, "Adrien", "Mollat", "Amollat", "Male", new Country("flag.png", "FR"), "photo.png", new Data(1, 100000, 65000, 179, 24, [1, 0, 0, 1, 1])),
            new Player(2, "Rafael", "Garcia", "Raph", "Male", new Country("flag.png", "ESP"), "photo.png", new Data(3, 80220, 67000, 175, 26, [1, 1, 0, 0, 0])),
            new Player(3, "Hugo", "Dupont", "Go", "Male", new Country("flag.png", "SUI"), "photo.png", new Data(11, 32410, 84000, 181, 28, [1, 1, 1, 0, 0])),
            new Player(4, "Samy", "Rehim", "Sam", "Male", new Country("flag.png", "USA"), "photo.png", new Data(32, 10410, 68000, 164, 23, [1, 0, 0, 0, 0])),
            new Player(5, "Julie", "Dubois", "Juju", "Female", new Country("flag.png", "FR"), "photo.png", new Data(24, 20110, 84000, 170, 28, [1, 1, 0, 0, 0]))
        };


        [Fact]
        public void TestbestCountry()
        {
            Country bestCountry = PlayersMethods.GetBestCountry(playerList);

            Assert.Equal("FR", bestCountry.code);
        }


        [Fact]
        public void TestAverageIMC()
        {
            double averageIMC = PlayersMethods.GetAverageIMC(playerList);

            Assert.Equal(24.4, averageIMC);
        }


        [Fact]
        public void TestHeightMedian()
        {
            int heightMedian = PlayersMethods.GetHeightMedian(playerList);

            Assert.Equal(175, heightMedian);
        }
    }
}


