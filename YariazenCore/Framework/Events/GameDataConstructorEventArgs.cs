using KitchenData;
using System;

namespace YariazenCore.Framework.Events
{
    public class GameDataConstructorEventArgs : EventArgs
    {
        public readonly GameData gamedata;
        internal GameDataConstructorEventArgs(GameData gamedata) 
        {
            this.gamedata = gamedata;
        }
    }
}
