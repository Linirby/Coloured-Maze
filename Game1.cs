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
    const int tileSize = 16;

    Player player;
    Texture2D playerTexture;
    int colorPlayerId;

    Texture2D wallTexture;
    List<Wall> walls = new List<Wall>();

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
        // colorWallId = 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow
        // wallId = 1: single, 2: left, 3: right, 4: bottom, 5: top, 6: horizontal, 7: vertical
        walls.Add(new Wall(wallTexture, new Vector2(5*(tileSize*scale), 0*(tileSize*scale)), colorId: 0, wallId: 2, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6*(tileSize*scale), 0*(tileSize*scale)), colorId: 0, wallId: 6, scale));
        walls.Add(new Wall(wallTexture, new Vector2(7*(tileSize*scale), 0*(tileSize*scale)), colorId: 0, wallId: 3, scale));

        walls.Add(new Wall(wallTexture, new Vector2(2*(tileSize*scale), 1*(tileSize*scale)), colorId: 0, wallId: 5, scale));
        walls.Add(new Wall(wallTexture, new Vector2(2*(tileSize*scale), 2*(tileSize*scale)), colorId: 0, wallId: 7, scale));
        walls.Add(new Wall(wallTexture, new Vector2(2*(tileSize*scale), 3*(tileSize*scale)), colorId: 0, wallId: 4, scale));
        walls.Add(new Wall(wallTexture, new Vector2(0*(tileSize*scale), 4*(tileSize*scale)), colorId: 0, wallId: 2, scale));
        walls.Add(new Wall(wallTexture, new Vector2(1*(tileSize*scale), 4*(tileSize*scale)), colorId: 0, wallId: 6, scale));
        walls.Add(new Wall(wallTexture, new Vector2(2*(tileSize*scale), 4*(tileSize*scale)), colorId: 0, wallId: 3, scale));

        walls.Add(new Wall(wallTexture, new Vector2(6*(tileSize*scale), 4*(tileSize*scale)), colorId: 0, wallId: 5, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6*(tileSize*scale), 5*(tileSize*scale)), colorId: 0, wallId: 7, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6*(tileSize*scale), 6*(tileSize*scale)), colorId: 0, wallId: 7, scale));
        walls.Add(new Wall(wallTexture, new Vector2(6*(tileSize*scale), 7*(tileSize*scale)), colorId: 0, wallId: 4, scale));
        walls.Add(new Wall(wallTexture, new Vector2(7*(tileSize*scale), 6*(tileSize*scale)), colorId: 0, wallId: 2, scale));
        walls.Add(new Wall(wallTexture, new Vector2(8*(tileSize*scale), 6*(tileSize*scale)), colorId: 0, wallId: 6, scale));
        walls.Add(new Wall(wallTexture, new Vector2(9*(tileSize*scale), 6*(tileSize*scale)), colorId: 0, wallId: 3, scale));

        playerTexture = Content.Load<Texture2D>("player");
        player = new Player(playerTexture, new Vector2(9*(tileSize*scale), 9*(tileSize*scale)), colorId: 1, scale, _graphics, walls);
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
        player.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
