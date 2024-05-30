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

public class Quests : State
{
    private readonly List<Component> components;
    private Texture2D gameBackground;

    public Quests(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        if (Globals.Quest == "key" && !Globals.Key)
        {
            var keyTexture = _content.Load<Texture2D>("Controls/key");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var keyButton = new Button(keyTexture, buttonFont) { Position = new(500, 500), Text = "" };
            keyButton.Click += keyButtonClick;
            components = new() { keyButton };
        }
    }

    private static void keyButtonClick(object sender, EventArgs e)
    {
        Globals.Key = true;
    }

    public override void LoadContent()
    {
        if (Globals.Quest.Split()[0] == "Book")
            gameBackground = _content.Load<Texture2D>("Backgrounds/BackgroundPicture");
        if (Globals.Quest == "key")
            gameBackground = _content.Load<Texture2D>("Backgrounds/openFridge");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);
        var i = 0;
        if (Globals.Quest == "key")
        {
            if (Globals.Key == false)
                foreach (var component in components)
                {
                    component.Draw(gameTime, spriteBatch);
                }
        }

        if (Globals.Quest.Split()[0]=="Book")
        {
            spriteBatch.Draw(_content.Load<Texture2D>("answers/" + Globals.Quest.Split()[1] + "Book"), new Vector2(70, 100), Color.White);
        }
        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.M))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q) && Globals.Quest.Split()[0] == "Book")
            _game.ChangeState(new Room2(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q) && Globals.Quest == "key")
            _game.ChangeState(new Room3(_game, _graphicsDevice, _content));

        if (Globals.Quest == "key" && Globals.Key == false)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }
    }
}