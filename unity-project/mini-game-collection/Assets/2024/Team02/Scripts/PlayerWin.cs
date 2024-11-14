using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace MiniGameCollection.Games2024.Team02
{
    public class PlayerWin : MonoBehaviour
    {
        public static int player1;
        public static int player2;
        public TextMeshProUGUI wintext;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (player1 > player2)
            {
                wintext.text = "PLAYER 1 WINS WITH " + player1 + " POINTS";
            }

            if (player2 > player1)
            {
                wintext.text = "PLAYER 2 WINS WITH " + player2 + "POINTS";
            }
        }
    }
}
