using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public class Vector
    {
        int[] body;
        public Vector(int[] body)
        {
            this.body = body;
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            int[] newBody = new int[v1.body.Length];
            for (int i = 0; i < newBody.Length; ++i)
            {
                newBody[i] = v1.body[i] + v2.body[i];
            }
            return new Vector(newBody);
        }
    }
    public interface UObject
    {
        object this[string key] { get; set; }

        //object GetProperty(string propertyName);
        //void SetProperty(string propertyName, object newValue);
    }
}
