using Spriten.Data;
using Spriten.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Spriten.Utility
{
    public static class SpriteHelper
    {
        public const byte EMPTY = 0;
        public const byte BODY = 1;
        public const byte EMPTY_BODY = 2;
        public const byte BORDER_BODY = 3;
        public const byte BORDER = 4;

        public enum Mask
        {
            Border, Body, BorderBody, EmptyBody
        }

        public enum Shading
        {
            Default, Vertical, Horizontal, None
        }

        public enum ColorMode
        {
            Default, Random, Fill
        }

        private static readonly Random mRandom = new Random();

        public static Bitmap GenerateSprite(DrawableMask drawable, SpriteSettings settings)
        {
            // cast layer to group, randomly select a layer
            if (settings.RandomFromGroup && !drawable.IsLayer)
            {
                LayerMaskGroup group = (LayerMaskGroup)drawable;
                int randomIndex = mRandom.Next(0, group.DrawableMaskList.Count);
                return GenerateSprite(group.DrawableMaskList[randomIndex], settings);
            }

            int width = drawable.Width;
            int height = drawable.Height;
            int oriSize = width * height;
            int outputWidth = settings.MirrorX ? width * 2 : width;
            int outputHeight = settings.MirrorY ? height * 2 : height;

            LayerMask layer;

            if (drawable.IsLayer)
                layer = (LayerMask)drawable.GetCopy("copy");
            else
                layer = new LayerMask(drawable.Name, drawable.Project, drawable.Bitmap, drawable.Mask);

            byte[] spriteMask = new byte[outputWidth * outputHeight];
            int[] spriteData = new int[outputWidth * outputHeight];
            GCHandle spriteHandle = GCHandle.Alloc(spriteData, GCHandleType.Pinned);
            Bitmap sprite = new Bitmap(outputWidth, outputHeight, outputWidth * 4, PixelFormat.Format32bppPArgb, spriteHandle.AddrOfPinnedObject());
            
            int val;

            // apply mask and generate random sample
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    val = x + (y * outputWidth);
                    spriteMask[val] = layer.MaskBytes[x + (y * width)];

                    if (spriteMask[val] == EMPTY_BODY && mRandom.Next(11) >= 5)
                        spriteMask[val] = EMPTY;
                    else if (spriteMask[val] == BORDER_BODY && mRandom.Next(11) >= 5)
                        spriteMask[val] = BORDER;
                }
            }

            // generate edges
            for (int y = 0; y < outputHeight; y++)
            {
                for (int x = 0; x < outputWidth; x++)
                {
                    val = x + (y * outputWidth);

                    if (spriteMask[val] == EMPTY_BODY || spriteMask[val] == BORDER_BODY || spriteMask[val] == BODY)
                    {
                        val = x + ((y - 1) * outputWidth);
                        if (y - 1 >= 0 && spriteMask[val] == EMPTY)
                            spriteMask[val] = BORDER;

                        val = x + ((y + 1) * outputWidth);
                        if (y + 1 < outputHeight && spriteMask[val] == EMPTY)
                            spriteMask[val] = BORDER;

                        val = x - 1 + (y * outputWidth);
                        if (x - 1 >= 0 && spriteMask[val] == EMPTY)
                            spriteMask[val] = BORDER;

                        val = x + 1 + (y * outputWidth);
                        if (x + 1 < outputWidth && spriteMask[val] == EMPTY)
                            spriteMask[val] = BORDER;
                    }
                }
            }

            // render pixel data
            double calcBrightness, shading;
            int argbColor, edgeColor = 0;

            if (settings.EdgeColor != Color.Transparent)
                edgeColor = settings.EdgeColor.ToArgb();           

            if (settings.ColorMode == ColorMode.Fill)
                argbColor = settings.FillColor.ToArgb();
            else
                argbColor = Color.FromArgb(mRandom.Next(256), mRandom.Next(256), mRandom.Next(256)).ToArgb();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    val = x + (y * outputWidth);

                    // Render sprite
                    if (spriteMask[val] != EMPTY)
                    {
                        // coloring
                        if (settings.ColorMode == ColorMode.Default)
                            spriteData[val] = layer.BitmapBits[x + (y * width)];
                        else
                            spriteData[val] = argbColor;

                        // shading
                        if (settings.Shading != Shading.None)
                        {
                            if (settings.Shading == Shading.Horizontal || (settings.Shading == Shading.Default && settings.MirrorY))
                                shading = (double)y / outputHeight;
                            else if (settings.Shading == Shading.Vertical || (settings.Shading == Shading.Default && settings.MirrorX))
                                shading = (double)x / outputWidth;
                            else
                                shading = 1;

                            calcBrightness = Math.Sin(shading * Math.PI) * settings.FillBrightness + mRandom.NextDouble() * settings.Noise;
                            spriteData[val] = ControlPaint.Light(Color.FromArgb(spriteData[val]), (float)calcBrightness).ToArgb();
                        }

                        // coloring edge
                        if (spriteMask[val] == BORDER)
                        {
                            // use custom colour
                            if (settings.EdgeColor != Color.Empty)
                                spriteData[val] = edgeColor;
                            // darken default pixel color
                            else
                                spriteData[val] = ControlPaint.Dark(Color.FromArgb(spriteData[val]), (float)settings.EdgeBrightness).ToArgb();
                        }

                        if (settings.MirrorX)
                            spriteData[outputWidth - 1 - x + (y * outputWidth)] = spriteData[val];

                        if (settings.MirrorY)
                            spriteData[x + ((outputHeight - 1 - y) * outputWidth)] = spriteData[val];

                        if (settings.MirrorX && settings.MirrorY)
                            spriteData[outputWidth - 1 - x + ((outputHeight - 1 - y) * outputWidth)] = spriteData[val];
                    }
                }
            }
            layer.Dispose();
            spriteHandle.Free();

            return sprite;
        }
        
        public static Bitmap GenerateSprite(List<DrawableMask> drawables, SpriteSettings settings)
        {
            int spriteWidth = settings.MirrorX ? drawables[0].Width * 2 * settings.Scale : drawables[0].Width * settings.Scale;
            int spriteHeight = settings.MirrorY ? drawables[0].Height * 2 * settings.Scale : drawables[0].Height * settings.Scale;

            Bitmap outputImage = new Bitmap(spriteWidth + (2 * settings.OuterMargin), spriteHeight + (2 * settings.OuterMargin), PixelFormat.Format32bppPArgb);
            Graphics outputGraphics = Graphics.FromImage(outputImage);
            outputGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            outputGraphics.SmoothingMode = SmoothingMode.None;
            outputGraphics.PixelOffsetMode = PixelOffsetMode.Half;

            // setup
            Bitmap temp;

            if (settings.UseLayerSeed)
            {
                for (int i = drawables.Count - 1; i >= 0; i--)
                {
                    using (temp = GenerateSprite(drawables[i], settings))
                    {
                        outputGraphics.DrawImage(temp, settings.OuterMargin, settings.OuterMargin, spriteWidth, spriteHeight);
                    }
                }
            }
            else
            {
                DrawableMask combined = MergeDrawableMaskList(drawables, settings.RandomFromGroup);
                outputGraphics.DrawImage(GenerateSprite(combined, settings), settings.OuterMargin, settings.OuterMargin, spriteWidth, spriteHeight);
            }

            outputGraphics.Dispose();

            return outputImage;
        }

        public static Bitmap GenerateSpriteAtlas(List<DrawableMask> drawables, SpriteSettings settings, int spriteCount, int spritePerRow)
        {
            int spritePerCol;
            if (spriteCount > 0 && (spritePerRow == 0 || spritePerRow > spriteCount))
            {
                spritePerRow = (int)Math.Ceiling((double)spriteCount / 2);
                spritePerCol = (int)Math.Ceiling((double)spriteCount / spritePerRow);
            }
            else
            {
                spritePerCol = (int)Math.Ceiling((double)spriteCount / spritePerRow);
            }
            int layerWidth = drawables[0].Width;
            int layerHeight = drawables[0].Height;
            int spriteWidth = settings.MirrorX ? layerWidth * 2 * settings.Scale : layerWidth * settings.Scale;
            int spriteHeight = settings.MirrorY ? layerHeight * 2 * settings.Scale : layerHeight * settings.Scale;
            int atlasWidth = (settings.OuterMargin * 2) + (settings.PaddingX * (spritePerRow - 1)) + (spriteWidth * spritePerRow);
            int atlasHeight = (settings.OuterMargin * 2) + (settings.PaddingY * (spritePerCol - 1)) + (spriteHeight * spritePerCol);

            Bitmap atlasImage = new Bitmap(atlasWidth, atlasHeight, PixelFormat.Format32bppPArgb);
            Graphics atlasGraphics = Graphics.FromImage(atlasImage);
            atlasGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            atlasGraphics.SmoothingMode = SmoothingMode.None;
            atlasGraphics.PixelOffsetMode = PixelOffsetMode.Half;

            int x = settings.OuterMargin, y = x;
            int xBoundary = settings.OuterMargin + (spriteWidth * spritePerRow) + (settings.PaddingX * (spritePerRow - 1));

            //atlasGraphics.Clear(Color.Transparent);
            Bitmap temp;
            for (int i = 0; i < spriteCount; i++)
            {
                if (settings.UseLayerSeed)
                {
                    for (int c = drawables.Count - 1; c >= 0; c--)
                    {
                        temp = GenerateSprite(drawables[c], settings);
                        atlasGraphics.DrawImage(temp, x, y, spriteWidth, spriteHeight);
                        temp.Dispose();
                    }
                }
                else
                {
                    DrawableMask combined = MergeDrawableMaskList(drawables, settings.RandomFromGroup);
                    atlasGraphics.DrawImage(GenerateSprite(combined, settings), x, y, spriteWidth, spriteHeight);
                    combined.Dispose();
                }

                if (x + settings.PaddingX + spriteWidth >= xBoundary)
                {
                    x = settings.OuterMargin;
                    y += settings.PaddingY + spriteHeight;
                }
                else
                {
                    x += settings.PaddingX + spriteWidth;
                }
            }

            atlasGraphics.Dispose();

            return atlasImage;
        }

        private static DrawableMask MergeDrawableMaskList(List<DrawableMask> drawables, bool randomFromGroup)
        {
            int width = drawables[0].Width;
            int height = drawables[0].Height;
            Project project = drawables[0].Project;

            Bitmap temp = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            Graphics tempGraphics = Graphics.FromImage(temp);
            tempGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            tempGraphics.SmoothingMode = SmoothingMode.None;
            tempGraphics.PixelOffsetMode = PixelOffsetMode.Half;
            Bitmap tempMask = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            Graphics tempMaskGraphics = Graphics.FromImage(tempMask);
            tempMaskGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            tempMaskGraphics.SmoothingMode = SmoothingMode.None;
            tempMaskGraphics.PixelOffsetMode = PixelOffsetMode.Half;

            // Combine all layer and generate sprite
            for (int i = drawables.Count - 1; i >= 0; i--)
            {
                DrawableMask toDraw = drawables[i];

                // if group
                if (randomFromGroup && !toDraw.IsLayer)
                    toDraw = RandomSelectLayer((LayerMaskGroup)drawables[i]);

                tempGraphics.DrawImageUnscaled(toDraw.Bitmap, 0, 0, width, height);
                tempMaskGraphics.DrawImageUnscaled(toDraw.Mask, 0, 0, width, height);
            }

            tempGraphics.Dispose();
            tempMaskGraphics.Dispose();

            return new LayerMask("flatten", project, temp, tempMask);
        }

        private static LayerMask RandomSelectLayer(LayerMaskGroup group)
        {
            int index = mRandom.Next(0, group.DrawableMaskList.Count);

            DrawableMask selected = group.DrawableMaskList[index];
            if (selected.IsLayer)
                return (LayerMask)selected;
            else
                return RandomSelectLayer((LayerMaskGroup)selected);
        }
    }
}