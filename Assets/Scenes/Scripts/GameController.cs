using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class GameController : MonoBehaviour
    {
        public Text scoreText;
        private int score;

        // Start is called before the first frame update
        void Start()
        {
            UpdateScore(0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore(int scoreValue)
        {
            UpdateScore(score + scoreValue);
        }

        private void UpdateScore(int newScore)
        {
            score = newScore;
            scoreText.text = "Score: " + score;
        }
    }
}