using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Coloured_Maze;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    const int scale = 4;

    Player player;
    Texture2D playerTexture;
    int colorPlayerId;

    Wall tempWall;
    Texture2D wallTexture;
    int colorWallId;
    int wallId;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        playerTexture = Content.Load<Texture2D>("player");
        colorPlayerId = 6;
        player = new Player(playerTexture, new Vector2(0, 0), colorPlayerId, scale, _graphics);

        wallTexture = Content.Load<Texture2D>("white_walls");
        colorWallId = 0;
        wallId = 3;
        tempWall = new Wall(wallTexture, new Vector2(100, 0), colorWallId, wallId, scale);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState keyboardState = Keyboard.GetState();
        // TODO: Add your update logic here
        player.Update(gameTime, keyboardState);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        player.Draw(_spriteBatch);
        tempWall.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
