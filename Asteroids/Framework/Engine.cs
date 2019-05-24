using SFML.Graphics;

namespace Asteroids {
    class Engine {

        private RenderWindow window;
        private GameState gameStateAtual;

        public Engine(string nomeJanela, uint largura = 640, uint altura = 480) {
            window = new RenderWindow(new SFML.Window.VideoMode(largura, altura), nomeJanela);

            window.Closed += (_, __) => window.Close();
            window.SetFramerateLimit(60);

            gameStateAtual = new PlayState(window);
        }

        public void Run() {
            while (window.IsOpen && gameStateAtual != null) {
                while (gameStateAtual.Works()) {
                    window.DispatchEvents();
                    gameStateAtual.Update();
                    gameStateAtual.Draw();
                }

                Framework.TextureManager.liberar();
                gameStateAtual = gameStateAtual.QualTrocar();
            }
        }
    }
}
