using System;
using System.Collections.Generic;
using Concentration.lib;
using Microsoft.Xna.Framework;

public class GameManager {

    private int turnStep = 0;
    private int maxSteps = 3;
    public int turns = 0;
    public GameState state = GameState.START;
    private DelayedAction stepper;    
    private CardManager cardManager;
    private MenuManager menuManager;
    private List<Button> menuButtons = new List<Button>(); 
    
    public GameManager(CardManager manager) {
        
        menuButtons.Add(
            new Button(
            Inputs.MouseLeft,
            ()=> state = GameState.PLAYING,
            new ScaledSprite(
                SpriteStore.GetSprite("Button"),
                (int) Constants.DisplayConstants.kDisplayWidth / 2,
                (int) Constants.DisplayConstants.kDisplayHeight / 2,
                50,
                50,
                3
            )
          )  
        );

        this.menuManager = new MenuManager(menuButtons);
        this.cardManager = manager;
        cardManager.ResetCardStates();
        stepper = new DelayedAction(() => turnStep++);
    }

    public void ExecuteMenuLogic(GameTime gameTime) {
        menuManager.UpdateEntities(gameTime);
        if (state == GameState.PLAYING) {
            cardManager.Initialize();
            menuManager.ClearMenu();
        }
        
    }

    public void ExecuteGameLogic(GameTime gameTime) {

        if (cardManager.GetCardsRemaining() == 0) {
            Console.WriteLine("Game is finished");
            Console.WriteLine("The game took " + turns + " turns.");
        }

        switch (turnStep % maxSteps) {
            case 0:
            Console.WriteLine("Step 0");
            if (cardManager.GetCardsRemaining() < 1) {
                state = GameState.END;
                break;
            } else {
                cardManager.ResetCardStates();
                stepper.Run();
                break;
            }
            
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

    public void ExecuteEndLogic(GameTime gameTime) {

    }

    public void Update(GameTime gameTime) {
        cardManager.UpdateEntities(gameTime);
        cardManager.UpdateCardLocks();
        if (state == GameState.START) {
            ExecuteMenuLogic(gameTime);
        } else if (state == GameState.PLAYING) {
            ExecuteGameLogic(gameTime);
        } else if (state == GameState.END) {
            ExecuteEndLogic(gameTime);
        }
    }
}