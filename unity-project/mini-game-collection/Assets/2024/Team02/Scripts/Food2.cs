using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team02
{
    public class Food2 : MonoBehaviour
    {
        public GameObject ballprefab; // Reference to the ball prefab
        public GameObject ballprefab2;
        public TextMeshProUGUI ScoreText;

        public int score = 0;

        // Audio
        public AudioSource audioSource;
        public AudioClip yumSound1;
        public AudioClip yumSound2;

        private bool lastYumWas1 = true;

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
            Debug.Log(collider.gameObject);
            if (collider.gameObject.name != "Player1" && collider.transform.root.name != "Player1" && collider.gameObject.name != "Wall" && collider.transform.root.name != "Wall" && !collider.gameObject.name.StartsWith("2024-team02-bullet-prefab") && !collider.gameObject.name.StartsWith("2024-team02-bullet-prefab2"))
            {
                score += 1; // Add score
                PlayerWin.player2 += 1;

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
