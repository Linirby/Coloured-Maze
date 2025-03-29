using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coloured_Maze
{
    class Level
    {
        string[,] mapArray;
        int arrayWidth;
        int arrayHeight;

        Texture2D wallTexture;
        Texture2D glassTexture;
        Texture2D colorPadTexture;
        Texture2D playerTexture;
        Texture2D goalTexture;
        int scale;
        GraphicsDeviceManager _graphics;

        List<Wall> walls;
        List<Glass> glassWalls;
        List<ColorPad> colorPads;
        Player player;
        Goal goal;


        public Level(string[,] array, Texture2D wallTexture, Texture2D glassTexture, Texture2D colorPadTexture, Texture2D playerTexture, Texture2D goalTexture, int scale, GraphicsDeviceManager _graphics)
        {
            this.wallTexture = wallTexture;
            this.glassTexture = glassTexture;
            this.colorPadTexture = colorPadTexture;
            this.playerTexture = playerTexture;
            this.goalTexture = goalTexture;
            this.scale = scale;
            this._graphics = _graphics;
            walls = new List<Wall>();
            glassWalls = new List<Glass>();
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
        // Walls      -> "W{wallId}{colorId}"
        // Glasses    -> "G{glassId}{colorId}"
        // Color Pads -> "c{colorId}"
        // Player     -> "p{colorId}"
        // Goal       -> "g{colorId}"
        public (List<Wall>, List<Glass>, List<ColorPad>, Player, Goal) Load()
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
                        case "W10":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 1, scale));
                            break;
                        case "W20":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 2, scale));
                            break;
                        case "W30":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 3, scale));
                            break;
                        case "W40":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 4, scale));
                            break;
                        case "W50":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 5, scale));
                            break;
                        case "W60":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 6, scale));
                            break;
                        case "W70":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 0, wallId: 7, scale));
                            break;
                        case "W11":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 1, scale));
                            break;
                        case "W21":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 2, scale));
                            break;
                        case "W31":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 3, scale));
                            break;
                        case "W41":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 4, scale));
                            break;
                        case "W51":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 5, scale));
                            break;
                        case "W61":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 6, scale));
                            break;
                        case "W71":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 1, wallId: 7, scale));
                            break;
                        case "W12":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 1, scale));
                            break;
                        case "W22":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 2, scale));
                            break;
                        case "W32":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 3, scale));
                            break;
                        case "W42":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 4, scale));
                            break;
                        case "W52":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 5, scale));
                            break;
                        case "W62":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 6, scale));
                            break;
                        case "W72":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 2, wallId: 7, scale));
                            break;
                        case "W13":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 1, scale));
                            break;
                        case "W23":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 2, scale));
                            break;
                        case "W33":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 3, scale));
                            break;
                        case "W43":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 4, scale));
                            break;
                        case "W53":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 5, scale));
                            break;
                        case "W63":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 6, scale));
                            break;
                        case "W73":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 3, wallId: 7, scale));
                            break;
                        case "W14":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 1, scale));
                            break;
                        case "W24":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 2, scale));
                            break;
                        case "W34":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 3, scale));
                            break;
                        case "W44":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 4, scale));
                            break;
                        case "W54":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 5, scale));
                            break;
                        case "W64":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 6, scale));
                            break;
                        case "W74":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 4, wallId: 7, scale));
                            break;
                        case "W15":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 1, scale));
                            break;
                        case "W25":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 2, scale));
                            break;
                        case "W35":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 3, scale));
                            break;
                        case "W45":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 4, scale));
                            break;
                        case "W55":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 5, scale));
                            break;
                        case "W65":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 6, scale));
                            break;
                        case "W75":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 5, wallId: 7, scale));
                            break;
                        case "W16":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 1, scale));
                            break;
                        case "W26":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 2, scale));
                            break;
                        case "W36":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 3, scale));
                            break;
                        case "W46":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 4, scale));
                            break;
                        case "W56":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 5, scale));
                            break;
                        case "W66":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 6, scale));
                            break;
                        case "W76":
                            walls.Add(new Wall(wallTexture, new Vector2(i, j), colorId: 6, wallId: 7, scale));
                            break;

                        // Glasses
                        case "G10":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 1, scale));
                            break;
                        case "G20":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 2, scale));
                            break;
                        case "G30":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 3, scale));
                            break;
                        case "G40":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 4, scale));
                            break;
                        case "G50":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 5, scale));
                            break;
                        case "G60":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 6, scale));
                            break;
                        case "G70":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 0, glassId: 7, scale));
                            break;
                        case "G11":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 1, scale));
                            break;
                        case "G21":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 2, scale));
                            break;
                        case "G31":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 3, scale));
                            break;
                        case "G41":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 4, scale));
                            break;
                        case "G51":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 5, scale));
                            break;
                        case "G61":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 6, scale));
                            break;
                        case "G71":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 1, glassId: 7, scale));
                            break;
                        case "G12":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 1, scale));
                            break;
                        case "G22":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 2, scale));
                            break;
                        case "G32":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 3, scale));
                            break;
                        case "G42":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 4, scale));
                            break;
                        case "G52":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 5, scale));
                            break;
                        case "G62":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 6, scale));
                            break;
                        case "G72":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 2, glassId: 7, scale));
                            break;
                        case "G13":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 1, scale));
                            break;
                        case "G23":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 2, scale));
                            break;
                        case "G33":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 3, scale));
                            break;
                        case "G43":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 4, scale));
                            break;
                        case "G53":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 5, scale));
                            break;
                        case "G63":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 6, scale));
                            break;
                        case "G73":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 3, glassId: 7, scale));
                            break;
                        case "G14":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 1, scale));
                            break;
                        case "G24":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 2, scale));
                            break;
                        case "G34":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 3, scale));
                            break;
                        case "G44":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 4, scale));
                            break;
                        case "G54":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 5, scale));
                            break;
                        case "G64":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 6, scale));
                            break;
                        case "G74":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 4, glassId: 7, scale));
                            break;
                        case "G15":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 1, scale));
                            break;
                        case "G25":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 2, scale));
                            break;
                        case "G35":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 3, scale));
                            break;
                        case "G45":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 4, scale));
                            break;
                        case "G55":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 5, scale));
                            break;
                        case "G65":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 6, scale));
                            break;
                        case "G75":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 5, glassId: 7, scale));
                            break;
                        case "G16":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 1, scale));
                            break;
                        case "G26":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 2, scale));
                            break;
                        case "G36":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 3, scale));
                            break;
                        case "G46":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 4, scale));
                            break;
                        case "G56":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 5, scale));
                            break;
                        case "G66":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 6, scale));
                            break;
                        case "G76":
                            glassWalls.Add(new Glass(glassTexture, new Vector2(i, j), colorId: 6, glassId: 7, scale));
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
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 0, scale, _graphics, walls, glassWalls, colorPads);
                            break;
                        case "p1":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 1, scale, _graphics, walls, glassWalls, colorPads);
                            break;
                        case "p2":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 2, scale, _graphics, walls, glassWalls, colorPads);
                            break;
                        case "p3":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 3, scale, _graphics, walls, glassWalls, colorPads);
                            break;
                        case "p4":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 4, scale, _graphics, walls, glassWalls, colorPads);
                            break;
                        case "p5":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 5, scale, _graphics, walls, glassWalls, colorPads);
                            break;
                        case "p6":
                            player = new Player(playerTexture, new Vector2(i, j), colorId: 6, scale, _graphics, walls, glassWalls, colorPads);
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
            return (walls, glassWalls, colorPads, player, goal);
        }
    }
}