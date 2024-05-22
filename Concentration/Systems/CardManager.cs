
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Concentration.Entities;
using Concentration.lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/** This class sets up all of the cards for play and manages their states. */
public class CardManager : EntityManager
{
    //Constants are used for card visual setup
    const float scale = Constants.GameConstants.kCardScale;
    const int xOffset = 
        (Constants.DisplayConstants.kDisplayWidth - (int) (13*(scale * 25 + 2) - 2)) / 2;
    const int yOffset =
        (Constants.DisplayConstants.kDisplayHeight - (int) (4*(scale * 36 + 2) - 2)) / 2;
    private Deck deck;

    //Keeps track of the cards that are currently flipped
    private List<Card> flippedCards = new List<Card>();

    //Created a deck of 52 cards when initialized.
    public CardManager(Texture2D spritesheet) {
        this.deck = new Deck(spritesheet);
    }

    //Places cards across the screen at equal distance in order to set up the game
    public void Initialize() {
        int yInterval = (int)(scale * 36) + 2; //38;
        int xInterval = (int)(scale * 25) + 2;//27;
        int cardsInRow = 13;
        Console.WriteLine("Working...");
        int x = 0 + xOffset;
        int y = 0 + yOffset;
        int i = 1;
        foreach (Card card in deck.get()) {
            card.setPosition(new Vector2(x, y));
            RegisterEntity(card);
            x += xInterval; 
            if (i % cardsInRow == 0) {
                x = 0 + xOffset;
            }
            if (i % cardsInRow == 0) {
                y += yInterval;
            }
            i++;
        }
    }

    //Prevent cards from being flipped
    private void LockCards() {
        foreach (Card card in queryEntitiesOfType<Card>()) {
            card.Lock();
        }
    }

    //Allow cards to be flipped
    private void UnlockCards() {
        foreach (Card card in queryEntitiesOfType<Card>()) {
            card.Unlock();
        }
    }

    //Resets all card states
    public void ResetCardStates() {
        flippedCards.Clear();
        foreach (Card card in queryEntitiesOfType<Card>()) {
            card.Unlock();
            card.Hide();
        }
    }

    public void DespawnFlippedCards() {
        /*foreach (Card card in queryEntitiesOfType<Card>()) {
            if (card.state == CardState.FLIPPED) {
                DespawnEntity(card);
            }
        }*/
        foreach (Card card in flippedCards) {
            DespawnEntity(card);
        }
    }

    //Determine if the two cards in the flipped cards list are scoreable
    public bool CheckFlippedCardsSimilar() {
        if (flippedCards.Count != 2) {
            return false;
        } 

        if ((flippedCards.ElementAt(0).color == flippedCards.ElementAt(1).color)
            && (flippedCards.ElementAt(0).number == flippedCards.ElementAt(1).number)) {
            return true;
        } else {
            return false;
        }
    }


    //How many cards are still left on the table
    public int GetCardsRemaining() {
        return GetLiveEntitiesCount();
    }

    //Determine when two cards have been selected by the player
    public bool TwoCardsSelected() {
         int selected = 0;

         foreach (Card card in queryEntitiesOfType<Card>()) {
            if (card.state == CardState.FLIPPED) {
                selected++;
            }
        }
        return (selected > 1);

        //return (flippedCards.Count == 2);
    }

    //Update card states
    public void UpdateCardLocks() {
        IEnumerable<Card> cards = queryEntitiesOfType<Card>();
        foreach (Card card1 in cards) {
            if (card1.state == CardState.FLIPPED && !flippedCards.Contains(card1)) {
                flippedCards.Add(card1);
            } 
        }
        if (flippedCards.Count > 1) {
            LockCards();
        }
    }
}
