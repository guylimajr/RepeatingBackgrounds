using UnityEngine;

namespace RepeatingBackground
{
    public class CheckeredBackground : AProceduralBackground
    {
        public float squareSize = 1;
        public uint pixelsPerUnit = 96;

        public Color32 colorA = new Color32(255, 255, 0, 255);
        public Color32 colorB = new Color32(255, 255, 255, 255);

        protected override uint width { get { return (uint)(squareSize * 2f * pixelsPerUnit); } }
        protected override uint height { get { return (uint)(squareSize * 2f * pixelsPerUnit); } }

        protected override Color32 ColorForPixel(uint i, uint j, uint width, uint height)
        {
            return Mathf.FloorToInt(i / (width / 2f)) == Mathf.FloorToInt(j / (height / 2f)) ? colorA : colorB;
        }

        protected override Vector2 textureUnitSize
        {
            get
            {
                return new Vector2(squareSize * 2f, squareSize * 2f);
            }
        }
    }
}
