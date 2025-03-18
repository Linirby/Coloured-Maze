using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Coloured_Maze
{
    class Wall
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rect;
        Rectangle sourceRect;

        int spriteWidth = 16;
        int spriteHeight = 16;
        int numberOfSprite = 7;

        int colorId = 0; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow
        int wallId = 1; // 1: single, 2: left, 3: right, 4: bottom, 5: top, 6: horizontal, 7: vertical

        public Wall(Texture2D texture, Vector2 position, int colorId, int wallId, int scale)
        {
            this.texture = texture;
            this.position = position;
            this.colorId = colorId;
            this.wallId = wallId;
            rect = new Rectangle((int)position.X, (int)position.Y, spriteWidth * scale, spriteHeight * scale);
            sourceRect = new Rectangle(spriteWidth*(wallId-1), spriteHeight*(colorId), spriteWidth, spriteHeight);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}