
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.ConstrainedExecution;
using System;


public static class Inputs {
   private static DebouncedInput MouseLeft = new DebouncedInput(
     () => Mouse.GetState().LeftButton == ButtonState.Pressed,
     () => Mouse.GetState().LeftButton == ButtonState.Released);

   private static DebouncedInput MouseRight = new DebouncedInput(
     () => Mouse.GetState().RightButton == ButtonState.Pressed,
     () => Mouse.GetState().RightButton == ButtonState.Released);

   public static Point GetMouseCoords() {
        int x = Mouse.GetState().X;
        int y = Mouse.GetState().Y;
        return new Point(x, y);
   }

   public static bool GetMouseLeftClick() {
     Console.WriteLine(MouseLeft.Get());
        return MouseLeft.Get();
   }



    public static bool GetMouseRightClick() {
        return MouseRight.Get();
   }

}