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
            Debug.Log(collider);
            score += 1;
            PlayerWin.player2 += 1;
            Destroy(collider.gameObject);
            transform.localScale += new Vector3(.01f, .01f, .01f);
        }
    }
}
