using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class News_type
    {
        private int typeID;

        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }
        private string typeName;

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }
        private DateTime type_createTime;

        public DateTime Type_createTime
        {
            get { return type_createTime; }
            set { type_createTime = value; }
        }
        private int? type_ParentID;

        public int? Type_ParentID
        {
            get { return type_ParentID; }
            set { type_ParentID = value; }
        }

        private int type_sequence;

        public int Type_sequence
        {
            get { return type_sequence; }
            set { type_sequence = value; }
        }
        private int type_count;

        public int Type_count
        {
            get { return type_count; }
            set { type_count = value; }
        }
    }
}
