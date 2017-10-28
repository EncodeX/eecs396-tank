using UnityEngine;

namespace Codes {
    public class Game : MonoBehaviour {
        /// <summary>
        /// The game context.
        /// A pointer to the currently active game (so that we don't have to use something slow like "Find").
        /// </summary>
        public static Game Ctx;
        
       // public static ScoreManager Score;  // not implemented yet
//        public static Player Player;
        
        public static BulletManager Bullets;



        
        internal void Start() {
            Ctx = this;
            
            //Score = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
//            Player = GameObject.Find("Player").GetComponent<Player>();
            //Asteroids = GameObject.Find("Spawner").GetComponent<AsteroidManager>();
            Bullets = new BulletManager(GameObject.Find("Bullets").transform);
            Debug.Log("Bullets: " + Bullets);
        }

        // all of this is done so that you can save/load with the Start/Back buttons
        private static string _saveAxis;

        private bool _locked;

        internal void Update() {
        }

        private static bool IsMac() {
            return Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}