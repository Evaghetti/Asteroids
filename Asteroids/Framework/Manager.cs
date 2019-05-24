using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Asteroids.Framework {
    static class TextureManager {
        private static Dictionary<string, Texture> entradas = new Dictionary<string, Texture>();

        public static Texture Carregar(string nome) {
            if (entradas.ContainsKey(nome))
                return entradas[nome];
            Texture novo = new Texture(nome);
            entradas.Add(nome, novo);
            return novo;
        }

        public static void liberar() {
            entradas.Clear();
        }
    }
}
