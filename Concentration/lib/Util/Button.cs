
using System;
using System.Net.NetworkInformation;
using Concentration.lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Button : IGameEntity{

    Action action;
    SingledInput input;
    ScaledSprite sprite;

    public Button(SingledInput input, Action action, ScaledSprite sprite) {
        this.sprite = sprite;
        this.input = input;
        this.action = action;
    }
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        sprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
        if (sprite.GetSpace().Contains(Inputs.GetMouseCoords()) && input.Get()) {
            action();
        }
    }
}