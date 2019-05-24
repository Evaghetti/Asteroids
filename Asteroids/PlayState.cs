using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Asteroids
{
    class PlayState : GameState {

        private Nave navezinha;
        private Texture texturaFundo;
        private Sprite fundo;

        private List<Framework.GameObject> projeteis;

        public PlayState(RenderWindow window) : base(window) {
            navezinha = new Nave(new SFML.System.Vector2f(50f, 50f));
            texturaFundo = new Texture("C:\\Users\\Enzo\\Programas\\Asteroids\\Asteroids\\Asteroids\\Imagens\\space-pure.jpg");
            fundo = new Sprite(texturaFundo);
            projeteis = new List<Framework.GameObject>();
        }

        public override void Update() {
            float deltaTime = GetDeltaTime();

            navezinha.Update(deltaTime);
            if (navezinha.Atirou)
                projeteis.Add(new Disparo(navezinha.Position, .05f, navezinha.AnguloRad));

            for (int i = 0; i < projeteis.Count; i++) {
                projeteis[i].Update(deltaTime);

            }
        }

        public override void Draw() {
            window.Clear();
            window.Draw(fundo);
            navezinha.Draw(window);
            for (int i = 0; i < projeteis.Count; i++)
                projeteis[i].Draw(window);

            window.Display();
        }
    }
}
