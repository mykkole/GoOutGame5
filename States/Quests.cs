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
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private int Counter;
    private float timer;
    private string _stringValue = string.Empty;
    private SpriteFont font;
    private int[] password = { 0, 0, 0, 0 };

    private float _rotation;
    private Vector2 pos;


    private float[] angles = { 3, 2, 1, 3 };

    public Quests(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        random = new();
        if (Globals.Quest == 4 && !Globals.Key)
        {
            var keyTexture = _content.Load<Texture2D>("Controls/key");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var keyButton = new Button(keyTexture, buttonFont) { Position = new(500, 500), Text = "" };
            keyButton.Click += keyButtonClick;
            _components = new() { keyButton };
        }
        if (Globals.Quest == 1)
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
            _components = new()
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
        if (Globals.Quest == 3)
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
            _components = new()
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
        if (Globals.Quest == 6)
        {
            var TVButtonTexture = _content.Load<Texture2D>("Controls/TVController");
            var TVButton1 = new Button(TVButtonTexture, font) { Position = new Vector2(0, 0), Text = "", };
            TVButton1.Click += TVButtonClick1;
            var TVButton2 = new Button(TVButtonTexture, font) { Position = new Vector2(110, 0), Text = "", };
            TVButton2.Click += TVButtonClick2;
            var TVButton3 = new Button(TVButtonTexture, font) { Position = new Vector2(220, 0), Text = "", };
            TVButton3.Click += TVButtonClick3;
            _components = new() { TVButton3, TVButton1, TVButton2 };
            if (Globals.Quest == 5)
            {
                var Button4 = new Button(TVButtonTexture, font) { Position = new Vector2(320, 0), Text = "" };
                Button4.Click += TVButton4Click;
                _components = new List<Component>() { TVButton3, TVButton1, TVButton2, Button4 };
            }
        }
        if (Globals.Quest == 5)
        {
            var pusTxt = _content.Load<Texture2D>("Controls/key");
            var puz = new Button(pusTxt, _content.Load<SpriteFont>("Fonts/Font")) { Position = new Vector2(120, 100), Text = "" };
            puz.Click += puzClicked;

            var puz2 = new Button(pusTxt, _content.Load<SpriteFont>("Fonts/Font")) { Position = new Vector2(120, 540), Text = "" };
            puz2.Click += puz2Clicked;

            var puz3 = new Button(pusTxt, _content.Load<SpriteFont>("Fonts/Font")) { Position = new Vector2(1300, 100), Text = "" };
            puz3.Click += puz3Clicked;

            var puz4 = new Button(pusTxt, _content.Load<SpriteFont>("Fonts/Font")) { Position = new Vector2(1300, 540), Text = "" };
            puz4.Click += puz4Clicked;
            _components = new List<Component>() { puz, puz2, puz3, puz4 };
        }
    }

    public void puzClicked(object sender, EventArgs e)
    {
        angles[0]++;
        if (angles[0] > 3)
        {
            angles[0] = 0;
        }
    }

    public void puz2Clicked(object sender, EventArgs e)
    {
        angles[1]++;
        if (angles[1] > 3)
        {
            angles[1] = 0;
        }
    }

    public void puz3Clicked(object sender, EventArgs e)
    {
        angles[2]++;
        if (angles[2] > 3)
        {
            angles[2] = 0;
        }
    }

    public void puz4Clicked(object sender, EventArgs e)
    {
        angles[3]++;
        if (angles[3] > 3)
        {
            angles[3] = 0;
        }
    }

    private void TVButton4Click(object sender, EventArgs e)
    {
        password[3] += 1;
        if (password[3] > 9)
            password[3] = 0;
    }

    private void keyButtonClick(object sender, EventArgs e)
    {
        Globals.Key = true;
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

    private void Button0Click(object sender, EventArgs e)
    {
        _stringValue += "0";
    }

    private void Button1Click(object sender, EventArgs e)
    {
        _stringValue += "1";
    }

    private void Button2Click(object sender, EventArgs e)
    {
        _stringValue += "2";
    }

    private void Button3Click(object sender, EventArgs e)
    {
        _stringValue += "3";
    }

    private void Button4Click(object sender, EventArgs e)
    {
        _stringValue += "4";
    }

    private void Button5Click(object sender, EventArgs e)
    {
        _stringValue += "5";
    }

    private void Button6Click(object sender, EventArgs e)
    {
        _stringValue += "6";
    }

    private void Button7Click(object sender, EventArgs e)
    {
        _stringValue += "7";
    }

    private void Button8Click(object sender, EventArgs e)
    {
        _stringValue += "8";
    }

    private void Button9Click(object sender, EventArgs e)
    {
        _stringValue += "9";
    }

    public override void LoadContent()
    {
        font = _content.Load<SpriteFont>("Fonts/Font");
        if (Globals.Quest == 1)
            gameBackground = _content.Load<Texture2D>("Backgrounds/table");
        if (Globals.Quest == 2)
            gameBackground = _content.Load<Texture2D>("Backgrounds/BackgroundPicture");
        if (Globals.Quest == 3)
            gameBackground = _content.Load<Texture2D>("Backgrounds/safe");
        if (Globals.Quest == 6)
            gameBackground = _content.Load<Texture2D>("Backgrounds/TV");
        if (Globals.Quest == 4)
            gameBackground = _content.Load<Texture2D>("Backgrounds/openFridge");
        if (Globals.Quest == 5)
            gameBackground = _content.Load<Texture2D>("Backgrounds/fridgeTask");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);
        var i = 0;
        if (Globals.Quest == 4)
        {
            if (Globals.Key == false)
                foreach (var component in _components)
                {
                    component.Draw(gameTime, spriteBatch);
                }
        }
        if (Globals.Quest == 3)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
                DrawPassword(spriteBatch, i, 5, new(709, 150));
                WriteResult(_stringValue, "347594", spriteBatch, _content.Load<Texture2D>("answers/safeAns"), _content.Load<Texture2D>("answers/safeWrongAns"), new(0, 0), new(460, 88));
            }
        }
        if (Globals.Quest == 1)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
                DrawPassword(spriteBatch, i, 9, new(395, 292));
                WriteResult(_stringValue, "8244839167", spriteBatch, _content.Load<Texture2D>("answers/phoneAns"), _content.Load<Texture2D>("answers/wrongPhoneAns"), new(389, 285), new(389, 285));
            }
        }

        if (Globals.Quest == 2)
        {
            spriteBatch.Draw(_content.Load<Texture2D>("answers/" + Globals.Type + "Book"), new Vector2(70, 100), Color.White);
        }
        if (Globals.Quest == 6)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
                spriteBatch.DrawString(font, password[0].ToString(), new(1200, 800), Color.Red);
                spriteBatch.DrawString(font, password[1].ToString(), new(1230, 800), Color.Red);
                spriteBatch.DrawString(font, password[2].ToString(), new(1250, 800), Color.Red);
                if (string.Join("", password) == "2410")
                    spriteBatch.Draw(_content.Load<Texture2D>("answers/TVans"), new Vector2(0, 0), Color.White);
            }
        }
        if (Globals.Quest == 5)
        {
            var texture = _content.Load<Texture2D>("Slice 13");
            var texture2 = _content.Load<Texture2D>("Slice 14");
            var texture3 = _content.Load<Texture2D>("Slice 15");
            var texture4 = _content.Load<Texture2D>("Slice 16");

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
                spriteBatch.Draw(texture, new Vector2(495, 225), null, Color.White, angles[0] * 90 * (3.14f / 180), new Vector2(texture.Width / 2, texture.Height / 2), Vector2.One, SpriteEffects.None, 1f);
                spriteBatch.Draw(texture2, new Vector2(495, 675), null, Color.White, angles[1] * 90 * (3.14f / 180), new Vector2(texture2.Width / 2, texture2.Height / 2), Vector2.One, SpriteEffects.None, 1f);
                spriteBatch.Draw(texture3, new Vector2(945, 225), null, Color.White, angles[2] * 90 * (3.14f / 180), new Vector2(texture2.Width / 2, texture2.Height / 2), Vector2.One, SpriteEffects.None, 1f);
                spriteBatch.Draw(texture4, new Vector2(945, 675), null, Color.White, angles[3] * 90 * (3.14f / 180), new Vector2(texture3.Width / 2, texture3.Height / 2), Vector2.One, SpriteEffects.None, 1f);
                if (string.Join("", angles) == "0000" && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Globals.Quest = 4;
                    _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
                }
            }
        }

        spriteBatch.End();
    }

    private void DrawPassword(SpriteBatch spriteBatch, int i, int maxLength, Vector2 vector2)
    {
        while (i < maxLength)
        {
            spriteBatch.DrawString(font, _stringValue, vector2, Color.Black);
            i++;
        }
    }

    private void WriteResult(String str, string answer, SpriteBatch spriteBatch, Texture2D rightAnswer, Texture2D wrongAnswer, Vector2 vectorCorrect, Vector2 vectorWrong)
    {
        if (str == answer)
        {
            spriteBatch.Draw(rightAnswer, vectorCorrect, Color.White);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                _stringValue = String.Empty;
        }
        else if (_stringValue.Length >= answer.Length)
        {
            spriteBatch.Draw(wrongAnswer, vectorWrong, Color.White);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                _stringValue = String.Empty;
        }
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.M))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        if ((Keyboard.GetState().IsKeyDown(Keys.Q)) && Globals.Quest == 1)
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q) && (Globals.Quest == 2 || Globals.Quest == 3))
            _game.ChangeState(new Room2(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q) && (Globals.Quest == 4 || Globals.Quest == 5))
            _game.ChangeState(new Room3(_game, _graphicsDevice, _content));
        if (Keyboard.GetState().IsKeyDown(Keys.Q) && Globals.Quest == 6)
            _game.ChangeState(new Room4(_game, _graphicsDevice, _content));

        if (Globals.Quest == 1 || Globals.Quest == 3 || Globals.Quest == 6 || Globals.Quest == 5)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        if (Globals.Quest == 4 && Globals.Key == false)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}