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

public class Puzzle : State
{
    private List<Component> _components;
    private Texture2D gameBackground;
    private SpriteFont font;

    private readonly float[] angles = { 3, 2, 1, 3 };

    public Puzzle(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
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
        _components = new() { puz, puz2, puz3, puz4 };
    }

    private void puzClicked(object sender, EventArgs e)
    {
        angles[0]++;
        if (angles[0] > 9)
        {
            angles[0] = 0;
        }
    }

    private void puz2Clicked(object sender, EventArgs e)
    {
        angles[1]++;
        if (angles[1] > 9)
        {
            angles[1] = 0;
        }
    }

    private void puz3Clicked(object sender, EventArgs e)
    {
        angles[2]++;
        if (angles[2] > 9)
        {
            angles[2] = 0;
        }
    }

    private void puz4Clicked(object sender, EventArgs e)
    {
        angles[3]++;
        if (angles[3] > 9)
        {
            angles[3] = 0;
        }
    }

    public override void LoadContent()
    {
        font = _content.Load<SpriteFont>("Fonts/Font");

        gameBackground = _content.Load<Texture2D>("Backgrounds/fridgeTask");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);

        var texture = _content.Load<Texture2D>("Slice 13 1 ");
        var texture2 = _content.Load<Texture2D>("Slice 14");
        var texture3 = _content.Load<Texture2D>("Slice 15");
        var texture4 = _content.Load<Texture2D>("Slice 16");

        foreach (var component in _components)
        {
            component.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(texture, new(495, 225), null, Color.White, angles[0] * 90 * ((float)Math.PI / 180), new(texture.Width / 2, texture.Height / 2), Vector2.One, SpriteEffects.None, 1f);
            spriteBatch.Draw(texture2, new(495, 675), null, Color.White, angles[1] * 90 * ((float)Math.PI / 180), new(texture2.Width / 2, texture2.Height / 2), Vector2.One, SpriteEffects.None, 1f);
            spriteBatch.Draw(texture3, new(945, 225), null, Color.White, angles[2] * 90 * ((float)Math.PI  / 180), new(texture2.Width / 2, texture2.Height / 2), Vector2.One, SpriteEffects.None, 1f);
            spriteBatch.Draw(texture4, new(945, 675), null, Color.White, angles[3] * 90 * ((float)Math.PI / 180), new(texture3.Width / 2, texture3.Height / 2), Vector2.One, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, string.Join("", angles), new(1300, 800), Color.Red, 0f, new(1, 1), new Vector2(2, 2), SpriteEffects.None, 1f);
            if (string.Join("", angles) == "9490" && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Globals.Quest = "key";
                _game.ChangeState(new Quests(_game, _graphicsDevice, _content));
            }
        }

        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.M))
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));

        if (Keyboard.GetState().IsKeyDown(Keys.Q))
            _game.ChangeState(new Room3(_game, _graphicsDevice, _content));

        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
    }
}