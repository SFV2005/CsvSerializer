using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SerializerNamespace
{
    public class CsvSerializer
    {
        public string Serialize(object _obj)
        {
            if (_obj is null)
            {
                return "";
            }

            var type = _obj.GetType();            
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var values = fields.Select(p =>
            {
                var value = p.GetValue(_obj);
                return value != null ? value.ToString() : "";
            });

            return string.Join(",",values);
        }
    }
}
