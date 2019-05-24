using System;
using SFML.Graphics;
using SFML.System;

namespace Asteroids {
    abstract class GameState {
        protected RenderWindow window;
        private static Clock relogio = new Clock();
        public GameState(RenderWindow window) {
            this.window = window;
            relogio.Restart();
        }

        public abstract void Update();
        public abstract void Draw();
        public virtual GameState QualTrocar() {
            return null;
        }
        public virtual bool Works() {
            return window.IsOpen;
        }
        public float GetDeltaTime() {
            return relogio.Restart().AsSeconds();
        }
    }
}
