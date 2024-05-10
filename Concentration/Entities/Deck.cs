using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using Concentration.Entities;
using Microsoft.Xna.Framework.Graphics;

//Should this be an entity?
public class Deck {
    private List<Card> deck;
    private Texture2D spritesheet;

    public Deck(Texture2D spritesheet) {
        this.spritesheet = spritesheet;
        this.deck = generateDeck();
        deck.Shuffle();
    }

    private List<Card> generateDeck() {
       
       List<Card> deck = new List<Card>();
       var suits = EnumUtil.GetValues<CardSuit>();
       foreach (var suit in suits) {
        Console.WriteLine("Building deck stage 1...");
            for (int i = 1; i <= 13; i++){
                Console.WriteLine("Building deck stage 2...");
                deck.Add(new Card(suit, i, spritesheet));
            }
       }
       return deck;
    }

    public List<Card> get() {
        return deck;
    }

}