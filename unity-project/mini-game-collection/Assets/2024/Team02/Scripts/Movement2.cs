using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team02
{
    public class Movement2 : MonoBehaviour
    {
        public float speed = 5.0f;
        public float jumpSpeed = 5.0f;
        public GameObject ballPrefab; // The ball prefab to shoot
        public float ballSpeed = 10f; // Speed at which the ball travels
        public float pushForce = 100f;  // Force applied to other players when hit by the ball

        public bool isGrounded;
        private bool isOnCooldown = false;
        private Rigidbody rb;

        // Audio
        public AudioSource audioSource;
        public AudioClip jumpSound;
        public AudioClip ballShootSound;
        public AudioClip walkingSound;
        public AudioClip yumSound1;
        public AudioClip yumSound2;

        private bool isWalking = false;
        private bool lastYumWas1 = true;

        void Start()
        {
            // Get the Rigidbody component
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }

            // Get the AudioSource component
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        void Update()
        {
            // Use P2_AxisX for horizontal and P2_AxisY for vertical movement
            float moveHorizontal = Input.GetAxis("P2_AxisX");
            float moveVertical = Input.GetAxis("P2_AxisY");

            // Calculate movement direction
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Apply movement to the capsule
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

            // Make the capsule face the direction of movement
            if (movement.magnitude > 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f);

                // Handle walking sound (looping)
                if (!isWalking)
                {
                    isWalking = true;
                    PlayWalkingSound();
                }
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    StopWalkingSound();
                }
            }

            // Check if player is grounded based on vertical speed
            isGrounded = Mathf.Abs(rb.velocity.y) < 0.01f;

            // Check for jump input using custom action "P2_Action1"
            if (Input.GetButtonDown("P2_Action1") && isGrounded)
            {
                Jump();
            }

            // Shoot ball
            if (Input.GetButtonDown("P2_Action2"))
            {
                ShootBall();
            }
        }

        public void Jump()
        {
            // Play jump sound
            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }

            // Apply an upward force if grounded
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        public void ShootBall()
        {
            if (ballPrefab != null)  // Ensure that ballPrefab is assigned
            {
                // Create a new ball at the player's position with a slight offset in front
                GameObject ball = Instantiate(ballPrefab, transform.position + transform.forward, Quaternion.identity);

                // Ensure the ball has a Rigidbody component
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();
                if (ballRb != null)
                {
                    // Apply force to the ball to shoot it forward
                    ballRb.AddForce(transform.forward * ballSpeed, ForceMode.Impulse);
                }

                // Play ball shoot sound
                if (ballShootSound != null)
                {
                    audioSource.PlayOneShot(ballShootSound);
                }

                // Destroy the ball after 1 second
                Destroy(ball, 1f);
            }
        }

        private void PlayWalkingSound()
        {
            if (walkingSound != null && !audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.clip = walkingSound;
                audioSource.Play();
            }
        }

        private void StopWalkingSound()
        {
            if (audioSource.isPlaying && audioSource.clip == walkingSound)
            {
                audioSource.loop = false;
                audioSource.Stop();
            }
        }

    }
}