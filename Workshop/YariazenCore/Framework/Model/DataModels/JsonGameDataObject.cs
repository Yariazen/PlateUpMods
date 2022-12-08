namespace YariazenCore.Framework.Model.JsonModels
{
    public abstract class JsonGameDataObject
    {
        public int ID { get; set; }
        public virtual string UniqueNameID { get; set; }
        public virtual int BaseGameDataObjectID { get; set; } = -1;
        public string ModName { get; set; }
    }
}
