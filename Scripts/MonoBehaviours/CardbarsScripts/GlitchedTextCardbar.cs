using UnboundLib;
using UnityEngine;

namespace CorruptedCardsManager.MonoBehaviours.CardbarsScripts {
    [RequireComponent(typeof(EnableTextFromCardbar))]
    public class GlitchedTextCardbar : MonoBehaviour {
        public void Start() {
            this.ExecuteAfterFrames(1, () => {
                EnableTextFromCardbar enableTextFromCardbar = GetComponent<EnableTextFromCardbar>();
                enableTextFromCardbar.text.gameObject.AddComponent<GlitchingTextMono>();
            });
        }
    }
}
