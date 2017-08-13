using System;
using System.Drawing;

using WeifenLuo.WinFormsUI.Docking;
using MechanikaDesign.WinForms.UI.ColorPicker;
using Spriten.Data;
using Spriten.Utility;
using System.Windows.Forms;

namespace Spriten.Dock
{
    public enum ColorSelector
    {
        Wheel, Box
    }

    public partial class ColorDock : DockContent
    {
        #region Properties

        private ContextMenu mColorDockMenu;
        private MenuItem mColorBoxItem;
        private MenuItem mColorWheelItem;
        private HslColor mColorHsl = HslColor.FromAhsl(0xff);
        private Color mSelectedColor = User.ForegroundColor;
        private ColorSelector mSelector;
        private bool mLockUpdates = false;
        private ColorBox2D mColorBox;
        private ColorSliderVertical mColorSlider;
        private ColorWheel mColorWheel;

        #endregion

        public Action<Color> SetPrimaryColor;

        #region Constructor

        public ColorDock(ColorSelector selector)
        {
            InitializeComponent();

            SetupContextMenu();
            LoadTheme();
            LoadColorSelector(selector);
        }

        private void LoadColorSelector(ColorSelector selector)
        {
            mSelector = selector;
            DisposeAllSelector();

            switch (mSelector)
            {
                case ColorSelector.Box:
                    SetupColorBox();
                    break;
                case ColorSelector.Wheel:
                    SetupColorWheel();
                    break;
            }
        }

        private void UncheckAllMenuItems()
        {
            for(int i = mColorDockMenu.MenuItems.Count - 1; i >= 0; i--)
            {
                mColorDockMenu.MenuItems[i].Checked = false;
            }
        }

        private void SetupColorBox()
        {
            mColorBox = new ColorBox2D();
            mColorSlider = new ColorSliderVertical();
            mColorSlider.Width = 40;
            mColorSlider.NubColor = ThemeHelper.Foreground;

            mColorBox.ColorChanged += ColorBoxColorChanged;
            mColorSlider.ColorChanged += ColorSliderColorChanged;

            mColorSlider.Dock = DockStyle.Right;
            mColorBox.Dock = DockStyle.Fill;

            mColorBox.ColorMode = ColorModes.Hue;
            mColorSlider.ColorMode = ColorModes.Hue;

            Controls.Add(mColorSlider);
            Controls.Add(mColorBox);

            UpdateRgbFields(User.ForegroundColor);
        }

        private void SetupColorWheel()
        {
            mColorWheel = new ColorWheel();
            mColorWheel.ColorChanged += ColorWheelColorChanged;
            mColorWheel.Dock = DockStyle.Fill;

            mLockUpdates = true;
            mColorWheel.Color = User.ForegroundColor;
            mLockUpdates = false;

            Controls.Add(mColorWheel);
        }

        private void DisposeAllSelector()
        {
            // color box and slider
            if (mColorBox != null)
                mColorBox.Dispose();

            if (mColorSlider != null)
                mColorSlider.Dispose();

            // color wheel
            if (mColorWheel != null)
                mColorWheel.Dispose();
        }

        private void SetupContextMenu()
        {
            mColorBoxItem = new MenuItem("Color Box", ColorBoxItemAction);
            mColorWheelItem = new MenuItem("Color Wheel", ColorWheelItemAction);

            mColorDockMenu = new ContextMenu();
            mColorDockMenu.MenuItems.Add(mColorBoxItem);
            mColorDockMenu.MenuItems.Add(mColorWheelItem);
            TabPageContextMenu = mColorDockMenu;
            TabPageContextMenu.Popup += DockContextMenuPopUp;
        }

        private void LoadTheme()
        {
            BackColor = ThemeHelper.Background;
        }

        #endregion

        private void DockContextMenuPopUp(object sender, EventArgs e)
        {
            switch (mSelector)
            {
                case ColorSelector.Box:
                    mColorBoxItem.Checked = true;
                    break;
                case ColorSelector.Wheel:
                    mColorWheelItem.Checked = true;
                    break;
            }
        }

        private void ColorBoxItemAction(object sender, EventArgs e)
        {
            if (mColorBoxItem.Checked = !mColorBoxItem.Checked)
                LoadColorSelector(User.ColodDockSelector = ColorSelector.Box);

            UncheckAllMenuItems();
        }

        private void ColorWheelItemAction(object sender, EventArgs e)
        {
            if (mColorWheelItem.Checked = !mColorWheelItem.Checked)
                LoadColorSelector(User.ColodDockSelector = ColorSelector.Wheel);

            UncheckAllMenuItems();
        }

        #region Events

        private void ColorWheelColorChanged(object sender, EventArgs args)
        {
            if (!mLockUpdates)
            {
                SetPrimaryColor?.Invoke(mSelectedColor = mColorWheel.Color);
            }
        }

        private void ColorSliderColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!mLockUpdates)
            {
                HslColor colorHSL = mColorSlider.ColorHSL;
                mColorHsl = colorHSL;
                mSelectedColor = mColorHsl.RgbValue;
                mLockUpdates = true;
                mColorBox.ColorHSL = mColorHsl;
                mLockUpdates = false;

                SetPrimaryColor?.Invoke(mSelectedColor);
            }
        }

        private void ColorBoxColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!mLockUpdates)
            {
                HslColor colorHSL = mColorBox.ColorHSL;
                mColorHsl = colorHSL;
                mSelectedColor = mColorHsl.RgbValue;
                mLockUpdates = true;
                mColorSlider.ColorHSL = mColorHsl;
                mLockUpdates = false;

                SetPrimaryColor?.Invoke(mSelectedColor);
            }
        }

        public void UpdateRgbFields(Color color)
        {
            mSelectedColor = color;
            mColorHsl = HslColor.FromColor(color);

            if (mSelector == ColorSelector.Box)
            {
                mColorSlider.ColorHSL = mColorHsl;
                mColorBox.ColorHSL = mColorHsl;
            }
            else if(mSelector == ColorSelector.Wheel)
            {
                mLockUpdates = true;
                mColorWheel.Color = color;
                mLockUpdates = false;
            }
        }

        #endregion

        private void ColorDock_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeAllSelector();
        }
    }
}
