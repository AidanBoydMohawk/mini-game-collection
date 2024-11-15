using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team02
{
    

    public class Food2 : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;

        public int score = 0;

        // Start is called before the first frame update
        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {
            ScoreText.text = score.ToString() + " POINTS";
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.name != "Player1" && collider.transform.root.name != "Player1" && collider.gameObject.name != "Wall" && collider.transform.root.name != "Wall")
            {
            score += 1; // add score
            PlayerWin.player2 += 1;
            Destroy(collider.gameObject); // Destroy object
            transform.localScale += new Vector3(.01f, .01f, .01f); // grow bigger
            }
        }
    }
}
