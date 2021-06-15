using System.Collections.Generic;

namespace KPatchUpdate
{
    public class SphereII_Guts
    {
        public static void DoGuts(ItemActionEntryRepair _instance)
        {
            XUi xui = _instance.ItemController.xui;
            ItemValue itemValue = ((XUiC_ItemStack) _instance.ItemController).ItemStack.itemValue;
            ItemClass forId = ItemClass.GetForId(itemValue.type);
            EntityPlayerLocal player = xui.playerUI.entityPlayer;

            XUiC_CraftingWindowGroup childByType = xui.FindWindowGroupByName("crafting")
                .GetChildByType<XUiC_CraftingWindowGroup>();

            List<ItemStack> repairItems = new List<ItemStack>();

            // If the item has a repairItems, use that, instead of the vanilla version.
            if (forId.Properties.Classes.ContainsKey("RepairItems"))
            {
                Recipe recipe = new Recipe();
                DynamicProperties dynamicProperties3 = forId.Properties.Classes["RepairItems"];
                // recipe.ingredients = ItemsUtilities.ParseProperties(dynamicProperties3);
                //
                // // Get an adjusted Craftint time from the player.
                // recipe.craftingTime = (int)EffectManager.GetValue(PassiveEffects.CraftingTime, null, recipe.craftingTime, xui.playerUI.entityPlayer, recipe, FastTags.Parse(recipe.GetName()), true, true, true, true, 1, true);
                // ItemsUtilities.ConvertAndCraft(recipe, player, __instance.ItemController);
                
            }
            else if (
                forId.Properties
                    .Contains(
                        "RepairItems")) // to support <property name="RepairItems" value="resourceWood,10,resourceForgedIron,10" />
            {
                Recipe recipe = new Recipe();
                string strData = forId.Properties.Values["RepairItems"].ToString();
                //recipe.ingredients = ItemsUtilities.ParseProperties(strData);

                // Get an adjusted Craftint time from the player.
                // recipe.craftingTime = (int)EffectManager.GetValue(PassiveEffects.CraftingTime, null, recipe.craftingTime, xui.playerUI.entityPlayer, recipe, FastTags.Parse(recipe.GetName()), true, true, true, true, 1, true);
                // ItemsUtilities.ConvertAndCraft(recipe, player, __instance.ItemController);
              

            }
            // If there's no RepairTools defined, then fall back to recipe reduction
            else if (forId.RepairTools == null || forId.RepairTools.Length <= 0)
            {
                // Determine, based on percentage left, 
                //int RecipeCountReduction = 2;
                // if (itemValue.PercentUsesLeft < 0.2)
                //     RecipeCountReduction = 3;

                // Use the helper method to reduce the recipe count, and control displaying on the UI for consistenncy.
                //ItemsUtilities.ConvertAndCraft(forId.GetItemName(), RecipeCountReduction, player, __instance.ItemController);
                


            }
        }
    }
}