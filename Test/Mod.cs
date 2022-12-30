using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace PlateUpModding
{
    public class SetEverythingOnFire : GenericSystemBase, IModSystem
    {
        private EntityQuery Appliances;

        public struct STestSingleton : IModComponent
        {
            public FixedString64 str;
        }

        protected override void Initialise()
        {
            base.Initialise();
            Appliances = GetEntityQuery(new QueryHelper()
                    .All(typeof(CAppliance))
                    .None(
                        typeof(CFire),
                        typeof(CIsOnFire),
                        typeof(CFireImmune),
                        typeof(STestSingleton)
                    ));
        }

        protected override void OnUpdate()
        {
            var appliances = Appliances.ToEntityArray(Allocator.TempJob);
            foreach (var appliance in appliances)
            {
                EntityManager.AddComponent<CIsOnFire>(appliance);
                EntityManager.AddComponent<STestSingleton>(appliance);
            }
            appliances.Dispose();
        }
    }
}
