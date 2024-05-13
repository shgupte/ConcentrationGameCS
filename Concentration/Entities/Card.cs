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
using System.Diagnostics.CodeAnalysis;

namespace Concentration.Entities;
public enum CardSuit {
    SPADE,
    CLUB,
    HEART,
    DIAMOND
}

public enum CardState {
    FLIPPED,
    HIDDEN,
    REMOVED
}

//At some point I should rewrite some of these definitions to make getters and setters consistent.
public class Card : IGameEntity {
    const int scale = Constants.GameConstants.kCardScale;
    bool locked = false;
    const int height = 36;
    const int width = 25;
    const int scaledHeight = height * scale;
    const int scaledWidth = width * scale;
    IOptional<Vector2> position = Optional.Empty<Vector2>();
    private Texture2D spritesheet;
    public CardSuit suit;
    public int number;
    public Color color; 
    public CardState state = CardState.HIDDEN;



    public Card(CardSuit suit, int number, Texture2D spritesheet) {
        this.spritesheet = spritesheet;
        this.suit = suit;
        this.number = number;
        number = Math.Clamp(number, 1, 13);
        
        if (suit == CardSuit.SPADE || suit == CardSuit.CLUB) {
            this.color = Color.Black;
        } else {
            this.color = Color.Red;
        }

    }

    //Cuts a sprite out from the spritesheet. This method is confirmed to work correctly.
    private Rectangle getSheetSpace() {
        int px = 0;
        int py = 0;
        Rectangle rect = new Rectangle(new Point(0, 0), new Point(0, 0));

        if (state == CardState.HIDDEN) {
            rect = new Rectangle(14 * width, 3 * height, width, height);
        }
        
        if (state == CardState.FLIPPED) {
            switch (suit) {
            case CardSuit.CLUB:
                py = 0;
                break;
            case CardSuit.DIAMOND:
                py = 1 * height;
                break;
            case CardSuit.SPADE:
                py = 2 * height;
                break;
            case CardSuit.HEART:
                py = 3 * height;
                break;
            }
        
            px = width * (number - 1);
            rect = new Rectangle(px, py, width, height);
        }

        return rect;

    }

    public Card withPosition(Vector2 pos) {
        position = Optional.Of(pos);
        return this;
    }

    public void setPosition(Vector2 pos) {
        position = Optional.Of(pos);
    }   

    public Vector2 GetPosition() {
        return position.GetValueOrElse(() => new Vector2(0, 0));
    }

    public void Flip() {
        state = CardState.FLIPPED;
    }

    public void Hide() {
        state = CardState.HIDDEN;
    }

    public Rectangle GetSpace() {
        if (!position.IsEmpty()) {
            return new Rectangle(GetPosition().ToPoint(), new Point(scaledWidth, scaledHeight));
        } else {
            throw new Exception();
        }
    }

    public bool IsHovered() {
        return GetSpace().Contains(Inputs.GetMouseCoords());
    }

    public void Lock() {
        locked = true;
    }

    public void Unlock() {
        locked = false;
    }

    public void ProcessMouseInput(){
        if (locked) return;
        Point cursor = Inputs.GetMouseCoords();
        if (IsHovered() && state == CardState.HIDDEN && Inputs.GetMouseLeftClick()) {
            this.state = CardState.FLIPPED;
            locked = true;
        } else if (IsHovered() && state == CardState.HIDDEN && !Inputs.GetMouseLeftClick()) {
            //Add card hover outline
        } else if (IsHovered() && state == CardState.FLIPPED && Inputs.GetMouseLeftClick()) {
            this.state = CardState.HIDDEN;
        }
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (position.IsEmpty()) {
            return;
        }
        spriteBatch.Draw(
            spritesheet,
            new Rectangle(new Point((int)GetPosition().X, (int)GetPosition().Y), new Point(scaledWidth, scaledHeight)),
            getSheetSpace(),
            Color.White
        );
    }
    public void Update(GameTime gameTime)
    {       
       ProcessMouseInput();
    }
}