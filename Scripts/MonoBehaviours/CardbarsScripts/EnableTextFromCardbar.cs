using TMPro;
using UnboundLib;
using UnityEngine;

namespace CorruptedCardsManager.MonoBehaviours.CardbarsScripts {
    public class EnableTextFromCardbar : MonoBehaviour {
        [HideInInspector] public TextMeshProUGUI text;
        void OnEnable() {
            text = transform.parent.GetComponentInChildren<TextMeshProUGUI>();
            this.ExecuteAfterFrames(1, () => {
                text.enabled = true;
            });
        }
    }
}
