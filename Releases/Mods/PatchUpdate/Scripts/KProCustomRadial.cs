using GUI_2;
using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using KScripts;


namespace KCustomRadial
{
	public static class KProCustomRadial
	{
		public static void KSetupRadial(PlayerMoveController playerMoveController, XUiC_Radial xuiRadialWindow, EntityPlayerLocal entityPlayerLocal)
		{
			
			XUiC_Radial _xuiRadialWindow = xuiRadialWindow;
			_xuiRadialWindow.ResetRadialEntries();
			string[] radialItemNames = GetRadialItemNames("KTeleport", "RadialItems");
			int preSelectedCommandIndex = -1;
			for (int i = 0; i < radialItemNames.Length; i++)
			{
				ItemClass itemClass = ItemClass.GetItemClass(radialItemNames[i], false);
				if (itemClass != null && (!entityPlayerLocal.IsInWater() || itemClass.UsableUnderwater))
				{
					// int itemCount = _xuiRadialWindow.xui.PlayerInventory.GetItemCount(itemClass.Id);
					// bool flag = (int)entityPlayerLocal.inventory.holdingItemItemValue.SelectedAmmoTypeIndex == i;

					string _iconName = itemClass.GetIconName();
					string _localizedName = itemClass.GetLocalizedItemName();
					_xuiRadialWindow.CreateRadialEntry(i, itemClass.GetIconName(),
						"ItemIconAtlas","", itemClass.GetLocalizedItemName(), false);
				}
			}


			ItemActionAttack _iAA = entityPlayerLocal.inventory.GetHoldingGun();
			_xuiRadialWindow.SetCommonData(UIUtils.ButtonIcon.FaceButtonEast,
				new Action<XUiC_Radial, int, XUiC_Radial.RadialContextAbs>(
					KHandleRadialCommand),
				new KRadialContextItem(
					(ItemActionRanged) entityPlayerLocal.inventory.GetHoldingGun()), preSelectedCommandIndex,
				false);
		
		}
		private static void KHandleRadialCommand(XUiC_Radial _sender, int _commandIndex, XUiC_Radial.RadialContextAbs _context)
		{
			KRadialContextItem customRadialContextItem = _context as KRadialContextItem;
			EntityPlayerLocal entityPlayer = _sender.xui.playerUI.entityPlayer;
			string[] magazineItemNames = entityPlayer.inventory.GetHoldingGun().MagazineItemNames;
			if (customRadialContextItem == null)
			{
				return;
			}

			if (customRadialContextItem.RangedItemAction == entityPlayer.inventory.GetHoldingGun())
			{
				ItemClass itemClass = ItemClass.GetItemClass(magazineItemNames[_commandIndex], false);
				if (itemClass != null)
				{
					bool result = itemClass.HasTrigger(MinEventTypes.onSelfPrimaryActionEnd);
					var num = itemClass.Effects.EffectGroups.Count;

					if (num == 1)
					{
						itemClass.FireEvent(MinEventTypes.onSelfPrimaryActionEnd,
							MinEventParams.CachedEventParam);
					}
					else
					{
						KHelper.EasyLog(
							$"Error Effects group has {num} elements but should have 1 element.", LogLevel.File);
					}
				}
			}
		}
		
		

		
		public static string[] GetRadialItemNames(string _itemName, string _propertyName)

		{
			string _output = KHelper.GetXmlProperty(_itemName, _propertyName);
			string[] returnValue = _output.Split(',');
			return returnValue;
		}

		
	}
	public class KRadialContextItem : XUiC_Radial.RadialContextAbs
	{
	
		public KRadialContextItem(ItemActionRanged _rangedItemAction)
		{
			LogLevel log = LogLevel.None;
			KHelper.EasyLog("KRadialContextItem Constructor: _rangedItemAction:", log);
			KHelper.EasyLog(_rangedItemAction, log);
			this.RangedItemAction = _rangedItemAction;
		}
		public readonly ItemActionRanged RangedItemAction;

	}
}



