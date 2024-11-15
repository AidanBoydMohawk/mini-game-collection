using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team02
{
    public class Food : MonoBehaviour
    {
        public GameObject ballprefab; // Reference to the ball prefab
        public GameObject ballprefab2;
        public TextMeshProUGUI ScoreText;

        public int score = 0;

        // Audio
        public AudioSource audioSource;  // Reference to the AudioSource component
        public AudioClip yumSound1;     // Reference to the first yum sound
        public AudioClip yumSound2;     // Reference to the second yum sound

        private bool lastYumWas1 = true; // Keeps track of which "yum" sound was played last

        // Start is called before the first frame update
        void Start()
        {
            // Get the AudioSource component
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            ScoreText.text = score.ToString() + " POINTS";
        }

        public void OnTriggerEnter(Collider collider)
        {
            // Check if the collider is not Player2, Wall, and if it matches the ball prefab
            if (collider.gameObject.name != "Player2" &&
                collider.transform.root.name != "Player2" &&
                collider.gameObject.name != "Wall" &&
                collider.transform.root.name != "Wall" &&
               !collider.gameObject.name.StartsWith("2024-team02-bullet-prefab") && !collider.gameObject.name.StartsWith("2024-team02-bullet-prefab2"))
            {
                // Increase the score and player1 score
                score += 1;
                PlayerWin.player1 += 1;

                // Play the yum sound (alternating between yumSound1 and yumSound2)
                PlayYumSound();

                // Destroy the ball
                Destroy(collider.gameObject);

                // Grow bigger
                transform.localScale += new Vector3(.01f, .01f, .01f);
            }
        }

        private void PlayYumSound()
        {
            // Alternate between yumSound1 and yumSound2
            AudioClip yumClip = lastYumWas1 ? yumSound1 : yumSound2;
            audioSource.PlayOneShot(yumClip);
            lastYumWas1 = !lastYumWas1; // Alternate the yum sounds
        }
    }
}