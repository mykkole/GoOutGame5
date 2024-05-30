using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace GoOutGame.States;

public class SettingsState : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private float timer;

    public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
    {
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        var contButton = new Button(_content.Load<Texture2D>("Controls/continue"), buttonFont) { Position = new(500, 300), Text = "", };
        contButton.Click += contButtonClick;

        var musicButton = new Button(_content.Load<Texture2D>("Controls/music"), buttonFont) { Position = new(500, 500), Text = "", };
        musicButton.Click += musicButtonClick;

        var menuButton = new Button(_content.Load<Texture2D>("Controls/menu"), buttonFont) { Position = new(500, 700), Text = "", };
        menuButton.Click += menuButtonClick;
        _components = new() { contButton, musicButton, menuButton };
    }

    public override void LoadContent()
    {
        gameBackground = _content.Load<Texture2D>("Backgrounds/settings");
    }

    private void contButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(Globals.location);
    }

    private void musicButtonClick(object sender, EventArgs e)
    {
        if (Globals.IsMusicPlay)
        {
            MediaPlayer.Pause();
            Globals.IsMusicPlay = false;
        }
        else
        {
            MediaPlayer.Resume();
            Globals.IsMusicPlay = true;
        }
    }

    private void menuButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, Vector2.Zero, Color.White);
        foreach (var component in _components)
        {
            component.Draw(gameTime, spriteBatch);
            if (Globals.IsMusicPlay)
                spriteBatch.Draw(_content.Load<Texture2D>("answers/playMusic"), new Vector2(900, 440), Color.White);
            else

                spriteBatch.Draw(_content.Load<Texture2D>("answers/noMusic"), new Vector2(900, 440), Color.White);
        }
        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
    }
}