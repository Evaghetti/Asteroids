using Asteroids.Framework;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids {
    class Meteoro : GameObject {
        private static readonly float velocidade = 5f;
        private /*readonly*/ float angulo;

        private Animation animations;
        private Sprite sprite;

        public bool PodeMultiplicar { get; } = false;

        public Meteoro(float angulo, Vector2f position = default) : base(position, new Vector2f(256f, 256f) * .25f, new Vector2f(-256f, -256f) * .125f) {
            this.angulo = angulo;
            if (position == default) {
                PodeMultiplicar = true;
                this.position = new Vector2f(320f - MathF.Cos(AnguloRad) * 320f, 240f - MathF.Sin(AnguloRad) * 240f);
            }

            sprite = new Sprite();
            sprite.Rotation = angulo;
            sprite.Origin = new Vector2f(256f, 256f) * .5f;
            sprite.Scale *= .25f;

            animations = new Animation("Imagens/meteoros.png", 256, 256, 8, 8);
            animations.AplicarTextura(ref sprite);
            animations.TempoEspera = 0.05f;
        }

        public override void Draw(RenderTarget target) {
            animations.AplicarFrame(ref sprite);

            target.Draw(sprite);
            base.Draw(target);
        }

        public override void Update(float deltaTime) {
            animations.Update(deltaTime);

            position.X += MathF.Cos(AnguloRad) * velocidade;
            position.Y += MathF.Sin(AnguloRad) * velocidade;

            sprite.Position = position;
            sprite.Rotation = angulo;
        }

        public float AnguloRad { get => (angulo - 90f) * 0.0174533f; }
        public Vector2f Position { get => position; }
    }
}
