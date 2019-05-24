﻿using SFML.System;
using SFML.Graphics;

namespace Asteroids.Framework {
    abstract class GameObject {
        protected Vector2f position, tamanho;

        public GameObject(Vector2f position, Vector2f tamanho) {
            this.position = position;
            this.tamanho = tamanho;
        }

        public bool ColidiuCom(GameObject outro) {
            FloatRect minhaCaixa = new FloatRect(position, tamanho), outraCaixa = new FloatRect(outro.position, outro.tamanho);
            return minhaCaixa.Intersects(outraCaixa);
        }

        public bool ForaDaTela {
            get {
                FloatRect minhaCaixa = new FloatRect(position, tamanho), janela = new FloatRect(0f, 0f, 640f, 480f);

                return !janela.Intersects(minhaCaixa);
            }
        }

        public abstract void Update(float deltaTime);
        public abstract void Draw(RenderTarget target);
    }
}
