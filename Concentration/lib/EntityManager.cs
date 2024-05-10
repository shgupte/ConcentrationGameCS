using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Concentration.lib;

public class EntityManager : ISystemManager {

    private readonly List<IGameEntity> m_LiveEntities = new List<IGameEntity>();
    private readonly List<IGameEntity> m_EntitiesToAdd = new List<IGameEntity>();
    private readonly List<IGameEntity> m_EntitiesToRemove = new List<IGameEntity>();


    public void Update(GameTime gameTime) {

        foreach (IGameEntity entity in m_LiveEntities) {
            if (m_EntitiesToRemove.Contains(entity)) {
                continue;
            }
            entity.Update(gameTime);
        }

        foreach (IGameEntity entity in m_EntitiesToAdd) {
            if (entity != null) m_LiveEntities.Add(entity);
        }

        foreach (IGameEntity entity in m_EntitiesToRemove) {
            if (entity != null) m_LiveEntities.Remove(entity);
        }

        m_EntitiesToAdd.Clear();
        m_EntitiesToRemove.Clear();
    
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
        foreach(IGameEntity entity in m_LiveEntities) {
            entity.Draw(spriteBatch, gameTime);
        }
    }

    public void RegisterEntity(IGameEntity entity) {
        m_LiveEntities.Add(entity);
    }

    public IEnumerable<T> queryEntitiesOfType<T>() where T : IGameEntity {
        return m_LiveEntities.OfType<T>();
    }

}