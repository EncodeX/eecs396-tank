using UnityEngine;

namespace Codes {
    public class Player : MonoBehaviour {
        private static string _fireaxis;

        private Rigidbody2D _rb;
	    private Gun _gun;

        // Use this for initialization
        internal void Start() {
            _rb = GetComponent<Rigidbody2D>();
		    _gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis();
        }

        // Update is called once per frame
        internal void Update() {
            HandleInput();
        }

        private void HandleInput() {
            Turn(Input.GetAxis("Horizontal"));
            Thrust(Input.GetAxis("Vertical"));
            if (Input.GetAxis(_fireaxis) > 0.8f) {
                Fire();
            }
        }

        private void Turn(float direction) {
            if (Mathf.Abs(direction) < 0.02f) {
                return;
            }
            _rb.AddTorque(direction * -0.05f);
        }

        private void Thrust(float intensity) {
            if (Mathf.Abs(intensity) < 0.02f) {
                return;
            }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire() {
            _gun.Fire();
        }
    }
}