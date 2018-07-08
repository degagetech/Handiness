using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    [Serializable]
    public class GroupInfoCollection : Dictionary<String, List<String>>
    {

        private HashSet<String> _itemTable;

        public IList<String> GetGroupItems(String groupName)
        {
            IList<String> groupInfo = null;
            if (this.Contain(groupName))
            {
                groupInfo = this[groupName];
            }
            return groupInfo;
        }
        public void RemoveItem(String item)
        {
            foreach (var pair in this)
            {
                pair.Value.Remove(item);
            }
        }
        public Boolean Contain(String groupName)
        {
            return this.ContainsKey(groupName);
        }
        public void AddGroup(String groupName, List<String> groupItems = null)
        {
            if (!this.ContainsKey(groupName))
            {
                groupItems = groupItems ?? new List<String>();
                this.Add(groupName, groupItems);
                foreach (var item in groupItems)
                {
                    this._itemTable.Add(item);
                }
            }
        }
        public void ReIndex()
        {
            foreach (var pair in this)
            {
                foreach (String name in pair.Value)
                {
                    this._itemTable.Add(name);
                }
            }
        }
        public Boolean ContainItem(String item)
        {
            return _itemTable.Contains(item);
        }
        public void RemoveGroup(String groupName)
        {
            if (this.ContainsKey(groupName))
                this.Remove(groupName);

        }
        public GroupInfoCollection()
        {

            _itemTable = new HashSet<String>();
        }

 
        

    }
}
