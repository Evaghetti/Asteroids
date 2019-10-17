using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using Asteroids.Framework;
using SFML.Graphics;

namespace Asteroids {
    class Explosao : GameObject {

        private Animation animation;
        private Sprite sprite;

        public Explosao(Vector2f position) : base(position, new Vector2f(256.125f, 251.25f)) {
            sprite = new Sprite {
                Position = position,
                Origin = new Vector2f(256.125f, 251.25f) * .5f,
                Scale = new Vector2f(.75f, .75f)
            };

            animation = new Animation("Imagens/explosao.png", (int)tamanho.X, (int)tamanho.Y, 8, 4) {
                TempoEspera = .01f
            };
            animation.AplicarTextura(ref sprite);
        }

        public override void Update(float deltaTime) {
            animation.Update(deltaTime);
            animation.AplicarFrame(ref sprite);
        }

        public override void Draw(RenderTarget target) {
            target.Draw(sprite);
        }

        public override bool PodeDeletar => animation.Terminou;
    }
}
