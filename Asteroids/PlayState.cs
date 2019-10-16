using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Asteroids
{
    class PlayState : GameState {

        private Nave navezinha;
        private Texture texturaFundo;
        private Sprite fundo;

        private List<Meteoro> meteoros;
        private List<Framework.GameObject> projeteis;

        private float tempoSpawnMeteoro = 0f;
        private readonly float limiteTempoSpawnMeteoro = 1f;

        private Random random;

        public PlayState(RenderWindow window) : base(window) {
            meteoros = new List<Meteoro>();
            projeteis = new List<Framework.GameObject>();
            navezinha = new Nave(new SFML.System.Vector2f(50f, 50f));
            texturaFundo = new Texture("Imagens/space-pure.jpg");
            random = new Random();
            fundo = new Sprite(texturaFundo);
        }

        public override void Update() {
            float deltaTime = GetDeltaTime();

            tempoSpawnMeteoro += deltaTime;
            if (tempoSpawnMeteoro >= limiteTempoSpawnMeteoro) {
                float anguloMovimento = (float)random.NextDouble() * 360f;

                meteoros.Add(new Meteoro(anguloMovimento));

                tempoSpawnMeteoro = 0f;
            }
            navezinha.Update(deltaTime);
            
            if (navezinha.Atirou)
                projeteis.Add(new Disparo(navezinha.Position, .05f, navezinha.AnguloRad));

            for (int i = 0; i < meteoros.Count; i++)
                meteoros[i].Update(deltaTime);

            for (int i = 0; i < projeteis.Count; i++) {
                projeteis[i].Update(deltaTime);

                if (projeteis[i].ForaDaTela) {
                    projeteis.Remove(projeteis[i]);
                    i--;
                }
            }
        }

        public override void Draw() {
            window.Clear();
            window.Draw(fundo);
            navezinha.Draw(window);
            for (int i = 0; i < projeteis.Count; i++)
                projeteis[i].Draw(window);
            for (int i = 0; i < meteoros.Count; i++)
                meteoros[i].Draw(window);

            window.Display();
        }
    }
}
