using System;
using Concentration.lib;
using Microsoft.Xna.Framework;

public class GameManager {

    private int turnStep = 0;
    private int maxSteps = 3;

    public int turns = 0;

    CardManager cardManager;
    public GameManager(CardManager manager) {
        this.cardManager = manager;
        cardManager.ResetCardStates();
    }

    public void ExecuteGameLogic() {

        if (cardManager.GetCardsRemaining() == 0) {
            Console.WriteLine("Game is finished");
            Console.WriteLine("The game took " + turns + " turns.");
        }

        switch (turnStep % maxSteps) {
            case 0:
            Console.WriteLine("Step 0");
            cardManager.ResetCardStates();
            turnStep++;
            break;

            case 1:
            Console.WriteLine("Step 1");
            if (cardManager.TwoCardsSelected()) {
                turnStep++;
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
            turnStep++;
            break;

            default:
            break;

        }
    }

    public void Update(GameTime gameTime) {
        cardManager.UpdateEntities(gameTime);
        cardManager.UpdateCardLocks();
        ExecuteGameLogic();
    }
}