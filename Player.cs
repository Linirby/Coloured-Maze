using System;
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
        Vector2 position;
        Rectangle rect;
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

        int colorId = 0; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow

        List<Wall> walls;

        public Player(Texture2D texture, Vector2 position, int colorId, int scale, GraphicsDeviceManager graphics, List<Wall> walls)
        {
            this.texture = texture;
            this.position = position;
            this.colorId = colorId;
            _graphics = graphics;
            this.walls = walls;
            rect = new Rectangle((int)position.X*spriteWidth*scale, (int)position.Y*spriteHeight*scale, spriteWidth * scale, spriteHeight * scale);
            sourceRect = new Rectangle(spriteWidth*colorId, 0, spriteWidth, spriteHeight );
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
                Console.WriteLine("I'm Falling! Oh nah I'm just going down -_-");
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

        public void Collisions()
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

            foreach (Wall wall in walls)
            {
                if (rect.Intersects(wall.rect))
                {   
                    if (direction.X == 1 && rect.Right >= wall.rect.Left)
                    {
                        rect.X = wall.rect.Left - rect.Width;
                        direction.X = 0;
                        canMove = false;
                        canGoRight = false;
                        break;
                    }
                    if (direction.X == -1 && rect.Left <= wall.rect.Right)
                    {
                        rect.X = wall.rect.Right;
                        direction.X = 0;
                        canMove = false;
                        canGoLeft = false;
                        break;
                    }
                    if (direction.Y == 1 && rect.Bottom > wall.rect.Top)
                    {
                        rect.Y = wall.rect.Top - rect.Width;
                        direction.Y = 0;
                        canMove = false;
                        canGoDown = false;
                        break;
                    }
                    if (direction.Y == -1 && rect.Top < wall.rect.Bottom)
                    {
                        rect.Y = wall.rect.Bottom;
                        direction.Y = 0;
                        canMove = false;
                        canGoUp = false;
                        Console.WriteLine("Ouch my head !");
                        break;
                    }
                }
            }
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