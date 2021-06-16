using GUI_2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KPatchUpdate
{
	public class KProCustomRadial
	{
		
		public static void Test()
		{
			KProSetupRadial();
		}

		private static string[] GetRadialItems()
		{
			string[] radialItems =  KHelper.GetXmlProperty("KTeleport", "RadialItems").Split(',');
			return radialItems;
		}
		public static void KProSetupRadial()
		{
			LogLevel log = LogLevel.Both;
			KHelper.EasyLog("Made it to Custom Radial", log);
			
			var entityPlayer = KHelper.GetEntityPlayer();
			XUiC_Radial xuiRadialWindow = LocalPlayerUI.GetUIForPlayer(entityPlayer).xui.RadialWindow;
			
		
			
			xuiRadialWindow.ResetRadialEntries();
			string[] radialItems = GetRadialItems(); 
			int preSelectedCommandIndex = -1;
			KHelper.EasyLog(
				$"Before for loop: RadialItems.length: {radialItems.Length}",
				log);

			if (radialItems.Length > 0)
			{

				for (int i = 0; i < radialItems.Length; i++)
				{
					ItemClass itemClass = ItemClass.GetItemClass(radialItems[i], false);
					if (itemClass != null)
					{
						// int itemCount =
						// 	xuiRadialWindow.xui.PlayerInventory.GetItemCount(itemClass.Id);
						xuiRadialWindow.CreateRadialEntry(i, itemClass.GetIconName(),
							"ItemIconAtlas",
							String.Format(" "), itemClass.GetLocalizedItemName(), false);
					}
				}

				xuiRadialWindow.SetCommonData(UIUtils.ButtonIcon.FaceButtonEast,
					new Action<XUiC_Radial, int, XUiC_Radial.RadialContextAbs>(
						KProHandleCustomRadialCommand),
					new KProRadialContextItem(),
					preSelectedCommandIndex, false);
			}
		}

		public static void KProHandleCustomRadialCommand(XUiC_Radial _sender,
			int _commandIndex, // Add a standard handle radial command
			XUiC_Radial.RadialContextAbs _context)
		{
			KProRadialContextItem customRadialContextItem = _context as KProRadialContextItem;
			EntityPlayerLocal entityPlayer = _sender.xui.playerUI.entityPlayer;
			string[] radialItems = GetRadialItems(); 
			if (customRadialContextItem == null)
			{
				return;
			}

			// if (customRadialContextItem.RangedItemAction == entityPlayer.inventory.GetHoldingGun())
			if (true)
			{
				ItemClass itemClass =
					ItemClass.GetItemClass(radialItems[_commandIndex], false);
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
							$"Error Effects group has {num} elements but should have 1 element.",
							LogLevel.File);
					}
				}
			}
		}
	}


	public class KProRadialContextItem : XUiC_Radial.RadialContextAbs
	{
		LogLevel log = LogLevel.Both;

		// Token: 0x060023E5 RID: 9189 RVA: 0x000E53BB File Offset: 0x000E35BB
		public KProRadialContextItem()
		{
			KHelper.EasyLog("RadialContextItem", log);
			// KHelper.EasyLog(_rangedItemAction, log);
			// this.RangedItemAction = _rangedItemAction;
		}

		// Token: 0x04001CD6 RID: 7382
		public readonly ItemActionRanged RangedItemAction;
	}
}





