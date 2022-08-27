using System;
using System.Runtime.CompilerServices;
using MelonLoader;
using Kitchen;
using KitchenLib.Registry;
using KitchenLib.Appliances;
using KitchenLib.Utils;

namespace KitchenLib
{
	public abstract class BaseMod : MelonMod
	{
		public string ModName { get { return Info.Name; } }
		public string ModVersion { get { return Info.Version; } }

		public string ModID;
		public string[] TestedVersions;
		public string[] ModDependencies;


        public BaseMod(string modID, string[] testedVersions, string[] modDependencies = null) : base() {
            ModID = modID; TestedVersions = testedVersions; ModDependencies = modDependencies;
            ModRegistery.Register(this);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Log(string message) {
			MelonLogger.Msg(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(string message) {
			MelonLogger.Error(message);
		}

		[Obsolete("Use the AddAppliance method instead")]
		public T RegisterCustomAppliance<T>() where T : CustomAppliance, new()  {
			return AddAppliance<T>();
		}

		public T AddAppliance<T>() where T : CustomAppliance, new()  {
			T appliance = new T();
			appliance.ModName = Info.Name;
			return CustomAppliances.Register(appliance);
		}

		public T AddSystem<T>() where T : GenericSystemBase, new() {
			return SystemUtils.AddSystem<T>();
		}
	}
}
