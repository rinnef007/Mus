// Prototype only — throwaway code, see PrototypeGameManager header.
using UnityEngine;

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
    /// Uses legacy Input on purpose: no Input System asset wiring needed
    /// for a throwaway build.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PrototypePlayer : MonoBehaviour
    {
        public float MoveSpeed = 6f;
        public float InteractionRange = 3.5f;
        public PrototypeGameManager GameManager;

        private CharacterController _controller;
        private IPrototypeInteractable _nearest;
        private float _verticalVelocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 move = new Vector3(h, 0f, v);
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

            if (Input.GetKeyDown(KeyCode.E) && _nearest != null)
            {
                _nearest.Interact(this);
            }
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
