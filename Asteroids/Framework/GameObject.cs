using SFML.System;
using SFML.Graphics;

namespace Asteroids.Framework {
    abstract class GameObject {
        protected Vector2f position, tamanho;
        private Vector2f offset;

        public GameObject(Vector2f position, Vector2f tamanho, Vector2f offset = default) {
            this.position = position;
            this.tamanho = tamanho;
            this.offset = offset;
        }

        public bool ColidiuCom(GameObject outro) {
            FloatRect minhaCaixa = new FloatRect(position + offset, tamanho), outraCaixa = new FloatRect(outro.position + outro.offset, outro.tamanho);
            return minhaCaixa.Intersects(outraCaixa);
        }

        public bool ForaDaTela {
            get {
                FloatRect minhaCaixa = new FloatRect(position, tamanho), janela = new FloatRect(0f, 0f, 640f, 480f);

                return !janela.Intersects(minhaCaixa);
            }
        }

        public abstract void Update(float deltaTime);
        public virtual void Draw(RenderTarget target) {
            RectangleShape rect = new RectangleShape {
                FillColor = Color.Transparent,
                OutlineColor = Color.Red,
                OutlineThickness = 1f,
                Position = position + offset,
                Size = tamanho
            };

            target.Draw(rect);
        }
    }
}
