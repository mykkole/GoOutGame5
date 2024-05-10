using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class Room3 : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private int Counter;
    private float timer;

    public Room3(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        random = new Random();
        var settingsButtonTexture = _content.Load<Texture2D>("Controls/SettingsButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        var fridgeTexture = _content.Load<Texture2D>("Controls/fridge");
        var arrowLeftBottonTexture = _content.Load<Texture2D>("Controls/ArrowLeft");
        var arrowRightBottonTexture = _content.Load<Texture2D>("Controls/ArrowRight");
        var fridgeButton = new Button(fridgeTexture, buttonFont) { Position = new(938, 619), Text = "" };
        fridgeButton.Click += fridgeButtonClick;

        var settingsButton = new Button(settingsButtonTexture, buttonFont) { Position = new(1390, 40), Text = "", };
        settingsButton.Click += SettingsButtonClick;

        var arrowLeftBotton = new Button(arrowLeftBottonTexture, buttonFont) { Position = new(50, 500), Text = "", };
        arrowLeftBotton.Click += ArrowLeftBottonClick;

        var arrowRightBotton = new Button(arrowRightBottonTexture, buttonFont) { Position = new(1390, 500), Text = "", };
        arrowRightBotton.Click += ArrowRightBottonClick;
        _components = new() { arrowLeftBotton, arrowRightBotton, settingsButton, fridgeButton };
    }

    private void fridgeButtonClick(object sender, EventArgs e)
    {
        Globals.Quest = Globals.Key ? 4 : 5;
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void ArrowRightBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Room4(_game, _graphicsDevice, _content));
    }

    private void ArrowLeftBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Room2(_game, _graphicsDevice, _content));
    }

    private void SettingsButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
    }

    public override void LoadContent()
    {
        gameBackground = _content.Load<Texture2D>("Backgrounds/kitchen");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, Vector2.Zero,Color.White);
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