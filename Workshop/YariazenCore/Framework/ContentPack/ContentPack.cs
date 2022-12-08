using KitchenLib.Customs;
using System.Collections.Generic;
using YariazenCore.Framework.Model;
using YariazenCore.Framework.Model.JsonModels;

namespace YariazenCore.Framework.ContentPack
{
    internal class ContentPack
    {
        Manifest manifest;
        List<Pack> packs;

        internal ContentPack(Manifest manifest, List<Pack> packs)
        {
            this.manifest = manifest;
            this.packs = packs;
        }
    }
}
