using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace PastaPalace.Customs.PastaProcess
{
    internal class PastaWhite : CustomDish
    {
        public override string UniqueNameID => "Pasta -- White Sauce";
        public override DishType Type => DishType.Base;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.PlatedPasta
            }
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Mod.ServedWhiteSauce,
                MenuItem = Mod.PlatedPasta
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Flour,
            Mod.Egg,
            Mod.Cheese,
            Mod.Onion,
            Mod.Water
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop
        };
        public override HashSet<Dish> PrerequisiteDishesEditor => new HashSet<Dish>
        {
            Mod.PastaBase
        };
        public override List<Unlock> HardcodedRequirements => new List<Unlock>
        {
            Mod.PastaBase
        };
    }
}
