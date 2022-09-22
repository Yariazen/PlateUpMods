using KitchenData;
using YariazenCore.Framework;
using YariazenCore.Framework.Events;

namespace CoffeeExpansion
{
    public class Mod : YariazenMod
    {
        private GameData gamedata;
        private bool test = false;

        public Mod() : base("Yariazen.CoffeeExpansion", ">=1.0.0", new[] { "Yariazen.YariazenCore" })
        {
            YariazenEvents.GameDataConstructor += OnGameDataConstructor;
        }

        private void OnGameDataConstructor(object sender, GameDataConstructorEventArgs e)
        {
            gamedata = e.gamedata;
        }
    }
}
