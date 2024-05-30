using System;
using System.Net.Sockets;
using GoOutGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GoOutGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private State _currentState;
    private State _nextState;
    private Texture2D _img;

    private Song song;
    private int _virtualW = 1440;
    private int _virtualH = 900;
    private Rectangle windowClientBounds;

    public Matrix GetScaleMatrix()
    {
        var skaleX = (float)_graphics.PreferredBackBufferWidth / _virtualW;
        var skaleY = (float)_graphics.PreferredBackBufferHeight / _virtualH;
        return Matrix.CreateScale(skaleX, skaleY, 1.0f);
    }
    
    public Game1()
    {
        _graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public float[] widthHeight()
    {
        return new float[] { _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight};
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        //_graphics.PreferredBackBufferWidth = 1440;
        //_graphics.PreferredBackBufferHeight = 900;
       _graphics.PreferredBackBufferWidth = 1980;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new (GraphicsDevice);
        song = Content.Load<Song>("audio");
        MediaPlayer.Play(song);
        MediaPlayer.IsRepeating = true;
        MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        _currentState = new MenuState(this, GraphicsDevice, Content);
        _currentState.LoadContent();
        _nextState = null;

        // TODO: use this.Content to load your game content here
    }

    void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
    {
        MediaPlayer.Volume -= 0.1f;
    }

    

    protected override void UnloadContent() { }

    protected override void Update(GameTime gameTime)
    {

        if (_nextState != null)
        {
            _currentState = _nextState;
            _currentState.LoadContent();

            _nextState = null;
        }
        _currentState.Update(gameTime);
        _currentState.PostUpdate(gameTime);
        
        
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    public void ChangeState(State state)
    {
        _nextState = state;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _currentState.Draw(gameTime,_spriteBatch);
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}