using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GoOutGame.Control;

public class Button : Component
{
    #region Fields

    private Game1 _game;

    private MouseState _currentMouse;

    private SpriteFont _font;

    private bool _isHovering;

    private MouseState _previousMouse;

    private Texture2D _texture;
    #endregion

    #region Properties

    public EventHandler Click;

    public bool Clicked { get; private set; }

    public float Layer { get; set; }

    public Vector2 Origin
    {
        get
        {
            return new (_texture.Width / 2, _texture.Height / 2);
        }
    }

    public Vector2 Position { get; set; }

    private Rectangle Rectangle
    {
        get
        {
            return new ((int)Position.X - ((int)Origin.X), (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
        }
    }

    public string Text;
    

    #endregion

    #region Methods

    public Button(Texture2D texture, SpriteFont font)
    {
        _texture = texture;

        _font = font;
    }


    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        var colour = Color.White;

        if (_isHovering && Text != "")
            colour = Color.Gray;
       
        
        spriteBatch.Draw(_texture, Position, null, colour, 0f, Origin, 1f, SpriteEffects.None, Layer);

        if (!string.IsNullOrEmpty(Text))
        {
            if (Globals.Quest == 3)
                colour = Color.Black;
            var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
            var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

            spriteBatch.DrawString(_font, Text,new (x,y),colour);
        }
    }

    public override void Update(GameTime gameTime)
    {
        _previousMouse = _currentMouse;
        _currentMouse = Mouse.GetState();

        var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

        _isHovering = false;

        if (mouseRectangle.Intersects(Rectangle))
        {
            _isHovering = true;

            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, new());
            }
        }
    }

    #endregion
}