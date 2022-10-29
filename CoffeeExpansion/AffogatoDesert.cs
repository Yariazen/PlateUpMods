using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeExpansion
{
    //HashSet<Item> MinimumIngredients // *What items are required for this Dish - default: new HashSet<Item>()
    //HashSet<Process> RequiredProcesses // What Processes are required for this Dish - default: new HashSet<Process>()
    //HashSet<Item> BlockProviders // What Item Providers to block from functioning. - default: new HashSet<Item>()
    //HashSet<Dish> PrerequisiteDishes // *What Dishes are required for this Dish - default: new HashSet<Dish>()
    internal class AffogatoDessert : CustomDish
    {
        public override DishType Type => DishType.Dessert;
        public override GameObject IconPrefab => (GameObject)Mod.bundle.LoadAsset("Affogato");
        public override List<Dish.MenuItem> UnlocksMenuItems
        {
            get
            {
                AffogatoBowl affogato = new AffogatoBowl();
                List<Dish.MenuItem> list = new List<Dish.MenuItem>();

                Dish.MenuItem menuItem = new Dish.MenuItem();
                menuItem.DynamicMenuType = DynamicMenuType.Static;
                menuItem.Item = (Item)GDOUtils.GetExistingGDO(affogato.ID);
                menuItem.Phase = MenuPhase.Dessert;
                menuItem.Weight = 1;

                list.Add(menuItem);
                return list;
            }
        }
        public override HashSet<Item> MinimumIngredients
        {
            get
            {
                HashSet<Item> list = new HashSet<Item>();

                ItemGroup iceCream = (ItemGroup)GDOUtils.GetExistingGDO(Mod.IceCreamGroupID);
                

                return list;
            }
        }
    }
}
