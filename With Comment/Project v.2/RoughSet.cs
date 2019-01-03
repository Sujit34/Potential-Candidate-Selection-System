using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Project_v._2
{
    class RoughSet
    {
       
        // a framework of information table with a set of rough set operators
        List<Object> __Objects = new List<Object>();
        Hashtable h = new Hashtable();
        public RoughSet(List<Object> _Objects)
        {
            this.__Objects = _Objects;
            for (int i = 0; i < _Objects.Count; i++)
            {
                Object x = _Objects[i];
                h.Add(x.Name, x.Attribute_Values);

            }


        }
        public Hashtable ReturnRoughSetTable()
        {
            return h;

        }
        public object ReturnObjectAttributeValue(object Name, object Attribute)
        {
            object result = null;
            List<Attribute> Result = ((List<Attribute>)h[Name]);
            for (int i = 0; i < Result.Count; i++)
            {
                if (Result[i].Name == Attribute)
                {
                    result = Result[i].value;
                    break;
                }
                else
                {
                    continue;

                }

            }
            return result;



        }
        public string ConvertObToString(List<List<object>> Result)
        {
            string Temp = "";
            for (int f = 0; f < Result.Count; f++)
            {
                for (int j = 0; j < Result[f].Count; j++)
                {
                    Temp += Result[f][j].ToString();

                }
            }


            return Temp;

        }

        private List<List<object>> ComputeDispensable_IndispensableAttributes()
        {
            List<object> Dispen = new List<object>();
            List<object> Indispen = new List<object>();
            List<object> Reducts = new List<object>();
            List<List<object>> Result = Indecernibility();
            List<List<object>> Final = new List<List<object>>();
            string S2 = ConvertObToString(Result);

            for (int i = 0; i < __Objects[0].__Attribute_Values.Count; i++)
            {
                List<List<object>> Temp = Indecernibility(__Objects[0].__Attribute_Values[i].Name);
                string S1 = ConvertObToString(Temp);
                if (S1 == S2)
                {
                    Dispen.Add(__Objects[0].__Attribute_Values[i].Name);
                    List<Attribute> Attr = new List<Attribute>();
                    Attr.AddRange(__Objects[0].__Attribute_Values);
                    Attr.RemoveAt(i);
                    string T = "";
                    for (int g = 0; g < Attr.Count; g++)
                    {
                        T = T + Attr[g].Name.ToString()+",";//reduct string

                    }
                    Reducts.Add(T);

                }
                else
                {
                    Indispen.Add(__Objects[0].__Attribute_Values[i].Name);
                    continue;

                }

            }

            Final.Add(Dispen);
            Final.Add(Indispen);
            Final.Add(Reducts);
            return Final;
        }
        public List<object> Dispensable()
        {
            List<List<object>> All = ComputeDispensable_IndispensableAttributes();
            return All[0];

        }
        public List<object> Indispensable()
        {
            List<List<object>> All = ComputeDispensable_IndispensableAttributes();
            return All[1];

        }
        public List<object> Reducts()
        {
            List<List<object>> All = ComputeDispensable_IndispensableAttributes();
            return All[2];

        }

        // you can exclude one of the defined attributes in the information table by providing its names/name
        // such as IND(P-{a}) the indecernibility is computed without attribute a 
        public List<List<object>> Indecernibility(object NameAttr)
        {
            List<List<object>> Result = new List<List<object>>();
            for (int i = 0; i < __Objects.Count; i++)
            {
                List<object> Temp = new List<object>();
                Temp.Add(__Objects[i].__Name);
                //j=0
                //j=i+1
                for (int j = 0; j < __Objects.Count; j++)
                {
                    if (i == j)
                        continue;
                    else
                    {
                        List<Attribute> AttVali = ((List<Attribute>)h[__Objects[i].__Name]);
                        List<Attribute> AttValj = ((List<Attribute>)h[__Objects[j].__Name]);
                        for (int f = 0; f < AttVali.Count; f++)
                        {
                            if ((AttVali[f].Name.ToString() != NameAttr.ToString()) || (AttVali[f].Name.ToString() != NameAttr.ToString()))
                            {
                                if (AttVali[f].value.ToString() == AttValj[f].value.ToString())
                                {
                                    if (f == AttVali.Count - 1)
                                    {

                                        Temp.Add(__Objects[j].__Name);


                                    }//Reach the Last Attribute
                                    else
                                    {
                                        continue;
                                    }


                                }// If Attributes_Values are Equal 
                                else
                                {
                                    break;
                                }// If Attributes_Values are Not Equal
                            }//For Remove Specified Attribute From Indecirnibility
                            else
                            {
                                if (f == AttVali.Count - 1)
                                {
                                    Temp.Add(__Objects[j].__Name);
                                }//When we Remove Final Attribute 
                                continue;

                            }


                        }//Loop to Search All Atributes 



                    }//Else To Not Compare each item with itself 


                }//For Jitems

                Result.Add(Temp);
            }// For Iitems
            return Result;
        }
        // Compute Indecernibility under all defined attributes AT in the information table "Table"
        public List<List<object>> Indecernibility()
        {
            List<List<object>> Result = new List<List<object>>();
            for (int i = 0; i < __Objects.Count; i++)
            {
                List<object> Temp = new List<object>();
                Temp.Add(__Objects[i].__Name);

                for (int j = 0; j < __Objects.Count; j++)
                {
                    if (i == j)
                        continue;
                    else
                    {
                        List<Attribute> AttVali = ((List<Attribute>)h[__Objects[i].__Name]);
                        List<Attribute> AttValj = ((List<Attribute>)h[__Objects[j].__Name]);
                        for (int f = 0; f < AttVali.Count; f++)
                        {
                            Console.WriteLine(AttVali[f].value.ToString());
                            if (AttVali[f].value.ToString() == AttValj[f].value.ToString())
                            {
                                if (f == AttVali.Count - 1)
                                {

                                    Temp.Add(__Objects[j].__Name);


                                }//Reach the Last Attribute
                                else
                                {
                                    continue;
                                }


                            }// If Attributes_Values are Equal 
                            else
                            {
                                break;
                            }// If Attributes_Values are Not Equal 


                        }//Loop to Search All Atributes 



                    }//Else To Not Compare each item with itself 


                }//For Jitems

                Result.Add(Temp);
            }// For Iitems
            return Result;
        }
        
    }
}
