using System.Collections.Generic;
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

    Texture2D wallTexture;
    List<Wall> walls = new List<Wall>();

    Texture2D colorPadTexture;
    List<ColorPad> colorPads = new List<ColorPad>();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 640;
        _graphics.PreferredBackBufferHeight = 640;

        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        wallTexture = Content.Load<Texture2D>("walls");
        colorPadTexture = Content.Load<Texture2D>("colorPads");
        playerTexture = Content.Load<Texture2D>("player");
        // colorWallId = 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow
        // wallId = 1: single, 2: left, 3: right, 4: bottom, 5: top, 6: horizontal, 7: vertical
        walls.Add(new Wall(wallTexture, new Vector2(5, 0), colorId: 0, wallId: 2, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6, 0), colorId: 0, wallId: 6, scale));
        walls.Add(new Wall(wallTexture, new Vector2(7, 0), colorId: 0, wallId: 3, scale));

        walls.Add(new Wall(wallTexture, new Vector2(2, 1), colorId: 0, wallId: 5, scale));
        walls.Add(new Wall(wallTexture, new Vector2(2, 2), colorId: 0, wallId: 7, scale));
        walls.Add(new Wall(wallTexture, new Vector2(2, 3), colorId: 0, wallId: 4, scale));

        walls.Add(new Wall(wallTexture, new Vector2(0, 4), colorId: 0, wallId: 2, scale));
        walls.Add(new Wall(wallTexture, new Vector2(1, 4), colorId: 0, wallId: 6, scale));
        walls.Add(new Wall(wallTexture, new Vector2(2, 4), colorId: 0, wallId: 3, scale));

        walls.Add(new Wall(wallTexture, new Vector2(6, 4), colorId: 0, wallId: 5, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6, 5), colorId: 0, wallId: 7, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6, 6), colorId: 0, wallId: 7, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6, 7), colorId: 0, wallId: 4, scale));

        walls.Add(new Wall(wallTexture, new Vector2(7, 6), colorId: 0, wallId: 2, scale));
        walls.Add(new Wall(wallTexture, new Vector2(8, 6), colorId: 0, wallId: 6, scale));
        walls.Add(new Wall(wallTexture, new Vector2(9, 6), colorId: 0, wallId: 3, scale));

        walls.Add(new Wall(wallTexture, new Vector2(2, 7), colorId: 0, wallId: 1, scale));
        walls.Add(new Wall(wallTexture, new Vector2(4, 7), colorId: 0, wallId: 1, scale));

        colorPads.Add(new ColorPad(colorPadTexture, new Vector2(2, 5), colorId: 3, scale));
        colorPads.Add(new ColorPad(colorPadTexture, new Vector2(5, 6), colorId: 0, scale));
        colorPads.Add(new ColorPad(colorPadTexture, new Vector2(7, 4), colorId: 1, scale));

        player = new Player(playerTexture, new Vector2(9, 9), colorId: 0, scale, _graphics, walls, colorPads);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState keyboardState = Keyboard.GetState();
        // TODO: Add your update logic here
        foreach (Wall wall in walls)
        {
            wall.Update();
        }
        foreach (ColorPad colorPad in colorPads)
        {
            colorPad.Update();
        }
        player.Update(gameTime, keyboardState);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (Wall wall in walls)
        {
            wall.Draw(_spriteBatch);
        }
        foreach (ColorPad colorPad in colorPads)
        {
            colorPad.Draw(_spriteBatch);
        }
        player.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
