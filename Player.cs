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
        int numberOfSprite = 7;

        float speed = 100f;
        Vector2 direction;
        bool isMoving = false;

        int colorId = 0; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow

        public Player(Texture2D texture, Vector2 position, int colorId, int scale, GraphicsDeviceManager graphics)
        {
            this.texture = texture;
            this.position = position;
            this.colorId = colorId;
            _graphics = graphics;
            rect = new Rectangle((int)position.X, (int)position.Y, spriteWidth * scale, spriteHeight * scale);
            sourceRect = new Rectangle(spriteWidth*colorId, 0, spriteWidth, spriteHeight );
        }

        public void Inputs(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right) && !isMoving && !(rect.Right >= _graphics.PreferredBackBufferWidth))
            {
                direction.X = 1;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Left) && !isMoving && !(rect.Left <= 0))
            {
                direction.X = -1;
                isMoving = true;
            }

            if (keyboardState.IsKeyDown(Keys.Down) && !isMoving && (rect.Top <= 0))
            {
                direction.Y = 1;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Up) && !isMoving && (rect.Bottom >= _graphics.PreferredBackBufferHeight))
            {
                direction.Y = -1;
                isMoving = true;
            }
        }

        public void Collisions()
        {
            if ((direction.X == 1 && rect.Right >= _graphics.PreferredBackBufferWidth) || (direction.X == -1 && rect.Left <= 0))
            {
                direction.X = 0;
                isMoving = false;
            }

            if ((direction.Y == 1 && rect.Bottom >= _graphics.PreferredBackBufferHeight) || (direction.Y == -1 && rect.Top <= 0))
            {
                direction.Y = 0;
                isMoving = false;
            }
        }

        public void Mouvement(GameTime gameTime)
        {
            rect.X += (int)(direction.X * speed * gameTime.ElapsedGameTime.Milliseconds / 100f);
            rect.Y += (int)(direction.Y * speed * gameTime.ElapsedGameTime.Milliseconds / 100f);
        }

        public void ColorUpdater()
        {
            sourceRect = new Rectangle(colorId*spriteWidth, 0, spriteWidth, spriteHeight);
        }

        // I've to draw and setting up the movements
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            ColorUpdater();
            Inputs(keyboardState);
            Mouvement(gameTime);
            Collisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}