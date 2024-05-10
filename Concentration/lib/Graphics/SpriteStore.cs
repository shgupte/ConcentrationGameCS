using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Graphics;

public static class SpriteStore {
    private static Dictionary<string, Texture2D> SpriteRegistry = new Dictionary<string, Texture2D>();

    public static void RegisterSprite(string name, Texture2D texture) {
        SpriteRegistry.Add(name, texture);
    }

    public static Texture2D GetSprite(string name) {
        Texture2D texture = SpriteRegistry[name];
        if (texture != null) {
            return texture;
        } else {
            throw new System.Exception();
        }
     }
}