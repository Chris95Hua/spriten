using System.Drawing;
using static Spriten.Utility.SpriteHelper;

namespace Spriten.Data
{
    public struct SpriteSettings
    {
        public int Scale, SpriteCount, PaddingX, PaddingY, OuterMargin;
        public double Noise, FillBrightness, EdgeBrightness;
        public bool MirrorX, MirrorY, RandomFromGroup, ExportIndividual, UseLayerSeed;
        public Shading Shading;
        public ColorMode ColorMode;
        public Color FillColor, EdgeColor;
    }
}
