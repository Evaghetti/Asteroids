using Asteroids.Framework;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids {
    class Meteoro : GameObject {
        private Animation animations;
        private Sprite sprite;

        public Meteoro() : base(new Vector2f(0f, 0f), new Vector2f(50f, 50f)) {
            sprite = new Sprite();
            sprite.Origin = new Vector2f(.5f, .5f);

            animations = new Animation("Imagens/meteoros.png", 256, 256, 8, 8);
            animations.AplicarTextura(ref sprite);
            animations.TempoEspera = 0.05f;
        }

        public override void Draw(RenderTarget target) {
            animations.AplicarFrame(ref sprite);

            target.Draw(sprite);
        }

        public override void Update(float deltaTime) {
            animations.Update(deltaTime);

            sprite.Position = position;
        }
    }
}
