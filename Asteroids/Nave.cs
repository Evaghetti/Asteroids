using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System;
using System.Collections.Generic;

namespace Asteroids
{
    class Nave : Framework.GameObject {

        private readonly Texture textura;
        private readonly Sprite sprite;
        private Vector2f velocidade;

        private static readonly float maxTempoPassadoDisparo = .5f;
        public static List<Framework.GameObject> Projeteis {
            private get => Projeteis;
            set {
                if (Projeteis == null)
                    Projeteis = value;
            }
        }

        private float angulo, aceleration, tempoPassadoDisparo = maxTempoPassadoDisparo;
        public Nave(Vector2f position) : base(position, new Vector2f(343f, 383f) * .15f, new Vector2f(-343f, -383f) * .075f) {
            //Mudar dps quando eu descobrir onde que fica os arquivos do projeto ._.
            textura = Framework.TextureManager.Carregar("Imagens/player.png");
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
                float anguloRadiano = AnguloRad;
                velocidade.X += MathF.Cos(anguloRadiano) * dirThrottle * aceleration * deltaTime;
                velocidade.Y += MathF.Sin(anguloRadiano) * dirThrottle * aceleration * deltaTime;
            }
            else
                velocidade *= 0.99f;

            Atirou = Keyboard.IsKeyPressed(Keyboard.Key.Space) && tempoPassadoDisparo >= maxTempoPassadoDisparo;
            if (Atirou)
                tempoPassadoDisparo = 0f;
            else if (tempoPassadoDisparo < maxTempoPassadoDisparo)
                tempoPassadoDisparo += deltaTime;

            position += velocidade;

            sprite.Position = position;
            sprite.Rotation = angulo;
        }

        public override void Draw(RenderTarget target) {
            target.Draw(sprite);
            base.Draw(target);
        }

        public Vector2f Position { get => position; }

        public float AnguloRad { get => (angulo - 90f) * 0.0174533f; }

        public bool Atirou { get; private set; }
    }
}
