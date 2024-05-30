using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class Room4 : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private int Counter;
    private float timer;
    public Room4(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        random = new Random();
        var settingsButtonTexture = _content.Load<Texture2D>("Controls/SettingsButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        var arrowLeftBottonTexture = _content.Load<Texture2D>("Controls/ArrowLeft");
        var arrowRightBottonTexture  = _content.Load<Texture2D>("Controls/ArrowRight");
        var hintButtonTexture = _content.Load<Texture2D>("Controls/hint");
        var TVButtonTexture = _content.Load<Texture2D>("Controls/TVTexture");
        var TVButton = new Button(TVButtonTexture, buttonFont) { Position = new (635, 670), Text = "", };
        TVButton.Click += TVButtonClick;
        var settingsButton = new Button(settingsButtonTexture, buttonFont)
        {
            Position = new(1390, 40),
            Text = ""
        };
        settingsButton.Click += SettingsButtonClick;
        
        var arrowLeftBotton = new Button(arrowLeftBottonTexture, buttonFont)
        {
            Position = new(50, 500),
            Text = ""
        };
        arrowLeftBotton.Click += ArrowLeftBottonClick;
        
        var arrowRightButton= new Button(arrowRightBottonTexture, buttonFont)
        {
            Position = new(1390, 500),
            Text = ""
        };
        arrowRightButton.Click += ArrowRightBottonClick;

        var hintButton = new Button(hintButtonTexture, buttonFont) { Position = new(200, 800), Text = "" };
        hintButton.Click += hintButtonClick;
        
        _components = new() { arrowLeftBotton,arrowRightButton,settingsButton,hintButton,TVButton };
    }

    private void TVButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new TVQuest(_game,_graphicsDevice,_content));
    }

    private void hintButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Hint(_game,_graphicsDevice,_content));
    }
    private void ArrowRightBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new GameState(_game,_graphicsDevice,_content));
    }

    private void ArrowLeftBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Room3(_game,_graphicsDevice,_content));
    }
    
    private void SettingsButtonClick(object sender, EventArgs e)
    {
        Globals.location = new Room4(_game, _graphicsDevice, _content);
        _game.ChangeState(new SettingsState(_game, _graphicsDevice, _content));
    }

    public override void LoadContent()
    {
            gameBackground = _content.Load<Texture2D>("Backgrounds/LivingRoom");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0,0),Color.White);
        foreach (var component in _components)
        {
            component.Draw(gameTime,spriteBatch);
        }
        spriteBatch.End();
        
    }

    public override void PostUpdate(GameTime gameTime)
    {
    }

    public override void Update(GameTime gameTime)
    {
        if( Keyboard.GetState().IsKeyDown(Keys.Escape)) 
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}