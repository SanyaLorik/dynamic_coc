using System;
using UnityEngine;
using UnityEngine.Events;

namespace _KotletaGames.ThirdPersonMovement_M.Information
{
    [Serializable]
    public class IsGroundChecker : MonoBehaviour
    {
        public float checkRadius = 0.3f;
        public LayerMask groundLayer;
        public bool IsGrounded;
        public UnityEvent<bool> IsGroundedUpdated;

        void Update() => CheckGround();

        void CheckGround()
        {
            bool isGrounded = Physics.CheckSphere(transform.position, checkRadius, groundLayer);

            if (IsGrounded != isGrounded)
                IsGroundedUpdated.Invoke(isGrounded);

            IsGrounded = isGrounded;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, checkRadius);
        }
    }
}