using UnityEngine;

namespace Assets.Codes {
    public class Wall: MonoBehaviour {
        private void Update() {
        }

        private void Start() {
            Vector2[] wallVectors = new Vector2[5];
            wallVectors[0] = new Vector2(0f, 0f);
            wallVectors[1] = new Vector2(0f, Screen.width);
            wallVectors[2] = new Vector2(Screen.height, Screen.width);
            wallVectors[3] = new Vector2(Screen.height, 0f);
            wallVectors[4] = new Vector2(0f, 0f);

            gameObject.GetComponent<EdgeCollider2D>().points = wallVectors;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            Debug.Log("Collision!");
        }
    }
}