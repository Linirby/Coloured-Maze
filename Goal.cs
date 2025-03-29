using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coloured_Maze
{
    class Goal
    {
        Texture2D texture;
        public Rectangle rect;
        Rectangle sourceRect;

        int spriteWidth = 16;
        int spriteHeight = 16;

        int colorId; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow

        public Goal(Texture2D texture, Vector2 position, int colorId, int scale)
        {
            this.texture = texture;
            this.colorId = colorId;
            rect = new Rectangle((int)position.X*spriteWidth*scale, (int)position.Y*spriteHeight*scale, spriteWidth * scale, spriteHeight * scale);
            sourceRect = new Rectangle(spriteWidth*colorId, 0, spriteWidth, spriteHeight);
        }

        public bool IsReached(Player player)
        {
            if (player.rect.Intersects(rect) && player.colorId == colorId)
            {
                Console.WriteLine("Goal Reached !");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}