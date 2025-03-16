using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Coloured_Maze
{
    class Player
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rect;
        Rectangle sourceRect;

        int spriteWidth = 16;
        int spriteHeight = 16;
        int numberOfSprite = 7;

        int speed = 100;
        Vector2 direction;
        bool isMoving = false;

        int colorId = 0; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow
        Color color;

        public Player(Texture2D texture, Vector2 position, int scale)
        {
            this.texture = texture;
            this.position = position;
            rect = new Rectangle((int)position.X, (int)position.Y, spriteWidth*scale, spriteHeight*scale);
            sourceRect = rect;
        }

        public void Inputs(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right) && !isMoving)
            {
                direction.X = 1;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Left) && !isMoving)
            {
                direction.X = -1;
                isMoving = true;
            }
        }

        public void Mouvement(GameTime gameTime)
        {
            rect.X += (int)direction.X * speed * gameTime.ElapsedGameTime.Seconds;
            rect.Y += (int)direction.Y * speed * gameTime.ElapsedGameTime.Seconds;
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}