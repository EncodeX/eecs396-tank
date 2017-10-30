using System;
using UnityEngine;

namespace Codes {
    public class Player : MonoBehaviour {
        private string _fireaxis;

        private Rigidbody2D _rb;
	    private Gun _gun;
        public Vector2 velocity;
        public float speed;
        public float angle;

        // Use this for initialization
        internal void Start() {
            _rb = GetComponent<Rigidbody2D>();
		    _gun = GetComponent<Gun>();
            velocity = new Vector2(1,0); // new kinematic velocity for player

            _fireaxis = Platform.GetFireAxis(gameObject.name);
            angle = 180f;
            speed = 2f;
        }

        // Update is called once per frame
        internal void Update() {
            HandleInput();
        }

        private void HandleInput() {
            //Turn(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal2"));
            //Thrust(Input.GetAxis("Vertical"), Input.GetAxis("Vertical2"));
            Calc(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical"), Input.GetAxis("Vertical2"));
            if (Input.GetAxis(_fireaxis) > 0.8f) {
                Fire(gameObject.GetComponent<SpriteRenderer>().color);
            }
        }

        private void Calc(float axisX1, float axisX2, float axisY1, float axisY2)
        {
            float axisX = gameObject.name == "Player1" ? axisX1 : axisX2;
            float axisY = gameObject.name == "Player1" ? axisY1 : axisY2;
            
            if (Mathf.Abs(axisX) < 0.2f)
            {
                axisX = 0;
            }

            if (Mathf.Abs(axisY) < 0.2f)
            {
                axisY = 0;
            }
            
            Vector2 movement = ((Vector2)transform.up) * axisY * speed * Time.deltaTime;

            _rb.MovePosition(_rb.position + movement);
            
            float turn = axisX * angle * Time.deltaTime;

            // Make this into a rotation in the y axis.
            // Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            _rb.MoveRotation (_rb.rotation + turn);
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