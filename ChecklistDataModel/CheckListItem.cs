using System.Xml;
using System;

namespace CheckListDataModel
{
    [Serializable]
    public class CheckListItem : CheckList
    {
        public int Ordinal { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
  
    }
}

