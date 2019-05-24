using System;
using SFML.Graphics;

namespace Asteroids {
    class Program {
        static void Main(string[] args) {
            RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(640, 480), "Asteroids C#");
            window.Closed += (_, __) => window.Close();

            while (window.IsOpen) {
                window.DispatchEvents();

                window.Clear(Color.Red);
                window.Display();
            }
        }
    }
}
