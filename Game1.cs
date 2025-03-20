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

    Goal goal;
    Texture2D goalTexture;

    string[,] mapTest;
    Level levelTest;

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
        goalTexture = Content.Load<Texture2D>("goals");

        // General IDs
        // ------------------------
        // colorId    -> 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow
        // wallId     -> 1: single, 2: left, 3: right, 4: bottom, 5: top, 6: horizontal, 7: vertical

        // Array IDs
        // ------------------------
        // Void       -> "": Nothing
        // Walls      -> "{wallId}{colorId}"
        // Color Pads -> "c{colorId}"
        // Player     -> "p{colorId}"
        // Goal       -> "g{colorId}"
        mapTest = new string[,]{
            {"g1",""  ,""  ,""  ,""  ,"20","60","30",""  ,""  },
            {""  ,""  ,"50",""  ,""  ,""  ,""  ,""  ,""  ,""  },
            {""  ,""  ,"70",""  ,""  ,""  ,""  ,""  ,""  ,""  },
            {""  ,""  ,"40",""  ,""  ,""  ,""  ,""  ,""  ,""  },
            {"20","60","30",""  ,""  ,""  ,"50","c1",""  ,""  },
            {""  ,""  ,"c3",""  ,""  ,""  ,"70",""  ,""  ,""  },
            {""  ,""  ,""  ,""  ,""  ,"c0","70","20","60","30"},
            {""  ,""  ,"10",""  ,"10",""  ,"40",""  ,""  ,""  },
            {""  ,""  ,""  ,""  ,""  ,""  ,""  ,""  ,""  ,""  },
            {""  ,""  ,""  ,""  ,""  ,""  ,""  ,""  ,""  ,"p0"}
        };
        
        levelTest = new Level(mapTest, wallTexture, colorPadTexture, playerTexture, goalTexture, scale, _graphics);
        var levelOutput = levelTest.Load();

        walls = levelOutput.Item1;
        colorPads = levelOutput.Item2;
        player = levelOutput.Item3;
        goal = levelOutput.Item4;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState keyboardState = Keyboard.GetState();
        // TODO: Add your update logic here
                if (goal.IsReached(player))
        {
            Exit();
        }

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
        goal.Draw(_spriteBatch);
        player.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
