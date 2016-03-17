using UnityEngine;

namespace RepeatingBackground
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    [ExecuteInEditMode]
    public class GridBackground : AProceduralBackground
    {
        public uint pixelsPerUnit = 96;
        public float squareSize = 1;
        public uint lineThickness = 2;

        public Color32 lineColor = new Color(255, 0, 255, 255);
        public Color32 BackgroundColor = new Color32(255, 255, 255, 255);

        protected override uint width { get { return (uint)(pixelsPerUnit * squareSize); } }
        protected override uint height { get { return (uint)(pixelsPerUnit * squareSize); } }

        protected override Color32 ColorForPixel(uint i, uint j, uint width, uint height)
        {
            return i < lineThickness || j < lineThickness ? lineColor : BackgroundColor;
        }

        protected override Vector2 textureUnitSize
        {
            get
            {
                return new Vector2(squareSize, squareSize);
            }
        }
    }
}
