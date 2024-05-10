using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Concentration.lib;
using System.Data;
using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using NOptional;
using System.Runtime.InteropServices;

namespace Concentration.Entities;
public enum CardSuit {
    SPADE,
    CLUB,
    HEART,
    DIAMOND
}
//At some point I should rewrite some of these definitions to make getters and setters consistent.
public class Card : IGameEntity {
    bool cardIsSelected {get; set;} = false;
    bool cardIsHovered {get; set;} = false;
    const int height = 36;
    const int width = 25;
    IOptional<Vector2> position = Optional.Empty<Vector2>();
    private Texture2D spritesheet;
    public CardSuit suit;
    public int number;
    public Color color; 

    public Card(CardSuit suit, int number, Texture2D spritesheet) {
        this.spritesheet = spritesheet;
        this.suit = suit;
        this. number = number;
        number = Math.Clamp(number, 1, 13);
        
        if (suit == CardSuit.SPADE || suit == CardSuit.CLUB) {
            this.color = Color.Black;
        } else {
            this.color = Color.Red;
        }
    }

    //Cuts a sprite out from the spritesheet. This method is confirmed to work correctly.
    private Rectangle getSheetSpace() {
        int px, py = 0;

        switch (suit) {
            case CardSuit.CLUB:
                py = 0;
                break;
            case CardSuit.DIAMOND:
                py = 1 * height + 1;
                break;
            case CardSuit.SPADE:
                py = 2 * height + 1;
                break;
            case CardSuit.HEART:
                py = 3 * height + 1;
                break;
        }
        
        px = width * (number - 1);

        return new Rectangle(px, py, width, height);
    }

    public Card withPosition(Vector2 pos) {
        position = Optional.Of(pos);
        return this;
    }

    public void setPosition(Vector2 pos) {
        position = Optional.Of(pos);
    }   
    
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (position.IsEmpty()) {
            return;
        }

        spriteBatch.Draw(spritesheet, position.GetValueOrElse(()=> new Vector2(0, 0)), getSheetSpace(), Color.White);
    }

    public void Update(GameTime gameTime)
    {
       
    }
}