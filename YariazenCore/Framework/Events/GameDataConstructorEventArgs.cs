using KitchenData;
using System;

namespace YariazenCore.Framework.Events
{
    public class GameDataConstructorEventArgs : EventArgs
    {
        readonly GameData gamedata;
        internal GameDataConstructorEventArgs(GameData gamedata) 
        {
            this.gamedata = gamedata;
        }
    }
}
