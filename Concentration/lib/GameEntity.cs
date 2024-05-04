using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Concentration.lib;

public interface GameEntity {
    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch, GameTime gameTime);

}