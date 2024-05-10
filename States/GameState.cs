using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class GameState : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private float timer;

    public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        random = new();
        var settingsButtonTexture = _content.Load<Texture2D>("Controls/SettingsButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        var arrowLeftBottonTexture = _content.Load<Texture2D>("Controls/ArrowLeft");
        var arrowRightBottonTexture = _content.Load<Texture2D>("Controls/ArrowRight");
        var tableTexture = _content.Load<Texture2D>("Controls/tableButton");
        var bedTexture = _content.Load<Texture2D>("Controls/bedTxt");
        var bedButton = new Button(bedTexture, buttonFont) { Position = new Vector2(1250, 755), Text = "" };
        bedButton.Click = bedButtonClick;
        var tableButton = new Button(tableTexture, buttonFont) { Position = new Vector2(500, 700), Text = "", };
        tableButton.Click += TableButtonClick;

        var settingsButton = new Button(settingsButtonTexture, buttonFont) { Position = new Vector2(1390, 40), Text = "", };
        settingsButton.Click += SettingsButtonClick;

        var arrowLeftBotton = new Button(arrowLeftBottonTexture, buttonFont) { Position = new Vector2(50, 500), Text = "", };
        arrowLeftBotton.Click += ArrowLeftBottonClick;

        var arrowRightBotton = new Button(arrowRightBottonTexture, buttonFont) { Position = new(1390, 500), Text = "", };
        arrowRightBotton.Click += ArrowRightBottonClick;
        _components = new() { arrowLeftBotton, arrowRightBotton, settingsButton, tableButton, bedButton };
    }

    private void TableButtonClick(object sender, EventArgs e)
    {
        Globals.Quest = 1;
        _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
    }

    private void bedButtonClick(object sender, EventArgs e)
    {
        Globals.Bed = true;
        Globals.Quest = 7;
    }

    private void ArrowRightBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Room2(_game, _graphicsDevice, _content));
    }

    private void ArrowLeftBottonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new Room4(_game, _graphicsDevice, _content));
    }

    private void SettingsButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
    }

    public override void LoadContent()
    {
        gameBackground = _content.Load<Texture2D>("Backgrounds/Bedroom");
    }
    

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, Vector2.Zero, Color.White);
        if (Globals.Bed)
        {
            if (Globals.Key)
            {
                spriteBatch.Draw(_content.Load<Texture2D>("Backgrounds/findKey"), Vector2.Zero, Color.White);
                spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Press escape to leave", new Vector2(500, 500), Color.Black);
            }
            else
                spriteBatch.Draw(_content.Load<Texture2D>("Backgrounds/notKey"), Vector2.Zero, Color.White);
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                Globals.Bed = false;
        }
        else
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        if (Globals.Key)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Exit();
        }
        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}