using System;
using System.Xml.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckListDataModel
{
    [Serializable(),
    XmlInclude(typeof(CheckList)),
    XmlInclude(typeof(CheckListItem))]
    public class CheckListBase 
    {
        [BsonId]
        public string Name { get; set; }
        public string Description { get; set; }
        private int Order { get; set; }
 
    }
}
