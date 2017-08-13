using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Linq;

using BrightIdeasSoftware;
using WeifenLuo.WinFormsUI.Docking;

using Spriten.Drawing;
using Spriten.Utility;
using Spriten.Data;
using static Spriten.Dock.DocumentDock;

namespace Spriten.Dock
{
    public partial class LayerDock : DockContent
    {
        private bool mSelectedLockedItem;

        // context menu and items
        private ContextMenu mContextMenu;
        private MenuItem mGroupItem;
        private MenuItem mAddItem;
        private MenuItem mAddItemAbove;
        private MenuItem mAddItemBelow;
        private MenuItem mAddItemGroup;
        private MenuItem mMergeItem;
        private MenuItem mFlattenItem;
        private MenuItem mRemoveItem;
        private MenuItem mDuplicateItem;
        private MenuItem mCutItem;
        private MenuItem mCopyItem;
        private MenuItem mPasteItem;
        private MenuItem mPasteToGroupItem;

        // events
        public Action<DrawableMask, InsertMode> InsertDrawable;
        public Action<DrawableMask> RemoveDrawable;
        public Action<DrawableMask> SelectDrawable;
        public Action<DrawableMask> MergeWithBelow;
        public Action<DrawableMask> FlattenGroup;
        public Action<List<DrawableMask>> MergeDrawables;
        public Action<List<DrawableMask>> DuplicateDrawables;
        public Action<List<DrawableMask>> CreateGroup;
        public Action<List<DrawableMask>> MoveDrawablesToRoot;
        public Action<DrawableMask, List<DrawableMask>> MoveDrawablesToGroup;
        public Action<DrawableMask, List<DrawableMask>, int> MoveDrawablesToSibling;
        public Action<List<DrawableMask>, bool> MoveDrawables;
        public Action<DrawableMask, bool> PasteDrawables;
        public Action RefreshCanvas;
        public Func<bool> HasActiveDocument;

        #region Constructor

        public LayerDock()
        {
            InitializeComponent();
            
            SetupTree();
            SetupDragAndDrop();
            SetupContextMenu();
            LoadIconsAndTheme();

            LayerPropertiesPanel.Visible = false;
        }

        #endregion

        /// <summary>
        /// Setup tree list view control
        /// </summary>
        private void SetupTree()
        {
            // node is expandable if it is a group which contains nested drawables
            treelist_layer.CanExpandGetter = delegate (object x)
            {
                return ((DrawableMask)x).IsNested;
            };

            // return the drawables inside group
            treelist_layer.ChildrenGetter = delegate (object x)
            {
                return ((LayerMaskGroup)x).DrawableMaskList;
            };
            
            if(ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                // image checkbox for visibility
                olvVisibility.Renderer = new MappedImageRenderer(new object[]
                {
                true, Properties.Resources.dark_eye_on_16,
                false, Properties.Resources.dark_eye_off_16
                });

                // image checkbox for layer lock
                olvLock.Renderer = new MappedImageRenderer(new object[]
                {
                true, Properties.Resources.dark_lock_on_16,
                false, Properties.Resources.dark_lock_off_16
                });
            }
            else
            {
                olvVisibility.Renderer = new MappedImageRenderer(new object[]
                {
                true, Properties.Resources.light_eye_on_16,
                false, Properties.Resources.light_eye_off_16
                });
                
                olvLock.Renderer = new MappedImageRenderer(new object[]
                {
                true, Properties.Resources.light_lock_on_16,
                false, Properties.Resources.light_lock_off_16
                });
            }

            // styling
            TreeListView.TreeRenderer treeColumnRenderer = treelist_layer.TreeColumnRenderer;
            treeColumnRenderer.IsShowLines = false;
            treeColumnRenderer.UseTriangles = true;
        }

        private void LoadIconsAndTheme()
        {
            BackColor = ThemeHelper.Background;

            treelist_layer.BackColor = ThemeHelper.TreeListBackground;
            treelist_layer.UseCellFormatEvents = true;
            treelist_layer.FormatCell += (sender, args) =>
            {
                args.SubItem.ForeColor = ThemeHelper.Foreground;
            };
            treelist_layer.SelectedBackColor = System.Drawing.Color.DarkGray;
            treelist_layer.UnfocusedSelectedBackColor = System.Drawing.Color.DarkGray;

            SetButtons(false);
        }

        private void SetAddButton(bool enable)
        {
            if (ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                if (enable)
                    btn_add.Image = Properties.Resources.dark_page_20;
                else
                    btn_add.Image = Properties.Resources.dark_page_disabled_20;
            }
            else
            {
                if (enable)
                    btn_add.Image = Properties.Resources.light_page_20;
                else
                    btn_add.Image = Properties.Resources.light_page_disabled_20;
            }

            btn_add.Enabled = enable;
        }

        private void SetRemoveButton(bool enable)
        {
            if (ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                if (enable)
                    btn_remove.Image = Properties.Resources.dark_trash_20;
                else
                    btn_remove.Image = Properties.Resources.dark_trash_disabled_20;
            }
            else
            {
                if (enable)
                    btn_remove.Image = Properties.Resources.light_trash_20;
                else
                    btn_remove.Image = Properties.Resources.light_trash_disabled_20;
            }

            btn_remove.Enabled = enable;
        }

        private void SetGroupButton(bool enable)
        {
            if (ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                if (enable)
                    btn_group.Image = Properties.Resources.dark_folder_20;
                else
                    btn_group.Image = Properties.Resources.dark_folder_disabled_20;
            }
            else
            {
                if (enable)
                    btn_group.Image = Properties.Resources.light_folder_20;
                else
                    btn_group.Image = Properties.Resources.light_folder_disabled_20;
            }

            btn_group.Enabled = enable;
        }

        private void SetDuplicateButton(bool enable)
        {
            if (ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                if (enable)
                    btn_duplicate.Image = Properties.Resources.dark_duplicate_20;
                else
                    btn_duplicate.Image = Properties.Resources.dark_duplicate_disabled_20;
            }
            else
            {
                if (enable)
                    btn_duplicate.Image = Properties.Resources.light_duplicate_20;
                else
                    btn_duplicate.Image = Properties.Resources.light_duplicate_disabled_20;
            }

            btn_duplicate.Enabled = enable;
        }

        private void SetMoveUpButton(bool enable)
        {
            if (ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                if (enable)
                    btn_moveUp.Image = Properties.Resources.dark_arrow_up_20;
                else
                    btn_moveUp.Image = Properties.Resources.dark_arrow_up_disabled_20;
            }
            else
            {
                if (enable)
                    btn_moveUp.Image = Properties.Resources.light_arrow_up_20;
                else
                    btn_moveUp.Image = Properties.Resources.light_arrow_up_disabled_20;
            }

            btn_moveUp.Enabled = enable;
        }

        private void SetMoveDownButton(bool enable)
        {
            if (ThemeHelper.Style == ThemeHelper.ThemeStyle.Dark)
            {
                if (enable)
                    btn_moveDown.Image = Properties.Resources.dark_arrow_down_20;
                else
                    btn_moveDown.Image = Properties.Resources.dark_arrow_down_disabled_20;
            }
            else
            {
                if (enable)
                    btn_moveDown.Image = Properties.Resources.light_arrow_down_20;
                else
                    btn_moveDown.Image = Properties.Resources.light_arrow_down_disabled_20;
            }

            btn_moveDown.Enabled = enable;
        }

        public void SetButtons(bool enable)
        {
            bool enableItemAction = treelist_layer.SelectedIndices.Count > 0 && enable;

            SetAddButton(enable);
            SetGroupButton(enable);
            SetRemoveButton(enableItemAction);
            SetDuplicateButton(enableItemAction);
            SetMoveUpButton(enableItemAction);
            SetMoveDownButton(enableItemAction);
        }

        public bool HasItemSelected()
        {
            return treelist_layer.SelectedIndices.Count > 0;
        }

        public bool IsSelectingGroup()
        {
            return treelist_layer.SelectedObject != null && !((DrawableMask)treelist_layer.SelectedObject).IsLayer;
        }

        /// <summary>
        /// Setup the drag and drop components
        /// </summary>
        private void SetupDragAndDrop()
        {
            treelist_layer.ModelCanDrop += delegate (object sender, ModelDropEventArgs e)
            {
                e.Handled = true;
                e.Effect = DragDropEffects.None;
                
                if(!e.SourceModels.Contains(e.TargetModel))
                {                    
                    bool ruleSatisfied = true;

                    if (e.DropTargetLocation == DropTargetLocation.Background)
                    {
                        for(int i = e.SourceModels.Count - 1; i >= 0 && ruleSatisfied; i--)
                        {
                            ruleSatisfied = ((DrawableMask)e.SourceModels[i]).Parent != null;
                        }

                        if (e.SourceListView != e.ListView && ruleSatisfied)
                            e.Effect = DragDropEffects.Move;
                    }
                    else
                    {
                        DrawableMask target = (DrawableMask)e.TargetModel;

                        for (int i = e.SourceModels.Count - 1; i >= 0 && ruleSatisfied; i--)
                        {
                            if (ruleSatisfied = !target.IsParent((DrawableMask)e.SourceModels[i]))
                                e.Effect = DragDropEffects.Move;
                        }                         
                    }
                }
            };

            treelist_layer.ModelDropped += delegate (object sender, ModelDropEventArgs e)
            {
                switch(e.DropTargetLocation)
                {
                    case DropTargetLocation.AboveItem:
                        MoveDrawablesToSibling((DrawableMask)e.TargetModel, e.SourceModels.Cast<DrawableMask>().ToList(), 0);
                        break;
                    case DropTargetLocation.BelowItem:
                        MoveDrawablesToSibling((DrawableMask)e.TargetModel, e.SourceModels.Cast<DrawableMask>().ToList(), 1);
                        break;
                    case DropTargetLocation.Background:
                        //MoveDrawablesToRoot(e.SourceModels.Cast<DrawableMask>().ToList());
                        break;
                    case DropTargetLocation.Item:
                        MoveDrawablesToGroup((DrawableMask)e.TargetModel, e.SourceModels.Cast<DrawableMask>().ToList());
                        break;
                    default:
                        return;
                }
            };

            SimpleDropSink sink = treelist_layer.DropSink as SimpleDropSink;
            sink.FeedbackColor = System.Drawing.Color.LightGray;
            sink.CanDropBetween = true;
            sink.CanDropOnBackground = true;            
        }

        /// <summary>
        /// Setup context menu items and events
        /// </summary>
        private void SetupContextMenu()
        {
            mAddItem = new MenuItem("Add layer", AddAboveAction);
            mAddItemAbove = new MenuItem("Insert above", AddAboveAction);
            mAddItemBelow = new MenuItem("Insert below", AddBelowAction);
            mAddItemGroup = new MenuItem("Insert into group", AddToGroupAction);
            mAddItem.MenuItems.Add(mAddItemAbove);
            mAddItem.MenuItems.Add(mAddItemBelow);
            mAddItem.MenuItems.Add(mAddItemGroup);

            mRemoveItem = new MenuItem("Remove layer", RemoveAction);
            mGroupItem = new MenuItem("Create group", GroupAction);
            mMergeItem = new MenuItem("Merge with layer below", MergeAction);
            mFlattenItem = new MenuItem("Flatten group", FlattenAction);
            mDuplicateItem = new MenuItem("Duplicate layer", DuplicateAction);

            mCutItem = new MenuItem("Cut", CutAction);
            mCopyItem = new MenuItem("Copy", CopyAction);
            mPasteItem = new MenuItem("Paste", PasteAction);
            mPasteToGroupItem = new MenuItem("Paste into group", PasteToGroupAction);

            mContextMenu = new ContextMenu();
            mContextMenu.MenuItems.Add(mAddItem);
            mContextMenu.MenuItems.Add(mRemoveItem);
            mContextMenu.MenuItems.Add("-");
            mContextMenu.MenuItems.Add(mGroupItem);
            mContextMenu.MenuItems.Add(mMergeItem);
            mContextMenu.MenuItems.Add(mFlattenItem);
            mContextMenu.MenuItems.Add("-");
            mContextMenu.MenuItems.Add(mDuplicateItem);
            mContextMenu.MenuItems.Add("-");
            mContextMenu.MenuItems.Add(mCutItem);
            mContextMenu.MenuItems.Add(mCopyItem);
            mContextMenu.MenuItems.Add(mPasteItem);
            mContextMenu.MenuItems.Add(mPasteToGroupItem);

            treelist_layer.ContextMenu = mContextMenu;
            treelist_layer.ContextMenu.Popup += treelistContextMenuPopUp;
        }

        #region LayerDockAction

        public void RefreshDrawableList(List<DrawableMask> drawables)
        {
            ClearList();
            treelist_layer.Roots = drawables;
            if (drawables.Count > 0)
                treelist_layer.SelectObject(drawables[0]);
        }

        public void SetDrawableList(List<DrawableMask> drawables)
        {
            treelist_layer.SetObjects(drawables);
            SetButtons(true);
        }

        public void UpdateList(List<DrawableMask> drawables)
        {
            treelist_layer.UpdateObjects(drawables);
        }

        public void ClearList()
        {
            treelist_layer.ClearObjects();
        }

        #endregion

        #region Events

        private void btn_add_Click(object sender, EventArgs e)
        {
            DrawableMask selected = treelist_layer.SelectedObject as DrawableMask;

            if (selected == null)
                InsertDrawable(selected, InsertMode.Above);
            else if(selected.IsLayer)
                InsertDrawable(selected, InsertMode.Above);
            else
                InsertDrawable(selected, InsertMode.ToGroup);
        }

        private void treelistContextMenuPopUp(object sender, EventArgs e)
        {
            int selectionCount = treelist_layer.SelectedIndices.Count;
            // no active document
            if (!HasActiveDocument())
            {
                // visibility/clickable
                mAddItem.Enabled = false;
                mAddItemAbove.Visible = false;
                mAddItemBelow.Visible = false;
                mAddItemGroup.Visible = false;
                mRemoveItem.Enabled = false;
                mGroupItem.Enabled = false;
                mMergeItem.Enabled = false;
                mFlattenItem.Enabled = false;
                mDuplicateItem.Enabled = false;
                mCutItem.Enabled = false;
                mCopyItem.Enabled = false;
                mPasteItem.Enabled = false;
                mPasteToGroupItem.Visible = false;

                // name
                mAddItem.Text = "Add layer";
                mRemoveItem.Text = "Remove layer";
                mGroupItem.Text = "Create group";
                mMergeItem.Text = "Merge with layer below";
                mDuplicateItem.Text = "Duplicate layer";
            }
            // has single item selected
            else if (selectionCount == 1)
            {
                DrawableMask selected = (DrawableMask)treelist_layer.SelectedObject;
                bool isNotLast = true;

                if (selected.Parent == null)
                {
                    var enume = treelist_layer.Roots.GetEnumerator();
                    int pos = 0, count = 0;
                    while (enume.MoveNext())
                    {
                        if (((DrawableMask)enume.Current) == selected)
                            pos = count;

                        count++;
                    }
                    isNotLast = pos < count - 1;
                }
                else
                {
                    List<DrawableMask> par = ((LayerMaskGroup)selected.Parent).DrawableMaskList;
                    isNotLast = par.IndexOf(selected) < par.Count - 1;
                }

                // visibility/clickable
                mAddItem.Enabled = true;
                mAddItemAbove.Visible = true;
                mAddItemBelow.Visible = true;
                mAddItemGroup.Visible = !selected.IsLayer;
                mRemoveItem.Enabled = !mSelectedLockedItem;
                mGroupItem.Enabled = true;
                mMergeItem.Enabled = isNotLast && !mSelectedLockedItem;
                mFlattenItem.Enabled = !selected.IsLayer;
                mDuplicateItem.Enabled = true;
                mCutItem.Enabled = true;
                mCopyItem.Enabled = true;
                mPasteToGroupItem.Visible = !selected.IsLayer;
                mPasteToGroupItem.Enabled = mPasteItem.Enabled = User.DrawablesClipboard.Count > 0;

                // name
                mAddItem.Text = "Add layer";
                mGroupItem.Text = "Create group";
                mMergeItem.Text = "Merge with layer below";

                if (selected.IsLayer)
                {
                    mRemoveItem.Text = "Remove layer";
                    mDuplicateItem.Text = "Duplicate layer";
                }
                else
                {
                    mRemoveItem.Text = "Remove group";
                    mDuplicateItem.Text = "Duplicate group";
                }
            }
            // has multiple items selected
            else if (selectionCount > 0)
            {
                // visibility/clickable
                mAddItem.Enabled = true;
                mAddItemAbove.Visible = true;
                mAddItemBelow.Visible = true;
                mAddItemGroup.Visible = false;
                mRemoveItem.Enabled = !mSelectedLockedItem;
                mGroupItem.Enabled = true;
                mMergeItem.Enabled = true;
                mFlattenItem.Enabled = false;
                mDuplicateItem.Enabled = true;
                mCutItem.Enabled = true;
                mCopyItem.Enabled = true;
                mPasteItem.Enabled = User.DrawablesClipboard.Count > 0;
                mPasteToGroupItem.Visible = false;

                // name
                mAddItem.Text = "Add layer";
                mRemoveItem.Text = "Remove items";
                mGroupItem.Text = "Group items";
                mMergeItem.Text = "Merge items";
                mDuplicateItem.Text = "Duplicate items";
            }
            // has active document, but nothing selected
            else
            {
                // visibility/clickable
                mAddItem.Enabled = true;
                mAddItemAbove.Visible = true;
                mAddItemBelow.Visible = false;
                mAddItemGroup.Visible = false;
                mRemoveItem.Enabled = false;
                mGroupItem.Enabled = true;
                mMergeItem.Enabled = false;
                mFlattenItem.Enabled = false;
                mDuplicateItem.Enabled = false;
                mCutItem.Enabled = false;
                mCopyItem.Enabled = false;
                mPasteItem.Enabled = User.DrawablesClipboard.Count > 0;
                mPasteToGroupItem.Visible = false;

                // name
                mAddItem.Text = "Add layer";
                mRemoveItem.Text = "Remove layer";
                mGroupItem.Text = "Create group";
                mMergeItem.Text = "Merge with layer below";
                mDuplicateItem.Text = "Duplicate layer";
            }
        }

        private void treelist_layer_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int selCount = treelist_layer.SelectedIndices.Count;

                if(selCount > 1)
                {
                    bool hasLockedItem = false;
                    for(int i = selCount - 1; i >= 0 && !hasLockedItem; i--)
                    {
                        hasLockedItem = ((DrawableMask)treelist_layer.SelectedObjects[i]).Locked;
                    }
                    mSelectedLockedItem = hasLockedItem;
                    SetRemoveButton(!hasLockedItem);
                    SetDuplicateButton(true);
                    SetMoveUpButton(true);
                    SetMoveDownButton(true);
                }
            }
        }

        private void treelist_layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawableMask selection = (DrawableMask)treelist_layer.SelectedObject;
            bool hasSelectedLayer = treelist_layer.SelectedIndices.Count > 0;

            if (selection != null)
            {
                SelectDrawable(selection);
                mSelectedLockedItem = selection.Locked;
            }
            
            SetRemoveButton(!mSelectedLockedItem && hasSelectedLayer);
            SetDuplicateButton(hasSelectedLayer);
            SetMoveUpButton(hasSelectedLayer);
            SetMoveDownButton(hasSelectedLayer);
        }

        private void AddAboveAction(object sender, EventArgs e)
        {
            InsertDrawable((DrawableMask)treelist_layer.SelectedObject, InsertMode.Above);
        }

        private void AddBelowAction(object sender, EventArgs e)
        {
            InsertDrawable((DrawableMask)treelist_layer.SelectedObject, InsertMode.Below);
        }

        private void AddToGroupAction(object sender, EventArgs e)
        {
            InsertDrawable((DrawableMask)treelist_layer.SelectedObject, InsertMode.ToGroup);
        }

        private void RemoveAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            for(int i = treelist_layer.SelectedObjects.Count - 1; i >= 0; i--)
            {
                RemoveDrawable((DrawableMask)treelist_layer.SelectedObjects[i]);
            }
            treelist_layer.RemoveObjects(treelist_layer.SelectedObjects);
            treelist_layer.ResumeLayout();
            RefreshCanvas();

            if(treelist_layer.Items.Count == 0)
            {
                SetRemoveButton(false);
                SetDuplicateButton(false);
                SetMoveDownButton(false);
                SetMoveUpButton(false);
            }
        }

        private void DuplicateAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            DuplicateDrawables(treelist_layer.SelectedObjects.Cast<DrawableMask>().ToList());
            treelist_layer.ResumeLayout();
        }

        private void GroupAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            CreateGroup(treelist_layer.SelectedObjects.Cast<DrawableMask>().ToList());
            treelist_layer.ResumeLayout();
        }

        private void MergeAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            if (treelist_layer.SelectedIndices.Count > 1)
                MergeDrawables(treelist_layer.SelectedObjects.Cast<DrawableMask>().ToList());
            else
                MergeWithBelow((DrawableMask)treelist_layer.SelectedObject);
            treelist_layer.ResumeLayout();
        }

        private void FlattenAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            FlattenGroup((DrawableMask)treelist_layer.SelectedObject);
            treelist_layer.ResumeLayout();
        }

        private void MoveUpAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            MoveDrawables(treelist_layer.SelectedObjects.Cast<DrawableMask>().ToList(), true);
            treelist_layer.ResumeLayout();
        }

        private void MoveDownAction(object sender, EventArgs e)
        {
            treelist_layer.SuspendLayout();
            MoveDrawables(treelist_layer.SelectedObjects.Cast<DrawableMask>().ToList(), false);
            treelist_layer.ResumeLayout();
        }

        public void CutAction(object sender, EventArgs e)
        {
            int selCount = treelist_layer.SelectedObjects.Count;
            User.ClearClipboard();
            List<DrawableMask> filterList = new List<DrawableMask>(selCount);

            for (int i = selCount - 1; i >= 0; i--)
            {
                filterList.Add((DrawableMask)treelist_layer.SelectedObjects[i]);
            }

            treelist_layer.SuspendLayout();
            for (int i = filterList.Count - 1; i >= 0; i--)
            {
                if (!filterList.Contains(filterList[i].Parent))
                {
                    User.DrawablesClipboard.Add(filterList[i].GetCopy(filterList[i].Name));
                    RemoveDrawable(filterList[i]);
                }
            }
            treelist_layer.RemoveObjects(treelist_layer.SelectedObjects);
            treelist_layer.ResumeLayout();
        }

        public void CopyAction(object sender, EventArgs e)
        {
            int selCount = treelist_layer.SelectedObjects.Count;
            User.ClearClipboard();
            List<DrawableMask> filterList = new List<DrawableMask>(selCount);

            for(int i = selCount - 1; i >= 0; i--)
            {
                filterList.Add((DrawableMask)treelist_layer.SelectedObjects[i]);
            }
                

            for(int i = filterList.Count - 1; i >= 0; i--)
            {
                if (!filterList.Contains(filterList[i].Parent))
                    User.DrawablesClipboard.Add(filterList[i].GetCopy(filterList[i].Name));
            }
        }

        public void PasteAction(object sender, EventArgs e)
        {
            PasteDrawables((DrawableMask)treelist_layer.SelectedObject, false);
        }

        public void PasteToGroupAction(object sender, EventArgs e)
        {
            PasteDrawables((DrawableMask)treelist_layer.SelectedObject, true);
        }

        private void treelist_layer_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            if (e.Column.Index == 1)
            {
                BeginInvoke(RefreshCanvas);
            }
        }

        #endregion
    }
}
