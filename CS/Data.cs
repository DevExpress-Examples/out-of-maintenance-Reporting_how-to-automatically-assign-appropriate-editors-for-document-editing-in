using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEditingFieldsSelector {
    public class CustomData {
        public ItemList Items { get; set; }
        public CustomData() {
            Items = new ItemList();
        }
    }
    public class ItemList : List<Item> {
        public ItemList() {
            for(int i = 0; i < 3; i++) {
                Add(new Item() {
                    Int32Property = i,
                    DateTimeProperty = DateTime.Now.AddDays(-i),
                    EnumProperty = (CustomEnum)i });
            }
        }
    }

    public class Item {
        public int Int32Property { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public CustomEnum EnumProperty { get; set; }
    }

    public enum CustomEnum {
        Value1 = 0,
        Value2 = 1,
        Value3 = 2
    }
}
