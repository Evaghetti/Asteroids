using System;
using System.Diagnostics;
using SFML.Graphics;

namespace Asteroids {
    abstract class GameState {
        protected RenderWindow window;
        private static Stopwatch relogio = new Stopwatch();
        public GameState(RenderWindow window) {
            this.window = window;
            relogio.Start();
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
            relogio.Stop();
            float deltaTime = relogio.ElapsedTicks / 10000f;
            relogio.Reset();
            relogio.Start();
            return deltaTime;
        }
    }
}
