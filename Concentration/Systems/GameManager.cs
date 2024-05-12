using System;
using Concentration.lib;
using Microsoft.Xna.Framework;

public class GameManager {

    private int turnStep = 0;
    private int maxSteps = 3;
    public int turns = 0;
    private DelayedAction stepper;    
    private CardManager cardManager;
    public GameManager(CardManager manager) {
        this.cardManager = manager;
        cardManager.ResetCardStates();
        stepper = new DelayedAction(() => turnStep++);
    }

    public void ExecuteGameLogic(GameTime gameTime) {

        if (cardManager.GetCardsRemaining() == 0) {
            Console.WriteLine("Game is finished");
            Console.WriteLine("The game took " + turns + " turns.");
        }

        switch (turnStep % maxSteps) {
            case 0:
            Console.WriteLine("Step 0");
            cardManager.ResetCardStates();
            stepper.Run();
            break;

            case 1:
            Console.WriteLine("Step 1");
            if (cardManager.TwoCardsSelected()) {
                stepper.RunWithDelay(gameTime, 1.2);
            }
            break;

            case 2:
            Console.WriteLine("Step 2");
            
            if (cardManager.CheckFlippedCardsSimilar()) {
                cardManager.DespawnFlippedCards();
            } else {
                cardManager.ResetCardStates();
            }
            turns++;
            stepper.Run();
            break;

            default:
            break;

        }
    }

    public void Update(GameTime gameTime) {
        cardManager.UpdateEntities(gameTime);
        cardManager.UpdateCardLocks();
        ExecuteGameLogic(gameTime);
    }
}