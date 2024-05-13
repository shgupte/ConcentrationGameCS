using System;
using Concentration.lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Button : IGameEntity{

    Action action;
    SingledInput input;
    Texture2D texture;
    Vector2 position;


    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        throw new NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}