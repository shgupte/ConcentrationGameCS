using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Concentration.lib;
using System.Data;
using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;

namespace Concentration.Entities;
public enum CardSuit {
    SPADE,
    CLUB,
    HEART,
    DIAMOND
}
public class Card : GameEntity {

    int height = Constants.GameConstants.kCardHeight;
    int width = Constants.GameConstants.kCardWidth;

    Vector2 position = new Vector2(0, 0);

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
    
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.Draw(spritesheet, position, getSheetSpace(), Color.White);
    }

    public void Update(GameTime gameTime)
    {
       
    }
}