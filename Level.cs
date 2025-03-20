using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Coloured_Maze
{
    class Level
    {
        string[,] mapArray;
        int arrayWidth;
        int arrayHeight;

        Texture2D wallTexture;
        Texture2D colorPadTexture;
        Texture2D playerTexture;
        Texture2D goalTexture;
        int scale;
        GraphicsDeviceManager _graphics;

        List<Wall> walls;
        List<ColorPad> colorPads;
        Player player;
        Goal goal;


        public Level(string[,] array, Texture2D wallTexture, Texture2D colorPadTexture, Texture2D playerTexture, Texture2D goalTexture, int scale, GraphicsDeviceManager _graphics)
        {
            this.wallTexture = wallTexture;
            this.colorPadTexture = colorPadTexture;
            this.playerTexture = playerTexture;
            this.goalTexture = goalTexture;
            this.scale = scale;
            this._graphics = _graphics;
            walls = new List<Wall>();
            colorPads = new List<ColorPad>();
            mapArray = array;
            arrayWidth = mapArray.GetLength(0);
            arrayHeight = mapArray.GetLength(1);
        }

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
        public (List<Wall>, List<ColorPad>, Player, Goal) Load()
        {
            
            for (int i = 0; i < arrayWidth; i++) 
            { 
                for (int j = 0; j < arrayHeight; j++) 
                { 
                    switch (mapArray[j, i])
                    {
                        case "":
                            break;
                        // Walls
                        case "10":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 1, scale));
                            break;
                        case "20":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 2, scale));
                            break;
                        case "30":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 3, scale));
                            break;
                        case "40":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 4, scale));
                            break;
                        case "50":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 5, scale));
                            break;
                        case "60":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 6, scale));
                            break;
                        case "70":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 7, scale));
                            break;
                        // Color Pads
                        case "c0":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 0, scale));
                            break;
                        case "c1":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 1, scale));
                            break;
                        case "c2":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 2, scale));
                            break;
                        case "c3":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 3, scale));
                            break;
                        case "c4":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 4, scale));
                            break;
                        case "c5":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 5, scale));
                            break;
                        case "c6":
                            colorPads.Add(new ColorPad(colorPadTexture, new Vector2(i, j), colorId: 6, scale));
                            break;
                        // Player
                        case "p0":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 0, scale, _graphics, walls, colorPads);
                            break;
                        case "p1":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 1, scale, _graphics, walls, colorPads);
                            break;
                        case "p2":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 2, scale, _graphics, walls, colorPads);
                            break;
                        case "p3":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 3, scale, _graphics, walls, colorPads);
                            break;
                        case "p4":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 4, scale, _graphics, walls, colorPads);
                            break;
                        case "p5":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 5, scale, _graphics, walls, colorPads);
                            break;
                        case "p6":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 6, scale, _graphics, walls, colorPads);
                            break;
                        // Goal
                        case "g0":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 0, scale);
                            break;
                        case "g1":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 1, scale);
                            break;
                        case "g2":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 2, scale);
                            break;
                        case "g3":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 3, scale);
                            break;
                        case "g4":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 4, scale);
                            break;
                        case "g5":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 5, scale);
                            break;
                        case "g6":
                            goal = new Goal(goalTexture, new Vector2(i, j), colorId: 6, scale);
                            break;
                    }
                } 
            }
            return (walls, colorPads, player, goal);
        }
    }
}