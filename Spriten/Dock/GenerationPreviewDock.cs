using System;
using System.Collections.Generic;
using Spriten.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace Spriten.Dock
{
    public partial class GenerationPreviewDock : DockContent
    {
        public Action UpdatePreview;

        public GenerationPreviewDock()
        {
            InitializeComponent();
        }
    }
}
