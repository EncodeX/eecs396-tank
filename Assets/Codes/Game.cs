using UnityEngine;

namespace Codes {
    public class Game : MonoBehaviour {
        /// <summary>
        /// The game context.
        /// A pointer to the currently active game (so that we don't have to use something slow like "Find").
        /// </summary>
        public static Game Ctx;


        internal void Start() {
            Ctx = this;
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