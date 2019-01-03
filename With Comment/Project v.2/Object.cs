using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_v._2
{
    class Object
    {
        // Each object has a name with set of defined attribute-values
        public object __Name;
        public List<Attribute> __Attribute_Values = new List<Attribute>();
       

        public Object(object _Name, List<Attribute> _Attribute_Values)
        {
            this.__Name = _Name;
            this.__Attribute_Values = _Attribute_Values;
            
        }
        public object Name
        {
            set { this.__Name = value; }
            get { return this.__Name; }
        
        }
        public List<Attribute> Attribute_Values
        {
            set { this.__Attribute_Values = value; }
            get { return this.__Attribute_Values; }


        }

        public object this[object Name]
        {
            set
            {

                for (int i = 0; i < __Attribute_Values.Count; i++)
                {
                    Attribute x = __Attribute_Values[i];
                    if (x.Name == Name)
                    {
                        x.value = value;
                        break;
                    }
                    else
                    { continue; }


                }


            }
            get
            {
                object Val = null;
                for (int i = 0; i < __Attribute_Values.Count; i++)
                {
                    Attribute x = __Attribute_Values[i];
                    if (x.Name == Name)
                    {
                        Val = x.value;
                        break;
                    }
                    else
                    { continue; }


                }
                return Val;
            }
        }
    }
}
