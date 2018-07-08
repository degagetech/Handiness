using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Handiness2.Schema.Exporter.Windows.Properties;
using Newtonsoft.Json;
namespace Handiness2.Schema.Exporter.Windows
{
    public partial class ExcelExportGroupForm : Form
    {

        public GroupInfoCollection GroupInfoCollection { get; private set; }
        public HashSet<String> _unallocatedTableNames;
        public ExcelExportGroupForm()
        {
            InitializeComponent();
            _unallocatedTableNames = new HashSet<String>();
        }


        public void SetGroupInfo(GroupInfoCollection collection, IList<TableSchemaExtend> tableSchemas)
        {
            this.GroupInfoCollection = collection;
            var schemaNames = new HashSet<String>(tableSchemas.Select(t => t.Name));
            List<String> groupNames = new List<String>();
            foreach (var pair in collection)
            {
                groupNames.Add(pair.Key);
                foreach (String name in pair.Value)
                {
                    schemaNames.Remove(name);
                }
            }
            _unallocatedTableNames = new HashSet<String>(schemaNames);
            this.DrawGroupInfo(groupNames);
        }
        private void DrawGroupInfo(List<String> groupNames)
        {

            this._cbGroup.Items.AddRange(groupNames.ToArray());
        }
        private void _btnAddGroup_Click(object sender, EventArgs e)
        {
            AddGroupForm form = new AddGroupForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (!this.IsUnique(form.GroupName))
                {
                    MessageBox.Show(Resources.ExcelExportGroupForm_GroupNotNnique, Resources.HintText, MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                this.GroupInfoCollection.AddGroup(form.GroupName);
                this._cbGroup.Items.Add(form.GroupName);
                this._cbGroup.SelectedItem = form.GroupName;
            }
        }
        private Boolean IsUnique(String groupName)
        {
           return  !this.GroupInfoCollection.Contain(groupName);
        }
        private void _btnDeleteGroup_Click(object sender, EventArgs e)
        {
            var current = this._cbGroup.SelectedItem;
            if (current != null)
            {
                this._cbGroup.Items.Remove(current);
                if (this._cbGroup.Items.Count > 0)
                {
                    this._cbGroup.SelectedIndex = 0;
                }
            }
        }

        private Boolean _groupSwitching = false;
        private void _cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            String groupName = this._cbGroup.Text;
            this._checkItemContainer.Items.Clear();
            if (!String.IsNullOrEmpty(groupName) && this.GroupInfoCollection.Contain(groupName))
            {
                _groupSwitching = true;
                var groupItems = this.GroupInfoCollection.GetGroupItems(groupName);
                _checkItemContainer.BeginUpdate();
                foreach (var item in groupItems)
                {
                    _checkItemContainer.Items.Add(item,true);
                }
                foreach (var item in this._unallocatedTableNames)
                {
                    _checkItemContainer.Items.Add(item, false);
                }
                _checkItemContainer.EndUpdate();
                _groupSwitching = false;
            }
        }
     
        private void _checkItemContainer_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_groupSwitching) return;
            String item = _checkItemContainer.SelectedItem as String;
            String groupName = this._cbGroup.Text;
            var groupItems = this.GroupInfoCollection.GetGroupItems(groupName);
            switch (e.NewValue)
            {
                case CheckState.Checked:
                    {
                        this._unallocatedTableNames.Remove(item);
                        groupItems.Add(item);
                    }
                    break;
                case CheckState.Unchecked:
                    {
                        this._unallocatedTableNames.Add(item);
                        groupItems.Remove(item);
                    }
                    break;
                default:return;
                    
            }
        }
    }
}
