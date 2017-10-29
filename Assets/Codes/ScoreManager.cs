using System;
using UnityEngine;
using UnityEngine.UI;


namespace Codes

{
    public class ScoreManager : MonoBehaviour {
        private static float _playerScore1, _playerScore2;
        private static Text _playerScoreText1, _playerScoreText2;
        private static RectTransform _playerScoreRect1, _playerScoreRect2;

        private void Start() {
            if (gameObject.name == "Player1Score") {
                _playerScoreRect1 = GetComponent<RectTransform>();
                _playerScoreText1 = GetComponent<Text>();
            }
            else {
                _playerScoreRect2 = GetComponent<RectTransform>();
                _playerScoreText2 = GetComponent<Text>();
            }
            
            RefreshScore();
        }

        public static void AddScore(string player, float score) {
            if (player == "Player1") {
                _playerScore1 += score;
            }
            else {
                _playerScore2 += score;
            }
            
            RefreshScore();
        }

        private static void RefreshScore() {
            if (_playerScoreText1 == null | _playerScoreText2 == null) {
                return;
            }
            _playerScoreText1.text = String.Format("P1 Score  {0}", _playerScore1);
            _playerScoreText2.text = String.Format("{0}  P2 Score ", _playerScore2);
        }

        private void Update() {
            var height = Screen.height;
            var width = Screen.width;
            _playerScoreRect1.position = new Vector3(0f, height);
            _playerScoreRect2.position = new Vector3(width, height);
            _playerScoreRect1.sizeDelta = new Vector2(width * .5f, 20f);
            _playerScoreRect2.sizeDelta = new Vector2(width * .5f, 20f);
        }
    }
}
