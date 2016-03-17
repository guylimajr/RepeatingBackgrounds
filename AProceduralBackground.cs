using UnityEngine;

namespace RepeatingBackground
{
    public abstract class AProceduralBackground : ARepeatingBackground
    {
        protected abstract uint width { get; }
        protected abstract uint height { get; }

        protected override Texture2D texture
        {
            get
            {
                var w = width;
                var h = height;
                var texture = new Texture2D((int)w, (int)h);
                var pixels = new Color32[w * h];
                for (uint i = 0; i < w; i++)
                {
                    for (uint j = 0; j < h; j++)
                    {
                        pixels[w * j + i] = ColorForPixel(i, j, w, h);
                    }
                }
                texture.SetPixels32(pixels);
                texture.Apply();
                return texture;
            }
        }

        protected abstract Color32 ColorForPixel(uint i, uint j, uint width, uint height);
    }
}
