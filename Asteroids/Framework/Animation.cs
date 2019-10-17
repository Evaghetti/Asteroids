using System;
using System.Collections.Generic;
using System.Text;

using SFML.Graphics;

namespace Asteroids.Framework {
    class Animation {
        private readonly Dictionary<string, Intervalo> animations;
        private readonly List<IntRect> frames;
        private readonly Texture textura;
        private string animationAtual;
        private float tempoPassado;

        private IntRect FrameAtual { get => frames[animations[animationAtual].frameAtual]; }
        private Intervalo IntervaloAtual { get => animations[animationAtual]; set => animations[animationAtual] = value; }

        public float TempoEspera { get; set; }

        public Animation(string caminho, int larguraSprite, int alturaSprite, int quantSpriteX, int quantSpriteY) {
            animations = new Dictionary<string, Intervalo>();
            frames = new List<IntRect>();

            for (int y = 0; y < alturaSprite * quantSpriteY; y += alturaSprite)  {
                for (int x = 0; x < larguraSprite * quantSpriteX; x += larguraSprite)
                    frames.Add(new IntRect(x, y, larguraSprite, alturaSprite));
            }

            animationAtual = AdicionarIntervalo("all", 0, frames.Count);
            textura = TextureManager.Carregar(caminho);
            tempoPassado = 0f;
        }

        public string AdicionarIntervalo(string nome, int inicio, int fim) {
            if (inicio < 0 || fim > frames.Count || animations.ContainsKey(nome))
                throw new ArgumentException($"Erro ao cadastrar a animação {nome}");

            animations.Add(nome, new Intervalo(inicio, fim));
            return nome;
        }

        public void TrocarAnimation(string nome) {
            if (!animations.ContainsKey(nome))
                throw new ArgumentException($"Não existe animação {nome}");

            animationAtual = nome;
        }

        public void Update(float deltaTime) {
            tempoPassado += deltaTime;

            if (tempoPassado >= TempoEspera) {
                Intervalo intervaloModificar = IntervaloAtual;

                intervaloModificar.frameAtual++;
                if (intervaloModificar.frameAtual >= intervaloModificar.fim)
                    intervaloModificar.frameAtual = intervaloModificar.inicio;
                IntervaloAtual = intervaloModificar;

                tempoPassado = 0f;
            }
        }

        public void AplicarTextura(ref Sprite alvo) {
            alvo.Texture = textura;
            AplicarFrame(ref alvo);
        }

        public void AplicarFrame(ref Sprite alvo) {
            alvo.TextureRect = FrameAtual;
        }

        public bool Terminou => IntervaloAtual.frameAtual + 1 >= IntervaloAtual.fim;
        
        private struct Intervalo {
            public int inicio;
            public int fim;
            public int frameAtual;

            public Intervalo(int inicio, int fim) {
                this.inicio = inicio;
                this.fim = fim;

                frameAtual = this.inicio;
            }
        }
    }
}
