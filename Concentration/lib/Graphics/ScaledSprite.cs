using Concentration.lib.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ScaledSprite{
        public Texture2D Texture { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int RelativeScale {get; set;}

        //Implement some type of absolute scaling later
        //private int EffectiveScale;

        public Color TintColor { get; set; } = Color.White;

        public ScaledSprite(Texture2D texture, int x, int y, int width, int height, int scale)
        {
            Texture = texture;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            RelativeScale = scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, new Rectangle(X, Y, Width * RelativeScale, Height * RelativeScale), TintColor);

        }

        public void MatchSize(ScaledSprite sprite) {
            this.Height = sprite.Height;
            this.Width = sprite.Width;
            this.RelativeScale = sprite.RelativeScale;
        }

        public Rectangle GetSpace() {
            return new Rectangle(new Point(X, Y), new Point(Width*RelativeScale, Height*RelativeScale));
        }


}