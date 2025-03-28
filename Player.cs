using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Coloured_Maze
{
    class Player
    {
        private GraphicsDeviceManager _graphics;

        Texture2D texture;
        public Rectangle rect;
        Rectangle sourceRect;

        int spriteWidth = 16;
        int spriteHeight = 16;

        float speed = 100f;
        Vector2 direction;
        bool canMove = false;
        bool canGoRight = true;
        bool canGoLeft = true;
        bool canGoDown = true;
        bool canGoUp = true;
        bool isCollidingWithColorPad = false;

        public int colorId = 0; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow

        List<Wall> walls;
        List<Glass> glassWalls;
        List<ColorPad> colorPads;

        public Player(Texture2D texture, Vector2 position, int colorId, int scale, GraphicsDeviceManager graphics, List<Wall> walls, List<Glass> glassWalls, List<ColorPad> colorPads)
        {
            this.texture = texture;
            this.colorId = colorId;
            _graphics = graphics;
            this.walls = walls;
            this.glassWalls = glassWalls;
            this.colorPads = colorPads; 
            rect = new Rectangle((int)position.X*spriteWidth*scale, (int)position.Y*spriteHeight*scale, spriteWidth * scale, spriteHeight * scale);
            sourceRect = new Rectangle(spriteWidth*colorId, 0, spriteWidth, spriteHeight);
        }

        public void Inputs(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right) && canGoRight && !canMove && !(rect.Right >= _graphics.PreferredBackBufferWidth))
            {
                direction.X = 1;
                canMove = true;
                canGoLeft = true;
                canGoDown = true;
                canGoUp = true;
            }
            if (keyboardState.IsKeyDown(Keys.Left) && canGoLeft && !canMove && !(rect.Left <= 0))
            {
                direction.X = -1;
                canMove = true;
                canGoRight = true;
                canGoDown = true;
                canGoUp = true;
            }

            if (keyboardState.IsKeyDown(Keys.Down) && canGoDown && !canMove && !(rect.Bottom >= _graphics.PreferredBackBufferHeight))
            {
                direction.Y = 1;
                canMove = true;
                canGoLeft = true;
                canGoRight = true;
                canGoUp = true;
            }
            if (keyboardState.IsKeyDown(Keys.Up) && canGoUp && !canMove && !(rect.Top <= 0))
            {
                direction.Y = -1;
                canMove = true;
                canGoLeft = true;
                canGoDown = true;
                canGoRight = true;
            }
        }

        public void WallsCollisions()
        {
            foreach (Wall wall in walls)
            {
                if (rect.Intersects(wall.rect))
                {   
                    canMove = false;

                    if (direction.X == 1 && rect.Right >= wall.rect.Left)
                    {
                        rect.X = wall.rect.Left - rect.Width;
                        direction.X = 0;
                        canGoRight = false;
                        break;
                    }
                    if (direction.X == -1 && rect.Left <= wall.rect.Right)
                    {
                        rect.X = wall.rect.Right;
                        direction.X = 0;
                        canGoLeft = false;
                        break;
                    }

                    if (direction.Y == 1 && rect.Bottom > wall.rect.Top)
                    {
                        rect.Y = wall.rect.Top - rect.Width;
                        direction.Y = 0;
                        canGoDown = false;
                        break;
                    }
                    if (direction.Y == -1 && rect.Top < wall.rect.Bottom)
                    {
                        rect.Y = wall.rect.Bottom;
                        direction.Y = 0;
                        canGoUp = false;
                        break;
                    }
                }
            }
        }

        public void GlassesCollisions()
        {
            foreach (Glass glass in glassWalls)
            {
                if (rect.Intersects(glass.rect) && colorId != glass.colorId)
                {   
                    canMove = false;

                    if (direction.X == 1 && rect.Right >= glass.rect.Left)
                    {
                        rect.X = glass.rect.Left - rect.Width;
                        direction.X = 0;
                        canGoRight = false;
                        break;
                    }
                    if (direction.X == -1 && rect.Left <= glass.rect.Right)
                    {
                        rect.X = glass.rect.Right;
                        direction.X = 0;
                        canGoLeft = false;
                        break;
                    }

                    if (direction.Y == 1 && rect.Bottom > glass.rect.Top)
                    {
                        rect.Y = glass.rect.Top - rect.Width;
                        direction.Y = 0;
                        canGoDown = false;
                        break;
                    }
                    if (direction.Y == -1 && rect.Top < glass.rect.Bottom)
                    {
                        rect.Y = glass.rect.Bottom;
                        direction.Y = 0;
                        canGoUp = false;
                        break;
                    }
                }
            }
        }

        public void ColorChanges()
        {
            foreach (ColorPad colorPad in colorPads)
            {
                if (rect.Intersects(colorPad.rect))
                {
                    if ((colorId == 1 && colorPad.colorId == 2) || (colorPad.colorId == 1 && colorId == 2)) // Red + Green
                    {
                        colorId = 6; // Yellow
                        isCollidingWithColorPad = true;
                        break;
                    }
                    else if ((colorId == 1 && colorPad.colorId == 3) || (colorPad.colorId == 1 && colorId == 3)) // Red + Blue
                    {
                        colorId = 5; // Magenta
                        isCollidingWithColorPad = true;
                        break;
                    }
                    else if ((colorId == 1 && colorPad.colorId == 4) || (colorPad.colorId == 1 && colorId == 4)) // Red + Cyan
                    {
                        colorId = 0; // White
                        isCollidingWithColorPad = true;
                        break;
                    }
                    else if ((colorId == 2 && colorPad.colorId == 3) || (colorPad.colorId == 2 && colorId == 3)) // Green + Blue
                    {
                        colorId = 4; // Cyan
                        isCollidingWithColorPad = true;
                        break;
                    }
                    else if ((colorId == 2 && colorPad.colorId == 5) || (colorPad.colorId == 2 && colorId == 5)) // Green + Magenta
                    {
                        colorId = 0; // White
                        isCollidingWithColorPad = true;
                        break;
                    }
                    else if ((colorId == 3 && colorPad.colorId == 6) || (colorPad.colorId == 3 && colorId == 6)) // Blue + Yellow
                    {
                        colorId = 0; // White
                        isCollidingWithColorPad = true;
                        break;
                    }
                    else // Anything else
                    {
                        colorId = colorPad.colorId;
                        isCollidingWithColorPad = true;
                        break;
                    }
                }
            }
        }

        public void ColorPadsCollisions()
        {
            if (isCollidingWithColorPad)
            {
                // Check if the player is still colliding with any color pad
                bool stillColliding = false;
                foreach (ColorPad colorPad in colorPads)
                {
                    if (rect.Intersects(colorPad.rect))
                    {
                        stillColliding = true;
                        break;
                    }
                }
                // If the player is no longer colliding with any color pad, reset the flag
                if (!stillColliding)
                {
                    isCollidingWithColorPad = false;
                }
            }
            else
            {
                ColorChanges();
            }
        }

        public void ScreenCollisions()
        {
            if ((direction.X == 1 && rect.Right >= _graphics.PreferredBackBufferWidth) || (direction.X == -1 && rect.Left <= 0))
            {
                direction.X = 0;
                canMove = false;
            }

            if ((direction.Y == 1 && rect.Bottom >= _graphics.PreferredBackBufferHeight) || (direction.Y == -1 && rect.Top <= 0))
            {
                direction.Y = 0;
                canMove = false;
            }
        }

        public void Collisions()
        {
            WallsCollisions();
            GlassesCollisions();
            ColorPadsCollisions();
            ScreenCollisions();
        }

        public void Mouvement(GameTime gameTime)
        {
            if (canMove)
            {
                rect.X += (int)(direction.X * speed * gameTime.ElapsedGameTime.Milliseconds / 100f);
                rect.Y += (int)(direction.Y * speed * gameTime.ElapsedGameTime.Milliseconds / 100f);
            }
        }

        public void SpriteUpdate()
        {
            sourceRect = new Rectangle(colorId*spriteWidth, 0, spriteWidth, spriteHeight);
        }

        // I've to draw and setting up the movements
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            SpriteUpdate();
            Collisions();
            Inputs(keyboardState);
            Mouvement(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}