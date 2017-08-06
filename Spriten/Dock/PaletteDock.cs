using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Spriten.Dock
{
    public partial class PaletteDock : DockContent
    {
        public PaletteDock()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void AddColorLabel(Color color)
        {
            Label colorLabel = new Label();
            colorLabel.Width = colorLabel.Height = 12;
            colorLabel.BorderStyle = BorderStyle.FixedSingle;
            colorLabel.BackColor = color;
            pnl_palette.Controls.Add(colorLabel);
        }

        private void RemoveColorLabel()
        {
            
        }

        private void LoadPalette()
        {

        }

        private void SavePalette()
        {

        }
    }

    internal class PaletteColor
    {
        #region Fields

        public Color Color { get; set; }
        public bool IsHovered { get; set; }
        public bool IsSelected { get; set; }
        private int mLength { get; set; }
        private Rectangle mBound;

        #endregion

        #region Constructors

        public PaletteColor()
        {
            mBound = Rectangle.Empty;
        }

        public PaletteColor(Color color) : this()
        {
            Color = color;
        }

        public PaletteColor(Color color, int sideLength) : this(color)
        {
            SideLength = sideLength;
        }

        #endregion

        #region Method

        public void Paint(Graphics g)
        {
            // fill rectangle

            if(IsHovered || IsSelected)
            {
                // draw highlight
            }
        }

        #endregion

        #region Properties

        public Rectangle BoundingRect
        {
            get { return mBound; }
        }

        public int SideLength
        {
            get { return mLength; }

            set
            {
                mLength = value;

                mBound = new Rectangle(0, 0, mLength, mLength);
            }
        }

        #endregion
    }
}
