using System;
using System.Collections.Generic;
using Concentration.lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameManager {

    //There are really only 3 stages of the game and this indicates it.
    private int turnStep = 0;
    private int maxSteps = 3;

    //used to count the amount of turns that have passed.
    public int turns = 0;

    //Changes depending on button press / game conditions
    public GameState state = GameState.START;
    private DelayedAction stepper;    
    private CardManager cardManager;
    private MenuManager menuManager;
    private ScoreManager scoreManager;
    private List<Button> menuButtons = new List<Button>(); 
    
    public GameManager() {
        
        //Create a button for our menu here: the button class I created allows us to pass a lambda function
        //that will execute when the button is pressed along with info for the visual elements of the button
        menuButtons.Add(
            new Button(
            Inputs.MouseLeft,
            () => state = GameState.PLAYING,
            new ScaledSprite(
                SpriteStore.GetSprite("ConcentrationPlayButton"),
                (Constants.DisplayConstants.kDisplayWidth - Constants.GameConstants.kStartButtonWidth) / 2,
                (Constants.DisplayConstants.kDisplayHeight - Constants.GameConstants.kStartButtonHeight) / 2,
                Constants.GameConstants.kStartButtonWidth,
                Constants.GameConstants.kStartButtonHeight
            )
          )  
        );

        //Initialize all entity managers
        this.scoreManager = new ScoreManager();
        this.menuManager = new MenuManager(menuButtons);
        this.cardManager = new CardManager(SpriteStore.GetSprite("CuteCardsPixel"));
        cardManager.ResetCardStates();
        //I had to make this a delayed action so that cards would not immediately flip back over when guessed
        stepper = new DelayedAction(() => turnStep++);
    }

    //Updates the menu
    public void ExecuteMenuLogic(GameTime gameTime) {
        menuManager.UpdateEntities(gameTime);
        if (state == GameState.PLAYING) {
            cardManager.Initialize();
            menuManager.ClearMenu();
        }
    }

    //Executes the draws
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
        if (state == GameState.START) {
            menuManager.Draw(spriteBatch, gameTime);
        } else if (state == GameState.PLAYING) {
            cardManager.Draw(spriteBatch, gameTime);
            scoreManager.Draw(spriteBatch, gameTime);
        }
    }

    //Manages all of the game logic (there isn't much of it) in a switch case for several states
    public void ExecuteGameLogic(GameTime gameTime) {

        if (cardManager.GetCardsRemaining() == 0) {
            Console.WriteLine("Game is finished");
            Console.WriteLine("The game took " + turns + " turns.");
        }

        switch (turnStep % maxSteps) {
            // Check if there are any cards left, otherwise reset remaining cards and continue
            case 0:
            if (cardManager.GetCardsRemaining() < 1) {
                state = GameState.END;
                break;
            } else {
                cardManager.ResetCardStates();
                stepper.Run();
                break;
            }
            
            // Wait until two cards are selected then continue
            case 1:
            if (cardManager.TwoCardsSelected()) {
                stepper.RunWithDelay(gameTime, 1.2);
            }
            break;

            // Despawn cards if they are scoreable, other wise reset them
            case 2:

            if (cardManager.CheckFlippedCardsSimilar()) {
                cardManager.DespawnFlippedCards();
                scoreManager.Update(true);
            } else {
                cardManager.ResetCardStates();
                scoreManager.Update(false);
            }
            turns++;
            Console.WriteLine("Current Score:  " + scoreManager.GetScore());
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