using System.Xml;
using System.Collections.Generic;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckListDataModel
{
    [Serializable]
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(CheckListItem))]
    public class CheckList 
    {
        private List<CheckListItem> _items = new List<CheckListItem>();

        [BsonId]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CheckListItem> Items { get { return _items; } set { _items = value; } }
        
        public void RemoveItem(string name)
        {
            CheckListItem node = null;
            foreach (var item in Items)
            {
                if (item.Name == name)
                {
                    node = item;
                    break;
                }
            }
            if (node != null)
                Items.Remove(node);
        }

        public CheckListItem AddItem(string name, string description)
        {
            var results = new CheckListItem
            {
                Name = name,
                Type = "Item",
                Description = description
            };

            Items.Add(results);
            return results;
        }
    }
}
