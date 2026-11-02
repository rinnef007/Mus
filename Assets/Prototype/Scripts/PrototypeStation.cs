// Prototype only — throwaway code, see PrototypeGameManager header.
using UnityEngine;

namespace HatMamVang.Prototype
{
    public enum StationType
    {
        Processing,
        Market
    }

    /// <summary>
    /// Processing: 3 lua -> 1 gao (3 seconds).
    /// Market: 1 gao -> 10 xu (instant).
    /// </summary>
    public class PrototypeStation : MonoBehaviour, IPrototypeInteractable
    {
        public StationType Type = StationType.Processing;
        public int ProcessingCost = 3;
        public float ProcessingDuration = 3f;
        public int SellPrice = 10;

        public PrototypeGameManager GameManager;

        private bool _processing;
        private float _processingTimer;

        public string Prompt
        {
            get
            {
                if (Type == StationType.Processing)
                {
                    return _processing
                        ? "Dang che bien..."
                        : "Che bien (3 lua -> 1 gao)";
                }

                return "Ban gao (1 gao -> 10 xu)";
            }
        }

        private void Update()
        {
            if (!_processing)
            {
                return;
            }

            _processingTimer += Time.deltaTime;
            if (_processingTimer >= ProcessingDuration)
            {
                _processing = false;
                if (GameManager != null)
                {
                    GameManager.Processed += 1;
                    GameManager.UpdateUI();
                }
            }
        }

        public void Interact(PrototypePlayer player)
        {
            if (GameManager == null)
            {
                return;
            }

            if (Type == StationType.Processing)
            {
                if (_processing)
                {
                    return;
                }

                if (GameManager.Crops < ProcessingCost)
                {
                    GameManager.SetPrompt("Can 3 lua de che bien!");
                    return;
                }

                GameManager.Crops -= ProcessingCost;
                _processing = true;
                _processingTimer = 0f;
            }
            else
            {
                if (GameManager.Processed <= 0)
                {
                    GameManager.SetPrompt("Chua co gao de ban!");
                    return;
                }

                GameManager.Processed -= 1;
                GameManager.Coins += SellPrice;
            }

            GameManager.UpdateUI();
        }
    }
}
