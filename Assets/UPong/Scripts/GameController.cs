using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace UnityGame
{
    public class GameController : MonoBehaviour
    {
        public Text scoreText;
        public Text timerText;

        public float targetTime = 60.0f;
        private float counterTime;
        private int score;

        // Start is called before the first frame update
        void Start()
        {
            UpdateScore(0);
            counterTime = targetTime;
        }

        // Update is called once per frame
        void Update()
        {
            counterTime -= Time.deltaTime;

            if (counterTime <= 0.0f)
            {
                // timerEnded();
            }

            timerText.text = "Time: " + counterTime.ToString("f1");
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

        private void timerEnded()
        {
            //Game Over
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            Destroy(GameObject.Find("Menu UI"));
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}