using System;
using SFML.Graphics;

namespace Asteroids
{
    class PlayState : GameState {

        private Nave navezinha;
        public PlayState(RenderWindow window) : base(window) {
            navezinha = new Nave(new SFML.System.Vector2f(50f, 50f));
        }

        public override void Update() {
            float deltaTime = GetDeltaTime();

            navezinha.Update(deltaTime);
        }

        public override void Draw() {
            window.Clear(Color.Red);
            navezinha.Draw(window);
            window.Display();
        }
    }
}
