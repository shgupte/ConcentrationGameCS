using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Concentration.lib;
using Concentration.Entities;
using System;
using System.Runtime.InteropServices;

namespace Concentration;


public class Concentration : Game
{
    private GraphicsDeviceManager _graphics;
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;
    private Texture2D _cardSheet;
    private Texture2D _buttons;
    private GameManager _gameManager;
    private Rectangle _targetRect;
    private Matrix _scalingMatrix;

    public Concentration() {
        _scalingMatrix = Matrix.CreateScale(1.0f);
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

           
        
        _graphics.PreferredBackBufferHeight = Constants.DisplayConstants.kWindowHeight;
        _graphics.PreferredBackBufferWidth = Constants.DisplayConstants.kWindowWidth;
        //
       //  _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;//
        //_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;//Constants.DisplayConstants.kDisplayWidth;
        Window.AllowUserResizing = true;
        _graphics.ApplyChanges();

        _renderTarget = new RenderTarget2D(
            GraphicsDevice,
            Constants.DisplayConstants.kDisplayWidth,
            Constants.DisplayConstants.kDisplayHeight 
        );
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here
        base.Initialize();
        CalculateDisplayTarget();
        Scaling.UpdateScaleMatrix(
            Constants.DisplayConstants.kDisplayWidth,
            Constants.DisplayConstants.kDisplayHeight,
            GraphicsDevice
        );
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _cardSheet = Content.Load<Texture2D>("CuteCardsPixel");
        _buttons = Content.Load<Texture2D>("ConcentrationPlayButton");
        SpriteStore.RegisterSprite("ConcentrationPlayButton", _buttons);
        SpriteStore.RegisterSprite("CuteCardsPixel", _cardSheet);
       
        // TODO: use this.Content to load your game content here
        //_cardManager = new CardManager(_cardSheet);
       // _cardManager.Initialize();
        _gameManager = new GameManager();

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
        
        // TODO: Add your drawing code here'

        //This is test code that will be removed, however, it does seem to work
        //_spriteBatch.Begin();
        //CalculateDisplayTarget();

        /*GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, null, null, null);
        _gameManager.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();*/

        //GraphicsDevice.SetRenderTarget(null);

        GraphicsDevice.Clear(Color.CornflowerBlue);

        //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, null, null, null);
        //_spriteBatch.Draw(_renderTarget, _targetRect, Color.White);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Scaling.ScalingMatrix);
        _gameManager.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void CalculateDisplayTarget() {
        //Point size = GraphicsDevice.Viewport.Bounds.Size;
        Point size = new Point(
            Constants.DisplayConstants.kWindowWidth,
            Constants.DisplayConstants.kWindowHeight
        );

        float scaleX = (float) size.X / _renderTarget.Width;
        float scaleY = (float) size.Y / _renderTarget.Height;
        float scale = Math.Min(scaleX, scaleX);
        _targetRect.Width = (int)(_renderTarget.Width * scale);
        _targetRect.Height = (int)(_renderTarget.Height * scale);
        _targetRect.X = (size.X - _targetRect.Width) / 2;
        _targetRect.Y = (size.Y - _targetRect.Height) / 2;
    }
    
}
