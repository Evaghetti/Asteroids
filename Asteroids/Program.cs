using System;
using SFML.Graphics;

namespace Asteroids {
    class Program {
        static void Main(string[] args) {
            Engine engine = new Engine("Asteroids C#");
            engine.Run();
        }
    }
}
