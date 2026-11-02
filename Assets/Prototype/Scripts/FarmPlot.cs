// Prototype only — throwaway code, see PrototypeGameManager header.
using UnityEngine;

namespace HatMamVang.Prototype
{
    public enum PlotState
    {
        Untilled,
        Tilled,
        PlantedDry,
        Growing,
        Ready
    }

    /// <summary>
    /// One farm plot. E cycles: cuoc -> gieo -> tuoi -> cho lon -> thu hoach.
    /// Growth is in seconds on purpose for a fast prototype test;
    /// seasons and real time are production work, not prototype work.
    /// </summary>
    public class FarmPlot : MonoBehaviour, IPrototypeInteractable
    {
        public PlotState State = PlotState.Untilled;
        public float GrowDuration = 8f;
        public int HarvestYield = 2;

        public PrototypeGameManager GameManager;
        public GameObject PlantVisual;

        private float _growTimer;
        private Renderer _plotRenderer;
        private Renderer _plantRenderer;

        public string Prompt
        {
            get
            {
                switch (State)
                {
                    case PlotState.Untilled: return "Cuoc dat";
                    case PlotState.Tilled: return "Gieo hat (1 hat giong)";
                    case PlotState.PlantedDry: return "Tuoi nuoc";
                    case PlotState.Growing: return "Dang lon...";
                    case PlotState.Ready: return "Thu hoach lua";
                    default: return "";
                }
            }
        }

        private void Awake()
        {
            _plotRenderer = GetComponent<Renderer>();
            if (PlantVisual != null)
            {
                _plantRenderer = PlantVisual.GetComponent<Renderer>();
            }
        }

        private void Start()
        {
            UpdateVisual();
        }

        private void Update()
        {
            if (State != PlotState.Growing)
            {
                return;
            }

            _growTimer += Time.deltaTime;
            float progress = Mathf.Clamp01(_growTimer / GrowDuration);
            if (PlantVisual != null)
            {
                PlantVisual.transform.localScale =
                    Vector3.Lerp(new Vector3(0.3f, 0.3f, 0.3f), new Vector3(0.8f, 1.2f, 0.8f), progress);
            }

            if (_growTimer >= GrowDuration)
            {
                State = PlotState.Ready;
                UpdateVisual();
            }
        }

        public void Interact(PrototypePlayer player)
        {
            if (GameManager == null)
            {
                return;
            }

            switch (State)
            {
                case PlotState.Untilled:
                    State = PlotState.Tilled;
                    break;
                case PlotState.Tilled:
                    if (GameManager.Seeds <= 0)
                    {
                        GameManager.SetPrompt("Het hat giong!");
                        return;
                    }

                    GameManager.Seeds -= 1;
                    State = PlotState.PlantedDry;
                    break;
                case PlotState.PlantedDry:
                    State = PlotState.Growing;
                    _growTimer = 0f;
                    break;
                case PlotState.Ready:
                    GameManager.Crops += HarvestYield;
                    State = PlotState.Untilled;
                    break;
                case PlotState.Growing:
                    break;
            }

            UpdateVisual();
            GameManager.UpdateUI();
        }

        private void UpdateVisual()
        {
            if (_plotRenderer != null)
            {
                _plotRenderer.material.color = State == PlotState.Untilled
                    ? new Color(0.35f, 0.25f, 0.15f)
                    : new Color(0.55f, 0.38f, 0.2f);
            }

            if (PlantVisual == null)
            {
                return;
            }

            switch (State)
            {
                case PlotState.Untilled:
                case PlotState.Tilled:
                    PlantVisual.SetActive(false);
                    break;
                case PlotState.PlantedDry:
                    PlantVisual.SetActive(true);
                    PlantVisual.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    if (_plantRenderer != null) _plantRenderer.material.color = Color.green;
                    break;
                case PlotState.Growing:
                    PlantVisual.SetActive(true);
                    if (_plantRenderer != null) _plantRenderer.material.color = Color.green;
                    break;
                case PlotState.Ready:
                    PlantVisual.SetActive(true);
                    PlantVisual.transform.localScale = new Vector3(0.8f, 1.2f, 0.8f);
                    if (_plantRenderer != null) _plantRenderer.material.color = Color.yellow;
                    break;
            }
        }
    }
}
