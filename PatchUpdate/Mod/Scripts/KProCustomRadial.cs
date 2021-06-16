using GUI_2;
using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;


namespace KCustomRadial
{
	public static class KProCustomRadial
	{
		public static void KSetupRadial(PlayerMoveController _playerMoveController)
		{
			
			XUiC_Radial _xuiRadialWindow = _playerMoveController.playerUI.xui.RadialWindow;
			EntityPlayerLocal entityPlayerLocal = _playerMoveController.entityPlayerLocal;
			_xuiRadialWindow.ResetRadialEntries();
			string[] radialItemNames = entityPlayerLocal.inventory.GetHoldingGun().MagazineItemNames;
			int preSelectedCommandIndex = -1;
			for (int i = 0; i < radialItemNames.Length; i++)
			{
				ItemClass itemClass = ItemClass.GetItemClass(radialItemNames[i], false);
				if (itemClass != null && (!entityPlayerLocal.IsInWater() || itemClass.UsableUnderwater))
				{
					int itemCount = _xuiRadialWindow.xui.PlayerInventory.GetItemCount(itemClass.Id);
					bool flag = (int)entityPlayerLocal.inventory.holdingItemItemValue.SelectedAmmoTypeIndex == i;
					_xuiRadialWindow.CreateRadialEntry(i, itemClass.GetIconName(),
						(itemCount > 0) ? "ItemIconAtlas" : "ItemIconAtlasGreyscale",
						itemCount.ToString(), itemClass.GetLocalizedItemName(), flag);
					if (flag)
					{
						preSelectedCommandIndex = i;
					}
				}
			}
			_xuiRadialWindow.SetCommonData(UIUtils.ButtonIcon.FaceButtonEast,
				new Action<XUiC_Radial, int, XUiC_Radial.RadialContextAbs>(
					this.handleRadialCommand),
				new ItemActionAttack.RadialContextItem(
					(ItemActionRanged) entityPlayerLocal.inventory.GetHoldingGun()), preSelectedCommandIndex,
				false);
		

	




		}
		
		
		

		
	}
}



