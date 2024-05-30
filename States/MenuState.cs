using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoOutGame.States;

public class MenuState : State
{
    private readonly List<Component> components;
    private Texture2D menuBack;

    public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        var buttonTexture = _content.Load<Texture2D>("Controls/MainMenuButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

        var newGameButton = new Button(buttonTexture, buttonFont) { Position = new Vector2(200, 450), Text = "New Game", };
        newGameButton.Click += ButtonNewGameClick;

        var exitButton = new Button(buttonTexture, buttonFont) { Position = new(200, 650), Text = "Bye", };
        exitButton.Click += ExitButtonClick;

        components = new() { newGameButton, exitButton, };
    }

    private void ExitButtonClick(object sender, EventArgs e)
    {
        _game.Exit();
    }

    private void ButtonNewGameClick(object sender, EventArgs e)
    {
        _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
    }

    public override void LoadContent()
    {
        menuBack = _content.Load<Texture2D>("Backgrounds/MainMenu");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        //spriteBatch.Begin(transformMatrix:_game.GetScaleMatrix());
        spriteBatch.Begin();
        spriteBatch.Draw(menuBack, new Vector2(0,0), Color.White);
        foreach (var component in components)
        {
            component.Draw(gameTime, spriteBatch);
        }
        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime) { }

    public override void Update(GameTime gameTime)
    {
        foreach (var component in components)
        {
            component.Update(gameTime);
        }
    }
}