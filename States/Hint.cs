using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class Hint : State
{
    private List<Component> _components;
    public static Random random;
    private Texture2D gameBackground;
    private int Counter;
    private float timer;
    private string _stringValue = string.Empty;
    private SpriteFont font;

    public Hint(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
    {
        random = new();
    }
    public override void LoadContent()
    {
        font = _content.Load<SpriteFont>("Fonts/Font");
        gameBackground = _content.Load<Texture2D>("Backgrounds/BackgroundPicture");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(gameBackground, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(_content.Load<Texture2D>("answers/hint"),new Vector2(300,0), Color.White);
        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
    }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Q) )
            _game.ChangeState(new Room4(_game, _graphicsDevice, _content));
        timer+=(float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}