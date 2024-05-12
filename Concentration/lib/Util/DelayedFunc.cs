using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/** Use if a function must only run after a certain time from when it is initially called. This should pretty much always be used following a conditional*/
public class DelayedAction {

    Action action;
    double ?begin = null;

    public DelayedAction(Action action) {
        this.action = action;
    }

    public void RunWithDelay(GameTime gameTime, double delayInSeconds) {
        if (begin == null) {
            begin = gameTime.TotalGameTime.TotalMilliseconds;
        } else if (gameTime.TotalGameTime.TotalMilliseconds - begin > (delayInSeconds * 1000.0)) { 
            Run();
        } 
    }

    public void Run() {
        action();
        Reset();
    }

    private void Reset() {
        begin = null;
    }


}
