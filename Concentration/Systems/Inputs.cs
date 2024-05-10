
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public static class Inputs {
   
   public static Point GetMouseCoords() {
        int x = Mouse.GetState().X;
        int y = Mouse.GetState().Y;
        return new Point(x, y);
   }

   public static bool GetMouseLeftPressed() {
        return (Mouse.GetState().LeftButton == ButtonState.Pressed);
   }

    public static bool GetMouseLeftReleased() {
        return (Mouse.GetState().LeftButton == ButtonState.Released);
   }

    public static bool GetMouseRightPressed() {
        return (Mouse.GetState().LeftButton == ButtonState.Pressed);
   }

   public static bool GetMouseRightReleased() {
        return (Mouse.GetState().LeftButton == ButtonState.Pressed);
   }
}