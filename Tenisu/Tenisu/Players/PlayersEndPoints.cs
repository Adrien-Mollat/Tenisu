namespace Tenisu.Players
{
    internal static class PlayersEndPoints
    {
        internal static void AddPlayersEndPoints(this WebApplication app)
        {
            app.MapGet("/playersbyrank", () => PlayersMethods.GetPlayerSortedByRank());

            app.MapGet("/players/{id:int}", (int id) => PlayersMethods.GetPlayerById(id));

            app.MapGet("/generalinfos", () => PlayersMethods.GetGeneralInfos());
        }
    }
}
