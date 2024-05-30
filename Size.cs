using Microsoft.Xna.Framework;

namespace GoOutGame;

public static class Size
{
    public static GraphicsDeviceManager SizeMan(this GraphicsDeviceManager graphicsDeviceManager)
    {
        var currentDisplay = graphicsDeviceManager.GraphicsDevice.DisplayMode;
        graphicsDeviceManager.PreferredBackBufferHeight = currentDisplay.Height;
        graphicsDeviceManager.PreferredBackBufferWidth = currentDisplay.Width;
        return graphicsDeviceManager;
    }
}