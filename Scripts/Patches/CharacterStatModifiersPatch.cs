using CorruptedCardsManager.Extensions;
using HarmonyLib;

namespace CorruptedCardsManager.Patches {
    [HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
    public class CharacterStatModifiersPatch {
        public static void Prefix(CharacterStatModifiers __instance) {
            CharacterData data = (CharacterData)Traverse.Create(__instance).Field("data").GetValue();
            data.GetAdditionalData().Reset();
        }
    }
}
