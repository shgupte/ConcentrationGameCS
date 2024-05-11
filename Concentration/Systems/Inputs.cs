
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.ConstrainedExecution;
using System;

/**Static inputs class that is used globally*/
public static class Inputs {

  //Do NOT put any print statement that include uses of SingledInput "Get()" function.
   private static SingledInput MouseLeft = new SingledInput(
     () => Mouse.GetState().LeftButton == ButtonState.Pressed);

   private static SingledInput MouseRight = new SingledInput(
     () => Mouse.GetState().RightButton == ButtonState.Pressed);

   public static Point GetMouseCoords() {
        int x = Mouse.GetState().X;
        int y = Mouse.GetState().Y;
        return new Point(x, y);
   }

   public static bool GetMouseLeftClick() {
        return MouseLeft.Get();
   }

    public static bool GetMouseRightClick() {
        return MouseRight.Get();
   }

}