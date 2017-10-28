using System;
using System.Collections.Generic;
using Assets.Codes;
using Assets.Codes;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Codes
{
    /// <summary>
    /// Bullet manager for spawning and tracking all of the game's bullets
    /// </summary>
    public class BulletManager
    {
        private readonly Transform _holder;

        /// <summary>
        /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
        /// </summary>
        private readonly Object _bullet;

        public BulletManager (Transform holder) {
            _holder = holder;
            _bullet = Resources.Load("Bullet");
        }

        // TODO fill me in
        public void ForceSpawn (Vector2 pos, Quaternion rotation, Vector2 velocity, float deathtime) {

            var shinyBullet = (GameObject)Object.Instantiate(_bullet, pos, rotation,_holder); // cast object as GameObject

            shinyBullet.GetComponent<Bullet>().Initialize(velocity,deathtime);  // this is overloaded lol
        }
        
        

        
    }

    /// <summary>
    /// Save data for all bullets in game
    /// </summary>
    public class BulletsData     
    {
        public List<BulletData> Bullets;
    }

    /// <summary>
    /// Save data for a single bullet
    /// </summary>
    public class BulletData
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public float Rotation;
    }
}
