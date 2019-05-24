using System;
using SFML.Graphics;
using SFML.System;

namespace Asteroids
{
    class Disparo : Framework.GameObject {

        private Texture textura;
        private Sprite sprite;
        private float velocidade, anguloRad;
        public Disparo(Vector2f position, float escala, float anguloRad = 0f) : base(position, new Vector2f(500f, 890f) * escala) {
            this.anguloRad = anguloRad;

            textura = new Texture("C:\\Users\\Enzo\\Programas\\Asteroids\\Asteroids\\Asteroids\\Imagens\\laser.png");
            sprite = new Sprite(textura);

            sprite.Rotation = 57.2958f * anguloRad + 90f;
            sprite.Origin = new Vector2f(500f * .5f, 890f * .5f);
            sprite.Scale = new Vector2f(escala, escala);

            velocidade = 1000f;
        }
        public override void Update(float deltaTime) {
            position.X += MathF.Cos(anguloRad) * velocidade * deltaTime;
            position.Y += MathF.Sin(anguloRad) * velocidade * deltaTime;

            sprite.Position = position;
        }

        public override void Draw(RenderTarget target) {
            target.Draw(sprite);
        }
    }
}
