using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_v._2
{
    class Attribute
    {
        // Each Attribute has a name and value for a specified object 
        private object __Name;
        private object __value;
        public Attribute(object _Name, object _Value)
        {
            this.__Name = _Name;
            this. __value = _Value;
        }
        public object Name
        {
            set { this.__Name = value; }
            get { return this.__Name; }
        
        }
        public object value
        {

            set { this.__value = value; }
            get { return this.__value; }
        
        }
    }
}
