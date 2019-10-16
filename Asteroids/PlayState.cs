﻿using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Asteroids
{
    class PlayState : GameState {

        private Nave navezinha;
        private Texture texturaFundo;
        private Sprite fundo;
        private Meteoro meteoro;

        private List<Framework.GameObject> projeteis;

        public PlayState(RenderWindow window) : base(window) {
            projeteis = new List<Framework.GameObject>();
            navezinha = new Nave(new SFML.System.Vector2f(50f, 50f));
            texturaFundo = new Texture("Imagens/space-pure.jpg");
            fundo = new Sprite(texturaFundo);

            meteoro = new Meteoro();
        }

        public override void Update() {
            float deltaTime = GetDeltaTime();

            navezinha.Update(deltaTime);
            meteoro.Update(deltaTime);

            if (navezinha.Atirou)
                projeteis.Add(new Disparo(navezinha.Position, .05f, navezinha.AnguloRad));

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
            meteoro.Draw(window);

            window.Display();
        }
    }
}
