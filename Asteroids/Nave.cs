using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System;

namespace Asteroids
{
    class Nave : Framework.GameObject {

        private readonly Texture textura;
        private readonly Sprite sprite;
        private Vector2f velocidade;

        private float angulo, aceleration;

        public Nave(Vector2f position) : base(position, new Vector2f(343f, 383f) * .15f) {
            //Mudar dps quando eu descobrir onde que fica os arquivos do projeto ._.
            textura = new Texture("C:\\Users\\Enzo\\Programas\\Asteroids\\Asteroids\\Asteroids\\Imagens\\player.png");
            sprite = new Sprite(textura);
            velocidade = new Vector2f(0f, 0f);

            angulo = 0f;
            aceleration = 5f;

            sprite.Scale *= .15f;
            sprite.Origin = new Vector2f(343f, 383f) * .5f;
        }

        public override void Update(float deltaTime) {
            int dirThrottle = Convert.ToInt32(Keyboard.IsKeyPressed(Keyboard.Key.Up)) - Convert.ToInt32(Keyboard.IsKeyPressed(Keyboard.Key.Down));
            int dirTurn = Convert.ToInt32(Keyboard.IsKeyPressed(Keyboard.Key.Right)) - Convert.ToInt32(Keyboard.IsKeyPressed(Keyboard.Key.Left));

            angulo += (500f * deltaTime) * dirTurn;
            if (dirThrottle != 0) {
                float anguloRadiano = (angulo - 90f) * 0.0174533f;
                velocidade.X += MathF.Cos(anguloRadiano) * dirThrottle * aceleration * deltaTime;
                velocidade.Y += MathF.Sin(anguloRadiano) * dirThrottle * aceleration * deltaTime;
            }
            else
                velocidade *= 0.99f;

            position += velocidade;

            sprite.Position = position;
            sprite.Rotation = angulo;
        }

        public override void Draw(RenderTarget target) {
            target.Draw(sprite);
        }
    }
}
