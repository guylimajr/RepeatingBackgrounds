using UnityEngine;

namespace RepeatingBackground
{
    public class TexturedBackground : ARepeatingBackground
    {
        public Vector2 tileSize = new Vector2(1, 1);
        public Texture2D tiledTexture;

        protected override Texture2D texture
        {
            get { return tiledTexture; }
        }

        protected override Vector2 textureUnitSize
        {
            get
            {
                return tileSize;
            }
        }
    }
}
