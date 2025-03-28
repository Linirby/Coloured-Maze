using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coloured_Maze
{
    class Glass
    {
        Texture2D texture;
        public Rectangle rect;
        Rectangle sourceRect;

        int spriteWidth = 16;
        int spriteHeight = 16;

        public int colorId = 0; // 0: white, 1: red, 2: green, 3: blue, 4: cyan, 5: magenta, 6: yellow
        int glassId = 1; // 1: single, 2: left, 3: right, 4: bottom, 5: top, 6: horizontal, 7: vertical

        public Glass(Texture2D texture, Vector2 position, int colorId, int glassId, int scale)
        {
            this.texture = texture;
            this.colorId = colorId;
            this.glassId = glassId;
            rect = new Rectangle((int)position.X*spriteWidth*scale, (int)position.Y*spriteHeight*scale, spriteWidth*scale, spriteHeight*scale);
            sourceRect = new Rectangle(spriteWidth*(glassId - 1), spriteHeight*colorId, spriteWidth, spriteHeight);
        }

        public void SpriteUpdate()
        {
            sourceRect = new Rectangle(spriteWidth*(glassId - 1), spriteHeight*colorId, spriteWidth, spriteHeight);
        }

        public void Update()
        {
            SpriteUpdate();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}