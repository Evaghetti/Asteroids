using System;
using SFML.Graphics;

namespace Asteroids
{
    class PlayState : GameState {

        public PlayState(RenderWindow window) : base(window) {}

        public override void Update() {
            float deltaTime = GetDeltaTime();

            Console.WriteLine(deltaTime);
        }

        public override void Draw() {
            window.Clear(Color.Red);
            window.Display();
        }
    }
}
