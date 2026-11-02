// Prototype only — throwaway code, see PrototypeGameManager header.
using UnityEngine;

namespace HatMamVang.Prototype
{
    /// <summary>Fixed-angle follow camera for the prototype only.</summary>
    public class PrototypeCameraFollow : MonoBehaviour
    {
        public Transform Target;
        public Vector3 Offset = new Vector3(0f, 9f, -9f);

        private void LateUpdate()
        {
            if (Target == null)
            {
                return;
            }

            transform.position = Target.position + Offset;
            transform.LookAt(Target.position + Vector3.up);
        }
    }
}
