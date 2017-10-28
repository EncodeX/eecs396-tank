using System;
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
            Turn(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal2"));
            Thrust(Input.GetAxis("Vertical"), Input.GetAxis("Vertical2"));
            if (Input.GetAxis(_fireaxis) > 0.8f) {
                Fire();
            }
        }

        private void Turn(float direction1, float direction2) {
            float direction = gameObject.name == "Player1" ? direction1 : direction2;
            if (Mathf.Abs(direction) < 0.02f) {
                return;
            }
            _rb.AddTorque(direction * -0.4f);
        }

        private void Thrust(float intensity1, float intensity2) {
            float intensity = gameObject.name == "Player1" ? intensity1 : intensity2;
            if (Mathf.Abs(intensity) < 0.02f) {
//                if (Math.Abs(_rb.velocity.magnitude) > 0) {
//                    _rb.velocity -= _rb.velocity * 0.1f;
//                }
                return;
            }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire() {
            _gun.Fire();
        }
    }
}