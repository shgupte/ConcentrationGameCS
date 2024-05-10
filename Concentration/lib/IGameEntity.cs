using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Concentration.lib;

public interface IGameEntity {
    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch, GameTime gameTime);

}