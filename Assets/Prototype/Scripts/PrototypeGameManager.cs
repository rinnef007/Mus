// Prototype only — throwaway code for Hạt Mầm Vàng core-loop test.
// Do NOT import this from production code. Production code must be
// written from scratch if this prototype gets a PROCEED verdict.
using UnityEngine;
using UnityEngine.UI;

namespace HatMamVang.Prototype
{
    /// <summary>
    /// Holds prototype inventory counts and updates the on-screen text.
    /// Created at runtime by PrototypeBootstrap; no scene setup required.
    /// </summary>
    public class PrototypeGameManager : MonoBehaviour
    {
        public int Seeds = 20;
        public int Crops;
        public int Processed;
        public int Coins;

        public Text StatusText;
        public Text PromptText;

        public void UpdateUI()
        {
            if (StatusText != null)
            {
                StatusText.text =
                    "Hat giong: " + Seeds + "\n" +
                    "Lua: " + Crops + "\n" +
                    "Gao: " + Processed + "\n" +
                    "Xu: " + Coins + "\n" +
                    "WASD di chuyen - E tuong tac";
            }
        }

        public void SetPrompt(string prompt)
        {
            if (PromptText != null)
            {
                PromptText.text = prompt;
            }
        }

        private void Start()
        {
            UpdateUI();
        }
    }
}
