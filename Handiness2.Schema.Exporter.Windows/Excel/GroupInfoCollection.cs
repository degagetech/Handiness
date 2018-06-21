using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public class GroupInfoCollection : IEnumerable<KeyValuePair<String, IList<String>>>
    {

        private Dictionary<String, IList<String>> _groupTable;
        private HashSet<String> _itemTable;
        public IEnumerator<KeyValuePair<String, IList<String>>> GetEnumerator()
        {
            return this._groupTable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._groupTable.GetEnumerator();
        }

        public Int32 Count
        {
            get
            {
                return _groupTable.Count;
            }
        }
        public Boolean Contain(String groupName)
        {
            return _groupTable.ContainsKey(groupName);
        }
        public void AddGroup(String groupName, IList<String> groupItems = null)
        {
            if (!_groupTable.ContainsKey(groupName))
            {
                groupItems = groupItems ?? new List<String>();
                this._groupTable.Add(groupName, groupItems);
                foreach (var item in groupItems)
                {
                    this._itemTable.Add(item);
                }
            }
        }
        public Boolean ContainItem(String item)
        {
            return _itemTable.Contains(item);
        }
        public void RemoveGroup(String groupName)
        {
            if (_groupTable.ContainsKey(groupName))
                this._groupTable.Remove(groupName);

        }
        public GroupInfoCollection()
        {
            _groupTable = new Dictionary<String, IList<String>>();
            _itemTable = new HashSet<String>();
        }
        public void Clear()
        {
            _groupTable.Clear();
        }



    }
}
