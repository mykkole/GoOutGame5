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

public class phoneAndSafeQuest : State
{
    private readonly List<Component> components;
    private Texture2D gameBackground;
    private string stringValue = string.Empty;
    private SpriteFont font;

    public phoneAndSafeQuest(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        if (Globals.Quest == "phone")
        {
            var phoneButtonTexture = _content.Load<Texture2D>("Controls/phoneButtoms");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var phone1 = new Button(phoneButtonTexture, buttonFont) { Position = new(400, 451), Text = "1" };
            phone1.Click += Button1Click;

            var phone2 = new Button(phoneButtonTexture, buttonFont) { Position = new(452, 453), Text = "2" };
            phone2.Click += Button2Click;

            var phone3 = new Button(phoneButtonTexture, buttonFont) { Position = new(502, 457), Text = "3" };
            phone3.Click += Button3Click;

            var phone4 = new Button(phoneButtonTexture, buttonFont) { Position = new(399, 483), Text = "4" };
            phone4.Click += Button4Click;

            var phone5 = new Button(phoneButtonTexture, buttonFont) { Position = new(450, 486), Text = "5" };
            phone5.Click += Button5Click;

            var phone6 = new Button(phoneButtonTexture, buttonFont) { Position = new(500, 488), Text = "6" };
            phone6.Click += Button6Click;

            var phone7 = new Button(phoneButtonTexture, buttonFont) { Position = new(398, 521), Text = "7" };
            phone7.Click += Button7Click;

            var phone8 = new Button(phoneButtonTexture, buttonFont) { Position = new(448, 523), Text = "8" };
            phone8.Click += Button8Click;

            var phone9 = new Button(phoneButtonTexture, buttonFont) { Position = new(498, 526), Text = "9" };
            phone9.Click += Button9Click;
            components = new()
            {
                phone1,
                phone2,
                phone3,
                phone4,
                phone5,
                phone6,
                phone7,
                phone8,
                phone9,
            };
        }
        if (Globals.Quest == "safe")
        {
            var safeButtonTexture = _content.Load<Texture2D>("Controls/safeButton");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var button1 = new Button(safeButtonTexture, buttonFont) { Position = new(507, 313), Text = "1" };
            button1.Click += Button1Click;

            var button2 = new Button(safeButtonTexture, buttonFont) { Position = new(719, 313), Text = "2" };
            button2.Click += Button2Click;

            var button3 = new Button(safeButtonTexture, buttonFont) { Position = new(918, 313), Text = "3" };
            button3.Click += Button3Click;

            var button4 = new Button(safeButtonTexture, buttonFont) { Position = new(507, 453), Text = "4" };
            button4.Click += Button4Click;

            var button5 = new Button(safeButtonTexture, buttonFont) { Position = new(719, 453), Text = "5" };
            button5.Click += Button5Click;

            var button6 = new Button(safeButtonTexture, buttonFont) { Position = new(918, 453), Text = "6" };
            button6.Click += Button6Click;

            var button7 = new Button(safeButtonTexture, buttonFont) { Position = new(507, 593), Text = "7" };
            button7.Click += Button7Click;

            var button8 = new Button(safeButtonTexture, buttonFont) { Position = new(719, 593), Text = "8" };
            button8.Click += Button8Click;

            var button9 = new Button(safeButtonTexture, buttonFont) { Position = new(918, 593), Text = "9" };
            button9.Click += Button9Click;

            var button0 = new Button(safeButtonTexture, buttonFont) { Position = new(719, 733), Text = "0" };
            button0.Click += Button0Click;
            components = new()
            {
                button0,
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
            };
        }
    }

    private void Button0Click(object sender, EventArgs e)
    {
        stringValue += "0";
    }

    private void Button1Click(object sender, EventArgs e)
    {
        stringValue += "1";
    }

    private void Button2Click(object sender, EventArgs e)
    {
        stringValue += "2";
    }

    private void Button3Click(object sender, EventArgs e)
    {
        stringValue += "3";
    }

    private void Button4Click(object sender, EventArgs e)
    {
        stringValue += "4";
    }

    private void Button5Click(object sender, EventArgs e)
    {
        stringValue += "5";
    }

    private void Button6Click(object sender, EventArgs e)
    {
        stringValue += "6";
    }

    private void Button7Click(object sender, EventArgs e)
    {
        stringValue += "7";
    }

    private void Button8Click(object sender, EventArgs e)
    {
        stringValue += "8";
    }

    private void Button9Click(object sender, EventArgs e)
    {
        stringValue += "9";
    }

    public override void LoadContent()
    {
        font = _content.Load<SpriteFont>("Fonts/Font");
        if (Globals.Quest == "phone")
            gameBackground = _content.Load<Texture2D>("Backgrounds/table");
        if (Globals.Quest == "safe")
            gameBackground = _content.Load<Texture2D>("Backgrounds/safe");
  
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);
        var i = 0;

        if (Globals.Quest == "safe")
        {
            foreach (var component in components)
            {
                component.Draw(gameTime, spriteBatch);
                DrawPassword(spriteBatch, i, 5, new(709, 150));
                WriteResult(stringValue, "347594", spriteBatch, _content.Load<Texture2D>("answers/safeAns"), _content.Load<Texture2D>("answers/safeWrongAns"), new(0, 0), new(460, 88));
            }
        }
        if (Globals.Quest == "phone")
        {
            foreach (var component in components)
            {
                component.Draw(gameTime, spriteBatch);
                DrawPassword(spriteBatch, i, 9, new(395, 292));
                WriteResult(stringValue, "8244839167", spriteBatch, _content.Load<Texture2D>("answers/phoneAns"), _content.Load<Texture2D>("answers/wrongPhoneAns"), new(389, 285), new(389, 285));
            }
        }

        spriteBatch.End();
    }

    private void DrawPassword(SpriteBatch spriteBatch, int i, int maxLength, Vector2 vector2)
    {
        while (i < maxLength)
        {
            spriteBatch.DrawString(font, stringValue, vector2, Color.Black);
            i++;
        }
    }

    private void WriteResult(String str, string answer, SpriteBatch spriteBatch, Texture2D rightAnswer, Texture2D wrongAnswer, Vector2 vectorCorrect, Vector2 vectorWrong)
    {
        if (str == answer)
        {
            spriteBatch.Draw(rightAnswer, vectorCorrect, Color.White);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                stringValue = String.Empty;
        }
        else if (stringValue.Length >= answer.Length)
        {
            spriteBatch.Draw(wrongAnswer, vectorWrong, Color.White);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                stringValue = String.Empty;
        }
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.M))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        if ((Keyboard.GetState().IsKeyDown(Keys.Q)) && Globals.Quest == "phone")
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q) && Globals.Quest == "safe")
            _game.ChangeState(new Room2(_game, _graphicsDevice, _content));

        foreach (var component in components)
        {
            component.Update(gameTime);
        }
    }
}