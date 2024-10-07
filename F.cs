using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializerNamespace
{   
    class F 
    { 
        public int i1, i2, i3, i4, i5; 
        public static F Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };

        public static F DeserializeFromCsv(string _csvString)
        {
            try
            {
                string[] fields = _csvString.Split(',');

                F newDeserializedObject = new F
                {
                    i1 = int.Parse(fields[0]),
                    i2 = int.Parse(fields[1]),
                    i3 = int.Parse(fields[2]),
                    i4 = int.Parse(fields[3]),
                    i5 = int.Parse(fields[4])
                };

                return newDeserializedObject;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
