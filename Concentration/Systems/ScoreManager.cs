
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.ConstrainedExecution;
using System;
using System.Runtime.InteropServices;

//not sure if this class should inherit from entity manager
public class ScoreManager {

    private int points = 0;
    private int consecutive = 0;

    private Vector2 position = new Vector2(0, 0);

    public void Update(Boolean cardsMatched) {
        if (cardsMatched) {
            consecutive += 1;
            points += consecutive;
        } else {
            consecutive = 0;
        }
    }

    public int GetScore() {
        return points;
    }   

    public void Reset() {
        points = 0;
        consecutive = 0;
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
         position = new Vector2(
            (int) Constants.DisplayConstants.kDisplayWidth * 0.05f * Scaling.Scale,
            (int) Constants.DisplayConstants.kDisplayHeight * 0.05f * Scaling.Scale
        );
        spriteBatch.DrawString(SpriteStore.GetFont("font"), "Score: " + points, position, Color.White);
    }

}