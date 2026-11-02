// Prototype only — throwaway code, see PrototypeGameManager header.
using UnityEngine;
using UnityEngine.UI;

namespace HatMamVang.Prototype
{
    /// <summary>
    /// Builds the whole prototype world at runtime, so the user does not
    /// have to hand-build a scene in the Editor.
    /// Usage: open Assets/Scenes/SampleScene, add an empty GameObject,
    /// attach this script, press Play.
    /// All visuals are primitives on purpose — no art, no polish.
    /// </summary>
    public class PrototypeBootstrap : MonoBehaviour
    {
        private PrototypeGameManager _manager;

        private void Start()
        {
            CreateManagerAndUI();
            GameObject player = CreatePlayer();
            SetupCamera(player.transform);
            CreateGround();
            CreatePlots();
            CreateStation(new Vector3(6f, 1f, 0f), StationType.Processing, Color.yellow);
            CreateStation(new Vector3(-6f, 1f, 0f), StationType.Market, Color.blue);
            _manager.UpdateUI();
        }

        private void CreateManagerAndUI()
        {
            GameObject managerObject = new GameObject("PrototypeGameManager");
            _manager = managerObject.AddComponent<PrototypeGameManager>();

            GameObject canvasObject = new GameObject("PrototypeCanvas");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();

            _manager.StatusText = CreateText(canvasObject.transform, "StatusText",
                new Vector2(0f, 1f), new Vector2(0f, 1f), new Vector2(10f, -10f), 20,
                new Vector2(0f, 1f));
            _manager.StatusText.alignment = TextAnchor.UpperLeft;
            _manager.PromptText = CreateText(canvasObject.transform, "PromptText",
                new Vector2(0.5f, 0f), new Vector2(0.5f, 0f), new Vector2(0f, 40f), 22,
                new Vector2(0.5f, 0f));
            _manager.PromptText.alignment = TextAnchor.MiddleCenter;
        }

        private Text CreateText(Transform parent, string name, Vector2 anchorMin,
            Vector2 anchorMax, Vector2 anchoredPosition, int fontSize, Vector2 pivot)
        {
            GameObject textObject = new GameObject(name);
            textObject.transform.SetParent(parent, false);
            Text text = textObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = fontSize;
            text.color = Color.white;
            RectTransform rect = text.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.pivot = pivot;
            rect.anchoredPosition = anchoredPosition;
            rect.sizeDelta = new Vector2(500f, 150f);
            return text;
        }

        private GameObject CreatePlayer()
        {
            // Player starts south of the plots (plots are around z -4 to 0),
            // with the camera behind the player, so the plots are in front
            // of the camera. Starting at z +8 put the plots behind the camera.
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "PrototypePlayer";
            player.transform.position = new Vector3(0f, 1f, -8f);
            Destroy(player.GetComponent<CapsuleCollider>());

            CharacterController controller = player.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.center = Vector3.zero;

            PrototypePlayer script = player.AddComponent<PrototypePlayer>();
            script.GameManager = _manager;
            return player;
        }

        private void SetupCamera(Transform playerTransform)
        {
            Camera camera = Camera.main;
            if (camera == null)
            {
                camera = new GameObject("Main Camera").AddComponent<Camera>();
                camera.tag = "MainCamera";
            }

            PrototypeCameraFollow follow = camera.gameObject.AddComponent<PrototypeCameraFollow>();
            follow.Target = playerTransform;
        }

        private void CreateGround()
        {
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "PrototypeGround";
            ground.transform.localScale = new Vector3(3f, 1f, 3f);
            ground.GetComponent<Renderer>().material.color = new Color(0.3f, 0.6f, 0.3f);
        }

        private void CreatePlots()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Vector3 position = new Vector3((x - 1.5f) * 1.5f, 0.1f, (z - 1.5f) * 1.5f - 2f);
                    GameObject plot = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plot.name = "Plot_" + x + "_" + z;
                    plot.transform.position = position;
                    plot.transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);

                    // Plant is NOT a child of the flattened plot cube, otherwise
                    // the plot's 0.2 Y scale would squash the plant flat.
                    GameObject plant = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plant.name = "Plant_" + x + "_" + z;
                    plant.transform.position = position + new Vector3(0f, 0.4f, 0f);
                    plant.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    plant.SetActive(false);

                    FarmPlot farmPlot = plot.AddComponent<FarmPlot>();
                    farmPlot.GameManager = _manager;
                    farmPlot.PlantVisual = plant;
                }
            }
        }

        private void CreateStation(Vector3 position, StationType type, Color color)
        {
            GameObject station = GameObject.CreatePrimitive(PrimitiveType.Cube);
            station.name = type == StationType.Processing ? "ProcessingStation" : "MarketStall";
            station.transform.position = position;
            station.transform.localScale = new Vector3(2f, 2f, 2f);
            station.GetComponent<Renderer>().material.color = color;

            PrototypeStation script = station.AddComponent<PrototypeStation>();
            script.Type = type;
            script.GameManager = _manager;
        }
    }
}
