using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class Quests : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private int Counter;
    private float timer;
    private string _stringValue = string.Empty;
    private SpriteFont font;

    public Quests(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        random = new Random();
        if (Globals.Quest == 1)
        {
            var phoneButtonTexture = _content.Load<Texture2D>("Controls/phoneButton");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var phone1 = new Button(phoneButtonTexture, buttonFont) { Position = new(100, 500), Text = "1" };
            phone1.Click += PhoneClick;

            var phone2 = new Button(phoneButtonTexture, buttonFont) { Position = new(300, 500), Text = "2" };
            phone2.Click += Phone2Click;
            _components = new List<Component>{phone1, phone2};
        }
    }


    private void PhoneClick(object sender, EventArgs e)
    {
        _stringValue += "1";
    }
    private void Phone2Click(object sender, EventArgs e)
    {
        _stringValue += "2";
    }
    public override void LoadContent()
    {
        font = _content.Load<SpriteFont>("Fonts/Font");
        if (Globals.Quest == 1)
            gameBackground = _content.Load<Texture2D>("Backgrounds/k3");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0,0),Color.White);
        foreach (var component in _components)
        {
            if (_stringValue == "122")
                spriteBatch.DrawString(font,"GOOD",new Vector2(500,500),Color.Black);
            component.Draw(gameTime,spriteBatch);
        }
        spriteBatch.End();
        
    }

    public override void PostUpdate(GameTime gameTime)
    {
    }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.M))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        var keyboardState = Keyboard.GetState();
        var keys = keyboardState.GetPressedKeys();

        if(keys.Length > 0)
        {
            var keyValue = keys[0].ToString();
            _stringValue += keyValue;
        }
        
        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        
    }
}