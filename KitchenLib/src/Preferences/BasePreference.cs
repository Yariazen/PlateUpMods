using System.IO;

namespace KitchenLib
{
    public abstract class BasePreference : IBinarySerializable{
        public string ModID;
	    public string Key;
        public string DisplayName;
        public abstract void Deserialize(BinaryReader reader);
        public abstract void Serialize(BinaryWriter writer);   
	    public BasePreference() { } 
    }

    public class BoolPreference : BasePreference
    {
        public bool Value;
        public BoolPreference() : base() { }
        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void Deserialize(BinaryReader reader)
        {
            Value = reader.ReadBoolean();
        }
    }

    public class StringPreference : BasePreference
    {
        public string Value;
        public StringPreference() : base() { }
        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void Deserialize(BinaryReader reader)
        {
            Value = reader.ReadString();
        }
    }
    public interface IBinarySerializable {
        void Deserialize(BinaryReader reader);
        void Serialize(BinaryWriter writer);
    }
}