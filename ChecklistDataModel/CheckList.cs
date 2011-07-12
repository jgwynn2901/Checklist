using System.Xml;
using System.Collections.Generic;
using System;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CheckListDataModel
{
    [Serializable]
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(CheckListItem))]
    public class CheckList 
    {
        private List<CheckListItem> _items = new List<CheckListItem>();

        [BsonId, Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonIgnore]
        public string Parent { get; set; }

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
            return AddItem(name, description, string.Empty);
        }

        public CheckListItem AddItem(string name, string description, string data)
        {
            var results = new CheckListItem
            {
                Name = name,
                Type = "Item",
                Description = description,
                Data = data,
                Ordinal = Items.Count
            };

            Items.Add(results);
            return results;
        }

        public CheckListItem UpdateItem(CheckListItem item)
        {
            var results = Items.Find(a => a.Name==item.Name);
            if (results != default(CheckListItem))
            {
                results.Description = item.Description;
                results.Data = item.Data;
                return results;
            }
            return AddItem(item.Name, item.Description, item.Data);
        }
    }
}
