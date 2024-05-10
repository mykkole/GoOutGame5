using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class Room2 : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private int Counter;
    private float timer;

    public Room2(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        random = new Random();
        var settingsButtonTexture = _content.Load<Texture2D>("Controls/SettingsButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        var arrowLeftBottonTexture = _content.Load<Texture2D>("Controls/ArrowLeft");
        var arrowRightBottonTexture = _content.Load<Texture2D>("Controls/ArrowRight");
        var redBookBottonTexture = _content.Load<Texture2D>("Controls/RedBook");
        var blueBookBottonTexture = _content.Load<Texture2D>("Controls/BlueBook");
        var purpleBookBottonTexture = _content.Load<Texture2D>("Controls/PurpleBook");
        var yellowBookBottonTexture = _content.Load<Texture2D>("Controls/YellowBook");
        var safeTexture = _content.Load<Texture2D>("Controls/safe");
        var settingsButton = new Button(settingsButtonTexture, buttonFont) { Position = new(1390, 40), Text = "", };
        settingsButton.Click += SettingsButtonClick;

        var arrowLeftBotton = new Button(arrowLeftBottonTexture, buttonFont) { Position = new(50, 500), Text = "", };
        arrowLeftBotton.Click += ArrowLeftBottonClick;

        var arrowRightBotton = new Button(arrowRightBottonTexture, buttonFont) { Position = new(1390, 500), Text = "", };
        arrowRightBotton.Click += ArrowRightBottonClick;

        var redBookBotton = new Button(redBookBottonTexture, buttonFont) { Position = new(833, 190), Text = "", };
        redBookBotton.Click += redBookBottonClick;

        var blueBookBotton = new Button(blueBookBottonTexture, buttonFont) { Position = new(1042, 476), Text = "", };
        blueBookBotton.Click += blueBookBottonClick;

        var purpleBookBotton = new Button(purpleBookBottonTexture, buttonFont) { Position = new(1095, 476), Text = "", };
        purpleBookBotton.Click += purpleBookBottonClick;

        var yellowBookBotton = new Button(yellowBookBottonTexture, buttonFont) { Position = new(1132, 313), Text = "", };
        yellowBookBotton.Click += yellowBookBottonClick;
        var safeBotton = new Button(safeTexture, buttonFont) { Position = new(1062, 606), Text = "", };
        safeBotton.Click += safeBottonClick;

        _components = new()
        {
            arrowLeftBotton,
            arrowRightBotton,
            settingsButton,
            redBookBotton,
            blueBookBotton,
            purpleBookBotton,
            yellowBookBotton,
            safeBotton
        };
    }

    private void safeBottonClick(object sender, EventArgs e)
    {
        Globals.Quest = 3;
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void redBookBottonClick(object sender, EventArgs e)
    {
        Globals.Quest = 2;
        Globals.Type = "Red";
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void blueBookBottonClick(object sender, EventArgs e)
    {
        Globals.Quest = 2;
        Globals.Type = "Blue";
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void purpleBookBottonClick(object sender, EventArgs e)
    {
        Globals.Quest = 2;
        Globals.Type = "Purple";
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void yellowBookBottonClick(object sender, EventArgs e)
    {
        Globals.Quest = 2;
        Globals.Type = "Yellow";
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void ArrowRightBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Room3(_game, _graphicsDevice, _content));
    }

    private void ArrowLeftBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
    }

    private void SettingsButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
    }

    public override void LoadContent()
    {
        gameBackground = _content.Load<Texture2D>("Backgrounds/Library");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);
        foreach (var component in _components)
        {
            component.Draw(gameTime, spriteBatch);
        }
        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        foreach (var component in _components)
        {
            component.Update(gameTime);
        }

        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}