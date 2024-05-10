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
    

    public Game1()
    {
        _graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public int[] widthHeight()
    {
        return new int[] { _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight};
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 1440;
        _graphics.PreferredBackBufferHeight = 900;
        //_graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        //_graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
       // _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
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
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _currentState.Draw(gameTime,_spriteBatch);
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}