using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class Scaling {
    public static Matrix ScalingMatrix = Matrix.CreateScale(1.0f);
    public static float Scale = 1.0f;

    public static void UpdateScaleMatrix(int renderWidth, int renderHeight, GraphicsDevice device) {
        float screenWidth = device.PresentationParameters.BackBufferWidth;
        float screenHeight = device.PresentationParameters.BackBufferHeight;
        float Rx = renderWidth;
        float Ry = renderHeight;

        // Calculate the virtual resolution
       /* if (screenWidth / Dx > screenHeight / Dy) {
            float aspect = screenHeight / Dy;
            Rx = (int)(aspect * Dx);
            Ry = (int)(Dy);
        } else {
            float aspect = screenWidth / Dx;
            Rx = (int)(Dx);
            Ry = (int)(aspect * Dy);
        } */
        
        if (screenWidth / Rx > screenHeight / Ry) {
            Console.WriteLine("Scale: " + screenHeight / Ry);
            ScalingMatrix = Matrix.CreateScale(screenHeight / Ry);
            Scale = screenHeight/Ry;
           // return Matrix.CreateScale(screenHeight / Ry);
        } else {
            Console.WriteLine("Scale: " + screenWidth / Rx);
            ScalingMatrix = Matrix.CreateScale(screenWidth / Rx);
            Scale = screenWidth/Rx;
           // return Matrix.CreateScale(screenWidth / Rx);
        }
        //Console.WriteLine("scale: " + (Rx/(float)Dx));
        //matrix = Matrix.CreateScale(Rx / (float)Dx);

    }   
}