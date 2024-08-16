using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Graphics;

public static class SpriteStore {
    private static Dictionary<string, Texture2D> SpriteRegistry = new Dictionary<string, Texture2D>();
    private static Dictionary<string, SpriteFont> FontRegistry = new Dictionary<string, SpriteFont>();

    public static void RegisterSprite(string name, Texture2D texture) {
        SpriteRegistry.Add(name, texture);
    }

     public static void RegisterFont(string name, SpriteFont font) {
        FontRegistry.Add(name, font);
    }

    public static Texture2D GetSprite(string name) {
        Texture2D texture = SpriteRegistry[name];
        if (texture != null) {
            return texture;
        } else {
            throw new System.Exception();
        }
     }
     public static SpriteFont GetFont(string name) {
        SpriteFont font = FontRegistry[name];
        if (font != null) {
            return font;
        } else {
            throw new System.Exception();
        }
     }
}