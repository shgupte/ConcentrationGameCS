using System;
using System.Collections.Generic;
using Concentration.lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameManager {

    private int turnStep = 0;
    private int maxSteps = 3;
    public int turns = 0;
    public GameState state = GameState.START;
    private DelayedAction stepper;    
    private CardManager cardManager;
    private MenuManager menuManager;
    private List<Button> menuButtons = new List<Button>(); 
    
    public GameManager() {
        
        //Make this something that is actually readable
        menuButtons.Add(
            new Button(
            Inputs.MouseLeft,
            ()=> state = GameState.PLAYING,
            new ScaledSprite(
                SpriteStore.GetSprite("ConcentrationPlayButton"),
                (Constants.DisplayConstants.kDisplayWidth - 128) / 2,
                (Constants.DisplayConstants.kDisplayHeight - 64) / 2,
                128,
                64
            )
          )  
        );

        this.menuManager = new MenuManager(menuButtons);
        this.cardManager = new CardManager(SpriteStore.GetSprite("CuteCardsPixel"));
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

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
        if (state == GameState.START) {
            menuManager.Draw(spriteBatch, gameTime);
        } else if (state == GameState.PLAYING) {
            cardManager.Draw(spriteBatch, gameTime);
        }
    }

    //Manages all of the game logic (there isn't much of it) in a switch case for several states
    public void ExecuteGameLogic(GameTime gameTime) {

        if (cardManager.GetCardsRemaining() == 0) {
            Console.WriteLine("Game is finished");
            Console.WriteLine("The game took " + turns + " turns.");
        }

        switch (turnStep % maxSteps) {
            case 0:
            //Console.WriteLine("Step 0");
            if (cardManager.GetCardsRemaining() < 1) {
                state = GameState.END;
                break;
            } else {
                cardManager.ResetCardStates();
                stepper.Run();
                break;
            }
            
            case 1:
            //Console.WriteLine("Step 1");
            if (cardManager.TwoCardsSelected()) {
                stepper.RunWithDelay(gameTime, 1.2);
            }
            break;

            case 2:
            //Console.WriteLine("Step 2");
            if (cardManager.CheckFlippedCardsSimilar()) {
                cardManager.DespawnFlippedCards();
            } else {
                cardManager.ResetCardStates();
            }
            turns++;
            Console.WriteLine("This many turns have passed: " + turns);
            stepper.Run();
            break;

            default:
            break;

        }
    }

    public void ExecuteEndLogic(GameTime gameTime) {
        Console.WriteLine("You took " + turns + " to finsih match all of the pairs.");
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