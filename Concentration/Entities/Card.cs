using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Concentration.lib;
using System.Data;
using Microsoft.VisualBasic;
using System;

namespace Card;

public enum CardSuit {
    SPADE,
    CLUB,
    HEART,
    DIAMOND
}
public class Card : GameEntity {

    public CardSuit suit;
    public int number;
    public Color color; 
    public Card(CardSuit suit, int number) {
        this.suit = suit;
        this. number = number;
        number = Math.Clamp(number, 1, 13);
        
        if (suit == CardSuit.SPADE || suit == CardSuit.CLUB) {
            this.color = Color.Black;
        } else {
            this.color = Color.Red;
        }
    }

    private Rectangle getSheetSpace() {
        //Temporary code - this will have to return the spritesheet valuse based on card vals.
        return new Rectangle(
            0,
            0,
            100,
            100
        );
    }
    
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        
    }

    public void Update(GameTime gameTime)
    {
       
    }
}