using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team02
{
    public class Movement : MonoBehaviour
    {
        public float speed = 5.0f;
        public float jumpSpeed = 5.0f;

        public bool isGrounded;

        private Rigidbody rb;

        void Start()
        {
            // Get the Rigidbody component
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }
        }

        void Update()
        {
            // Use P1_AxisX for horizontal and P1_AxisY for vertical movement
            float moveHorizontal = Input.GetAxis("P1_AxisX");
            float moveVertical = Input.GetAxis("P1_AxisY");

            // Calculate movement direction
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Apply movement to the capsule
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

            // Check for jump input
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }

        public void Jump()
        {
            // Apply an upward force if grounded
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            // Check if touching the ground
            if (collision.collider.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            // Reset grounded state when leaving the ground
            if (collision.collider.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}


