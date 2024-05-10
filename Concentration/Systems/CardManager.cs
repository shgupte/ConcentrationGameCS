
using System;
using System.Threading;
using Concentration.Entities;
using Concentration.lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CardManager : EntityManager
{
    private Deck deck;
    public CardManager(Texture2D spritesheet) {
        this.deck = new Deck(spritesheet);
    }

    //YAY This function works!
    public void Initialize() {
        int yInterval = 38;
        int xInterval = 27;
        int cardsInRow = 13;
        Console.WriteLine("Working...");
        int x = 0;
        int y = 0;
        int i = 1;
        foreach (Card card in deck.get()) {
            card.setPosition(new Vector2(x, y));
            RegisterEntity(card);
            x += xInterval; 
            if (i % cardsInRow == 0) {
                x = 0;
            }
            if (i % cardsInRow == 0) {
                y += yInterval;
            }
            i++;
        }
    }
}