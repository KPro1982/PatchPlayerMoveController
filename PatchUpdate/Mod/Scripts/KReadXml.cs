// Based on Sphereii Core
using System.Collections.Generic;
using static KPatchUpdate.ItemsUtilities;

namespace KPatchUpdate
{
    public static class KReadXml
    {
        public static void GetXml()
        {
            ItemClass itemClass = ItemClass.GetItemClass("KTeleport", false);
            var strData = itemClass.Properties.Values["KProOuterActions"];
            if (itemClass.Properties.Classes.ContainsKey("CKPro"))
            {
                var dynamicProperties3 = itemClass.Properties.Classes["KProInnerActions"];
                List<ItemStack> stack = ParseProperties(dynamicProperties3);
            }  
            KHelper.EasyLog("Parsed!", LogLevel.Chat);

        }

        
    }
}