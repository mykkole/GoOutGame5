using System;
using System.Collections.Generic;
using GoOutGame.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GoOutGame.States;

public class MenuState:State
{
    private List<Component> _components;
    private Texture2D menuBack;

    public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
    : base(game, graphicsDevice, content)
    {
        var buttonTexture = _content.Load<Texture2D>("Controls/MainMenuButton");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

        var newGameButton = new Button(buttonTexture, buttonFont)
        {
            Position = new(200, 450),
            Text = "NewGame",
        };
        newGameButton.Click += ButtonNewGameClick;
        
        var exitButton = new Button(buttonTexture, buttonFont)
        {
            Position = new(200, 650),
            Text = "Bye",
        };
        exitButton.Click += ExitButtonClick;

        _components = new() { newGameButton, exitButton, };
    }

    private void ExitButtonClick(object sender, EventArgs e)
    {
        _game.Exit();
    }

    private void SettingsButtonClick(object sender, EventArgs e)
    {
        _game.ChangeState(new GameState(_game,_graphicsDevice,_content));
    }

    private void ButtonNewGameClick(object sender, EventArgs e)
    {
        _game.ChangeState(new GameState(_game,_graphicsDevice,_content));
    }

    public override void LoadContent()
    {
        menuBack = _content.Load<Texture2D>("Backgrounds/MainMenu");
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(menuBack,new Vector2(0,0),Color.White);
        foreach (var component in _components)
        {
            component.Draw(gameTime,spriteBatch);
        }
        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
    }
}