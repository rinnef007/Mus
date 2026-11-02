// Prototype only — throwaway code, see PrototypeGameManager header.
using UnityEngine;
using UnityEngine.InputSystem;

namespace HatMamVang.Prototype
{
    public interface IPrototypeInteractable
    {
        string Prompt { get; }
        void Interact(PrototypePlayer player);
    }

    /// <summary>
    /// Simple third-person movement for the prototype.
    /// WASD moves, E interacts with the nearest interactable in range.
    /// Camera is a fixed-angle follow camera (see PrototypeCameraFollow);
    /// a final third-person orbit camera is production work, not prototype work.
    /// Uses the Input System package on purpose: this project sets
    /// Active Input Handler to Input System only, so legacy
    /// UnityEngine.Input throws InvalidOperationException here.
    /// Actions are created in code, so no Input Action asset wiring is needed.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PrototypePlayer : MonoBehaviour
    {
        public float MoveSpeed = 6f;
        public float InteractionRange = 3.5f;
        public PrototypeGameManager GameManager;

        private CharacterController _controller;
        private InputAction _moveAction;
        private InputAction _interactAction;
        private IPrototypeInteractable _nearest;
        private float _verticalVelocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();

            _moveAction = new InputAction("Move", InputActionType.Value);
            _moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/w")
                .With("Down", "<Keyboard>/s")
                .With("Left", "<Keyboard>/a")
                .With("Right", "<Keyboard>/d");
            _moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow")
                .With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");

            _interactAction = new InputAction("Interact", InputActionType.Button, "<Keyboard>/e");
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _interactAction.Enable();
            _interactAction.performed += OnInteractPerformed;
        }

        private void OnDisable()
        {
            _interactAction.performed -= OnInteractPerformed;
            _moveAction.Disable();
            _interactAction.Disable();
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            if (_nearest != null)
            {
                _nearest.Interact(this);
            }
        }

        private void Update()
        {
            Vector2 input = _moveAction.ReadValue<Vector2>();
            Vector3 move = new Vector3(input.x, 0f, input.y);
            if (move.sqrMagnitude > 1f)
            {
                move.Normalize();
            }

            if (_controller.isGrounded)
            {
                _verticalVelocity = 0f;
            }
            else
            {
                _verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }

            Vector3 velocity = move * MoveSpeed;
            velocity.y = _verticalVelocity;
            _controller.Move(velocity * Time.deltaTime);

            if (move.sqrMagnitude > 0.01f)
            {
                transform.forward = Vector3.Lerp(transform.forward, move, 0.2f);
            }

            FindNearestInteractable();
        }

        private void FindNearestInteractable()
        {
            _nearest = null;
            float nearestDistance = InteractionRange;
            Collider[] hits = Physics.OverlapSphere(transform.position, InteractionRange);
            foreach (Collider hit in hits)
            {
                IPrototypeInteractable interactable =
                    hit.GetComponentInParent<IPrototypeInteractable>();
                if (interactable == null)
                {
                    continue;
                }

                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    _nearest = interactable;
                }
            }

            if (GameManager != null)
            {
                GameManager.SetPrompt(_nearest != null ? "E: " + _nearest.Prompt : "");
            }
        }
    }
}
