using Spriten.Drawing;
using System;
using System.Collections.Generic;

namespace Spriten.Data
{
    /// <summary>
    /// Project session
    /// </summary>
    [Serializable]
    public class Project
    {
        #region Properties

        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastSaved { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<DrawableMask> DrawableList { get; set; }
        public int ThumbnailWidth { get; private set; }
        public int ThumbnailHeight { get; private set; }
        public int ThumbnailX { get; private set; }
        public int ThumbnailY { get; private set; }
        private bool mUseMask;
        #endregion

        #region Constructors

        /// <summary>
        /// Create an empty project
        /// </summary>
        public Project()
        {
            ThumbnailWidth = ThumbnailHeight = 38;
            DrawableList = new List<DrawableMask>();
        }

        /// <summary>
        /// Create a project with the specified width, height, title and mask option
        /// </summary>
        /// <param name="width">Width of the project's canvas (in pixel)</param>
        /// <param name="height">Height of the project's canvas (in pixel)</param>
        /// <param name="title">Title of the project</param>
        /// <param name="useMask">Use mask for this project</param>
        public Project(int width, int height, string title, bool useMask) : this()
        {
            Width = width;
            Height = height;
            Title = title;
            IsUsingMask = useMask;

            CalculateThumbnailSize();
        }

        #endregion

        private void CalculateThumbnailSize()
        {
            int oriWidth = ThumbnailWidth, oriHeight = ThumbnailHeight;
            double scaleFactor, aspectRatio = Width / Height;

            if (1 > aspectRatio)
                scaleFactor = (double)ThumbnailHeight / Height;
            else
                scaleFactor = (double)ThumbnailWidth / Width;

            ThumbnailWidth = (int)Math.Floor(Width * scaleFactor);
            ThumbnailHeight = (int)Math.Floor(Height * scaleFactor);

            ThumbnailX = (oriWidth - ThumbnailWidth) / 2;
            ThumbnailY = (oriHeight - ThumbnailHeight) / 2;
        }

        public void Cleanup()
        {
            for (int i = DrawableList.Count - 1; i >= 0; i--)
            {
                DrawableList[i].Dispose();
            }
        }

        public bool IsUsingMask
        {
            get
            {
                return mUseMask;
            }
            set
            {
                if (mUseMask != value)
                {
                    for (int i = DrawableList.Count - 1; i >= 0; i--)
                    {
                        DrawableList[i].IsUsingMask = value;
                    }

                    mUseMask = value;
                }
            }
        }
    }
}
