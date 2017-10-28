using Assets.Codes;
using UnityEngine;

namespace Codes {
    public class Gun: MonoBehaviour {
        private const float FireCooldown = 1f;
        private float _lastfire;

        public void Fire () {
            float time = Time.time;
            if (time < _lastfire + FireCooldown) { return; }

            _lastfire = time;
            Game.Bullets.ForceSpawn(
                transform.position + transform.up * 0.7f,
                transform.rotation,
                transform.up * 4f,
                time + Bullet.Lifetime);
            Debug.Log("Shoot");
        }
    }
}