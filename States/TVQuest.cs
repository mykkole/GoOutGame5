using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class TVQuest : State
{
    private List<Component> _components;
    private Texture2D gameBackground;
    private int Counter;
    private SpriteFont font;
    private int[] password = { 0, 0, 0, 0 };

    public TVQuest(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        var TVButtonTexture = _content.Load<Texture2D>("Controls/TVController");
        var TVButton1 = new Button(TVButtonTexture, font) { Position = new Vector2(0, 0), Text = "", };
        TVButton1.Click += TVButtonClick1;
        var TVButton2 = new Button(TVButtonTexture, font) { Position = new Vector2(110, 0), Text = "", };
        TVButton2.Click += TVButtonClick2;
        var TVButton3 = new Button(TVButtonTexture, font) { Position = new Vector2(220, 0), Text = "", };
        TVButton3.Click += TVButtonClick3;

        var Button4 = new Button(TVButtonTexture, font) { Position = new Vector2(320, 0), Text = "" };
        Button4.Click += TVButton4Click;
        _components = new() { TVButton3, TVButton1, TVButton2, Button4 };
    }

    private void TVButton4Click(object sender, EventArgs e)
    {
        password[3] += 1;
        if (password[3] > 9)
            password[3] = 0;
    }

    private void TVButtonClick1(object sender, EventArgs e)
    {
        password[0] += 1;
        if (password[0] > 9)
            password[0] = 0;
    }

    private void TVButtonClick2(object sender, EventArgs e)
    {
        password[1] += 1;
        if (password[1] > 9)
            password[1] = 0;
    }

    private void TVButtonClick3(object sender, EventArgs e)
    {
        password[2] += 1;
        if (password[2] > 9)
            password[2] = 0;
    }

    public override void LoadContent()
    {
        font = _content.Load<SpriteFont>("Fonts/Font");

        gameBackground = _content.Load<Texture2D>("Backgrounds/TV");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);

        foreach (var component in _components)
        {
            component.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, password[0].ToString(), new(1200, 800), Color.Red);
            spriteBatch.DrawString(font, password[1].ToString(), new(1230, 800), Color.Red);
            spriteBatch.DrawString(font, password[2].ToString(), new(1250, 800), Color.Red);
            if (string.Join("", password) == "2410")
                spriteBatch.Draw(_content.Load<Texture2D>("answers/TVans"), new Vector2(0, 0), Color.White);
        }

        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.M))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q))
            _game.ChangeState(new Room4(_game, _graphicsDevice, _content));

        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
    }
}