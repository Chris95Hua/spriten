using Spriten.Utility;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spriten.CustomControl
{
    public partial class NumericSlider : Control
    {
        public event EventHandler OnValueChanged;
        public string DisplayText { get; set; }
        public string PostFix { get; set; }
        public float Minimum { get; set; }
        public string DisplayStringFormat { get; set; }
        public float Maximum { get; set; }
        public float UpDownStep { get; set; }
        public float MouseWheelStep { get; set; }
        public Color EnabledFill { get; set; }
        public Color DisabledFill { get; set; }
        public float RoundDiameter { get; set; }
        private float mValue;
        private StringFormat mFormat;
        private Brush mEnabledBrush, mDisabledBrush, mTextBrush;
        private Pen mOutlinePen;
        private Rectangle mFillRect;
        private GraphicsPath mControlOutline, mFillPath;
        private Button mIncButton, mDecButton;
        private TextBox mValueBox;
        private bool mEditingText, mRoundUp, mRoundDown;

        public NumericSlider()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            mEnabledBrush = new SolidBrush(ThemeHelper.Hovered);
            mDisabledBrush = new SolidBrush(ThemeHelper.TreeListBackground);
            mOutlinePen = new Pen(ThemeHelper.DockBackColor);
            mTextBrush = new SolidBrush(ThemeHelper.Foreground);
            Anchor = AnchorStyles.None;
            Dock = DockStyle.None;
            Width = 140;
            Height = 32;
            RoundDiameter = 6f;
            DisplayStringFormat = "{0:0.00}";

            mFormat = new StringFormat();
            mFormat.LineAlignment = StringAlignment.Center;
            mFormat.Alignment = StringAlignment.Center;

            InitButtons();
            
            Rectangle outline = ClientRectangle;
            outline.Height -= 1;
            mControlOutline = GetRoundedRect(ClientRectangle, RoundDiameter);
            mFillRect = new Rectangle(0, 0, ClientRectangle.Width - mDecButton.Width - 3, ClientRectangle.Height);
            InitTextBox();

            MouseWheelStep = UpDownStep = 1f;
            Minimum = 1f;
            Maximum = 100f;
        }

        private void InitButtons()
        {
            mIncButton = new Button();
            mDecButton = new Button();

            // style
            mIncButton.Font = mDecButton.Font = new Font("Courier New", 6);
            mIncButton.Text = ((char)0x25B2).ToString();
            mDecButton.Text = ((char)0x25BC).ToString();
            mIncButton.ForeColor = mDecButton.ForeColor = ThemeHelper.Foreground;
            mIncButton.BackColor = mDecButton.BackColor = ThemeHelper.Background;
            mIncButton.FlatStyle = mDecButton.FlatStyle = FlatStyle.Flat;
            mIncButton.FlatAppearance.BorderSize = mDecButton.FlatAppearance.BorderSize = 0;
            mIncButton.TextAlign = mDecButton.TextAlign = ContentAlignment.MiddleCenter;

            // size and position
            int buttonHeight = (int)((float)(ClientRectangle.Height - 2) / 2);
            int buttonWidth = 12;
            int locX = ClientRectangle.Width - buttonWidth - 1;
            mIncButton.Height = mDecButton.Height = buttonHeight;
            mIncButton.Width = mDecButton.Width = buttonWidth;
            mIncButton.Top = 1;
            mIncButton.Left = locX;
            mDecButton.Top = ClientRectangle.Height - buttonHeight - 1;
            mDecButton.Left = locX;

            // event
            mIncButton.MouseUp += IncrementButtonClicked;
            mDecButton.MouseUp += DecrementButtonClicked;

            Controls.Add(mIncButton);
            Controls.Add(mDecButton);
        }

        private void InitTextBox()
        {
            mValueBox = new TextBox();            
            mValueBox.TextAlign = HorizontalAlignment.Center;
            mValueBox.Font = Font;
            mValueBox.BorderStyle = BorderStyle.None;
            mValueBox.Width = mFillRect.Width;
            mValueBox.Left = 1;
            mValueBox.Top = ((ClientRectangle.Height - mValueBox.Height) / 2);

            // events
            mValueBox.KeyDown += new KeyEventHandler(OnValueBoxKeyDown);
            mValueBox.LostFocus += OnValueBoxLostFocus;

            Controls.Add(mValueBox);
            mValueBox.Visible = false;
        }

        #region Value Box Events

        private void OnValueBoxLostFocus(object sender, EventArgs e)
        {
            if (mValueBox.Visible)
                StoreValueBoxValue(e);
        }

        private void OnValueBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                StoreValueBoxValue(e);

            if (e.KeyCode == Keys.Escape)
            {
                mValueBox.Clear();
                mEditingText = mValueBox.Visible = false;
                Invalidate();
            }
        }

        #endregion

        private void StoreValueBoxValue(EventArgs e)
        {
            string input = mValueBox.Text;
            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, "^[0-9]*([.,][0-9]{0,2})?$"))
            {
                Value = float.Parse(input);
                


                OnValueChanged?.Invoke(this, e);
                mEditingText = mValueBox.Visible = false;
                Invalidate();
                mDecButton.Focus();
            }

            mValueBox.Clear();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (mValueBox.Visible)
                mEditingText = mValueBox.Visible = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(ThemeHelper.Pressed);

            if (Enabled)
            {
                if (mEditingText)
                {
                    mFillPath = GetRoundedRect(new Rectangle(0, 0, mFillRect.Width + 1, ClientRectangle.Height - 1), RoundDiameter);
                    pe.Graphics.FillPath(Brushes.White, mFillPath);
                }
                else
                {
                    mFillPath = GetRoundedRect(new Rectangle(0, 0, (int)(mFillRect.Width * ((float)Value / (Maximum - Minimum))), ClientRectangle.Height - 1), RoundDiameter);
                    pe.Graphics.FillPath(mEnabledBrush, mFillPath);
                    pe.Graphics.DrawString(DisplayText + StringValue, Font, mTextBrush, mFillRect, mFormat);
                }
            }
            else
            {
                mFillPath = GetRoundedRect(new Rectangle(0, 0, (int)(mFillRect.Width * ((float)Value / (Maximum - Minimum))), ClientRectangle.Height - 1), RoundDiameter);
                pe.Graphics.FillPath(mDisabledBrush, mFillPath);
                pe.Graphics.DrawString(DisplayText + StringValue, Font, mEnabledBrush, mFillRect, mFormat);
            }

            pe.Graphics.DrawPath(mOutlinePen, mControlOutline);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            mValueBox.Text = string.Format(DisplayStringFormat, Value);
            mEditingText = mValueBox.Visible = true;
            mValueBox.Focus();
            mValueBox.SelectAll();
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // slider
            if (e.Button == MouseButtons.Left)
            {
                Value = (float)e.X / (ClientRectangle.Width - mIncButton.Width - 1) * Maximum;
                OnValueChanged?.Invoke(this, e);
                Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if(e.Delta > 0)
                Value += MouseWheelStep;
            else
                Value -= MouseWheelStep;

            OnValueChanged?.Invoke(this, e);
            Invalidate();
        }

        private void IncrementButtonClicked(object sender, EventArgs e)
        {
            Value += UpDownStep;
            OnValueChanged?.Invoke(this, e);
            Invalidate();
        }

        private void DecrementButtonClicked(object sender, EventArgs e)
        {
            Value -= UpDownStep;
            OnValueChanged?.Invoke(this, e);
            Invalidate();
        }

        private float RoundValue(float value)
        {
            if (mRoundUp)
                return (float)Math.Ceiling((decimal)value);
            else if (mRoundDown)
                return (float)Math.Floor((decimal)value);

            return value;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                mEnabledBrush.Dispose();
                mDisabledBrush.Dispose();
                mOutlinePen.Dispose();
                mTextBrush.Dispose();
                mIncButton.Dispose();
                mDecButton.Dispose();
                mValueBox.Dispose();
                mFormat.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Return a GraphicPath that is round corner rectangle.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="diameter"></param>
        /// <returns></returns>
        protected GraphicsPath GetRoundedRect(Rectangle rect, float diameter)
        {
            GraphicsPath path = new GraphicsPath();

            RectangleF arc = new RectangleF(rect.X, rect.Y, diameter, diameter);
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        public float Value
        {
            get
            {
                return mValue;
            }
            set
            {
                if (value >= Maximum)
                    mValue = Maximum;
                else if (value <= Minimum)
                    mValue = Minimum;
                else
                    mValue = RoundValue(value);
            }
        }

        public string StringValue
        {
            get
            {
                return string.IsNullOrEmpty(PostFix) ? string.Format(DisplayStringFormat, Value) : string.Format(DisplayStringFormat, Value) + " " + PostFix;
            }
        }

        public bool AlwaysRoundUp
        {
            get
            {
                return mRoundUp;
            }
            set
            {
                if (value && mRoundDown)
                    mRoundDown = false;

                mRoundUp = value;
            }
        }

        public bool AlwaysRoundDown
        {
            get
            {
                return mRoundDown;
            }
            set
            {
                if (value && mRoundUp)
                    mRoundUp = false;

                mRoundDown = value;
            }
        }
    }
}
