using System;
using SFML.Graphics;

namespace Asteroids
{
    class PlayState : GameState {

        private Nave navezinha;
        private Texture texturaFundo;
        private Sprite fundo;
        public PlayState(RenderWindow window) : base(window) {
            navezinha = new Nave(new SFML.System.Vector2f(50f, 50f));
            texturaFundo = new Texture("C:\\Users\\Enzo\\Programas\\Asteroids\\Asteroids\\Asteroids\\Imagens\\space-pure.jpg");
            fundo = new Sprite(texturaFundo);
        }

        public override void Update() {
            float deltaTime = GetDeltaTime();

            navezinha.Update(deltaTime);
        }

        public override void Draw() {
            window.Clear();
            window.Draw(fundo);
            navezinha.Draw(window);
            window.Display();
        }
    }
}
