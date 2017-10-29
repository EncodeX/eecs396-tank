using UnityEngine;

namespace Codes {
    public class Wall: MonoBehaviour {
        private void Update() {
        }

        private void Awake() {
            var left = Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height;
            var right = Camera.main.transform.position.x + Camera.main.orthographicSize * Screen.width / Screen.height;
            var top = Camera.main.transform.position.y - Camera.main.orthographicSize;
            var bottom = Camera.main.transform.position.y + Camera.main.orthographicSize;
            Vector2[] wallVectors = new Vector2[5];
            wallVectors[0] = new Vector2(left, top);
            wallVectors[1] = new Vector2(left, bottom);
            wallVectors[2] = new Vector2(right, bottom);
            wallVectors[3] = new Vector2(right, top);
            wallVectors[4] = new Vector2(left, top);

            gameObject.GetComponent<EdgeCollider2D>().points = wallVectors;
        }
    }
}