using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Concentration.lib;
using Concentration.Entities;
using System;

namespace Concentration;


public class Concentration : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _cardSheet;
    private Texture2D _buttons;
    private CardManager _cardManager;
    private GameManager _gameManager;

    public Concentration() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferHeight = Constants.DisplayConstants.kDisplayHeight;
        _graphics.PreferredBackBufferWidth = Constants.DisplayConstants.kDisplayWidth;
        //
       //  _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;//
        //_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;//Constants.DisplayConstants.kDisplayWidth;
        _graphics.ApplyChanges();
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here
        base.Initialize();

    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _cardSheet = Content.Load<Texture2D>("CuteCardsPixel");
        _buttons = Content.Load<Texture2D>("ConcentrationPlayButton");
        SpriteStore.RegisterSprite("ConcentrationPlayButton", _buttons);
       
        // TODO: use this.Content to load your game content here
        _cardManager = new CardManager(_cardSheet);
       // _cardManager.Initialize();
        _gameManager = new GameManager(_cardManager);

    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        //_cardManager.UpdateEntities(gameTime);
       // _cardManager.UpdateSystem();
       _gameManager.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here'

        //This is test code that will be removed, however, it does seem to work
        //_spriteBatch.Begin();
        //wtf do these arguments even do?
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, null, null, null);
        //_cardManager.Draw(_spriteBatch, gameTime);
        _gameManager.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
