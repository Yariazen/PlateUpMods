using CoffeeExpansion;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace CoffeeExpansion
{
    internal class CreativeTerminal : CustomAppliance
	{
		public override string Name
		{
			get { return "Creative Appliance"; }
		}

		public override string Description
		{
			get { return "It's an appliance for testing things"; }
		}
		public override GameObject Prefab
		{
			get { return Mod.gamedata.Get<Appliance>().FirstOrDefault(a => a.ID == Mod.OrderingTerminalID).Prefab; }
		}

		public override void OnRegister(GameDataObject gameDataObject)
        {
            MaterialUtils.ApplyMaterial(((Appliance)gameDataObject).Prefab, "OrderMachine/Base_L_Counter.blend", new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default"), MaterialUtils.GetExistingMaterial("Wood 4 - Painted"), MaterialUtils.GetExistingMaterial("Wood 4 - Painted") });
            MaterialUtils.ApplyMaterial(((Appliance)gameDataObject).Prefab, "OrderMachine/Base_L_Counter.blend/Handle_L_Counter.blend", new Material[] { MaterialUtils.GetExistingMaterial("Knob") });
            MaterialUtils.ApplyMaterial(((Appliance)gameDataObject).Prefab, "OrderMachine/Top_L_Counter.blend", new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default") });
            MaterialUtils.ApplyMaterial(((Appliance)gameDataObject).Prefab, "OrderMachine/Cube", new Material[] { MaterialUtils.GetExistingMaterial("Plastic - Black"), MaterialUtils.GetExistingMaterial("Screen") });
            MaterialUtils.ApplyMaterial(((Appliance)gameDataObject).Prefab, "OrderMachine/Cube/Star", new Material[] { MaterialUtils.GetExistingMaterial("Plastic - Black") });
            MaterialUtils.ApplyMaterial(((Appliance)gameDataObject).Prefab, "OrderMachine/Cube/Star1", new Material[] { MaterialUtils.GetExistingMaterial("Plastic - Black") });
        }

		private static TextMeshPro text;
		static Dictionary<int, string> appliances;
		static List<int> keys;
		static int counter = -1;

		public override bool PreRotate(InteractionData data, bool isSecondary)
		{
			if (isSecondary)
			{
				SpawnUtils.SpawnApplianceBlueprint(getSelectedAppliance());
			}
			else
			{
				if (text == null)
				{
					GameObject uiContainer = GameObject.Find("UI Container");
					GameObject versionDisplay = GameObject.Find("Version Display(Clone)");
					GameObject counterText = Object.Instantiate(versionDisplay, versionDisplay.transform.position, versionDisplay.transform.rotation);
					counterText.transform.parent = uiContainer.transform;
					counterText.name = "Counter Text";
					counterText.transform.localPosition = new Vector3(counterText.transform.localPosition.x, counterText.transform.localPosition.y + 1, counterText.transform.localPosition.z);
					text = counterText.transform.GetChild(0).GetComponent<TextMeshPro>();
				}
				if (appliances == null)
				{
					appliances = new Dictionary<int, string>();
					keys = new List<int>();
					foreach (Appliance appliance in GameData.Main.Get<Appliance>())
					{
						if (appliance.Name != "")
						{
							keys.Add(appliance.ID);
							appliances.Add(appliance.ID, appliance.Name);
						}
					}
				}
				if (Input.GetKey(KeyCode.LeftShift))
					counter--;
				else
					counter++;
				if (counter > (keys.Count - 1))
					counter = 0;
				if (counter < 0)
					counter = keys.Count - 1;
				text.text = appliances[keys[counter]];
			}
			return true;
		}

		public override bool ForceIsInteractionPossible()
		{
			return true;
		}

		public override bool IsInteractionPossible(InteractionData data)
		{
			return true;
		}

		public override bool PreInteract(InteractionData data, bool isSecondary = false)
		{
			return false;
		}

		public static int getSelectedAppliance()
		{
			if (keys == null)
				return Mod.OrderingTerminalID;
			else
				return keys[counter];
		}
		
	}
}
