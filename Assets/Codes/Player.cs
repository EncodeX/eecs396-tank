using UnityEngine;

namespace Codes {
    public class Player : MonoBehaviour {
        private string _fireaxis;

        private Rigidbody2D _rb;
	    private Gun _gun;

        // Use this for initialization
        internal void Start() {
            _rb = GetComponent<Rigidbody2D>();
		    _gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis(gameObject.name);
        }

        // Update is called once per frame
        internal void Update() {
            HandleInput();
        }

        private void HandleInput() {
            Turn(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal2"));
            Thrust(Input.GetAxis("Vertical"), Input.GetAxis("Vertical2"));
            if (Input.GetAxis(_fireaxis) > 0.8f) {
                Fire(gameObject.GetComponent<SpriteRenderer>().color);
            }
        }

        private void Turn(float direction1, float direction2) {
            float direction = gameObject.name == "Player1" ? direction1 : direction2;
            if (Mathf.Abs(direction) < 0.02f) {
                return;
            }
            _rb.AddTorque(direction * -0.05f);
        }

        private void Thrust(float intensity1, float intensity2) {
            float intensity = gameObject.name == "Player1" ? intensity1 : intensity2;
            if (Mathf.Abs(intensity) < 0.02f) {
                return;
            }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire(Color color) {
            _gun.Fire(color);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.name == "Bullet(Clone)") {
                if (other.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color) {
                    ScoreManager.AddScore(gameObject.name == "Player1"? "Player1":"Player2", -1f);
                }
                else {
                    ScoreManager.AddScore(gameObject.name == "Player1"? "Player2":"Player1", 2f);
                }
            }
        }
    }
}