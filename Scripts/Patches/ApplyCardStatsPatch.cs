using HarmonyLib;

namespace CorruptedCardsManager.Patches {
    [HarmonyPatch(typeof(ApplyCardStats), "ApplyStats")]
    public class ApplyCardStatsPatch {
        public static void Postfix(ApplyCardStats __instance, Player ___playerToUpgrade) {
            CorruptedStatModifers corruptedStatModifers = ___playerToUpgrade.GetComponent<CorruptedStatModifers>();
            if(corruptedStatModifers != null) {
                corruptedStatModifers.Apply(___playerToUpgrade);
            }
        }
    }
}
