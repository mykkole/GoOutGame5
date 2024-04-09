using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GoOutGame.States;

public class SettingsState:State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private float timer;
    public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content) { }
    public override void LoadContent()
    {
        random = new Random();
        var settingsButtonTexture = _content.Load<Texture2D>("Controls/SettingsItemButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        var settingsItemButton = new Button(settingsButtonTexture, buttonFont)
        {
            Position = new(1390, 40),
            Text = "",
        };
        settingsItemButton.Click += SettingsItemButtonClick;
        _components = new() { settingsItemButton };
    }

    private void SettingsItemButtonClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        throw new System.NotImplementedException();
    }

    public override void PostUpdate(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }
}