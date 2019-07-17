using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace TestCompenents.sharedComponents
{
    public class BaseController : Frame
        {
            private Dictionary<string, object> cache = new Dictionary<string, object>();

            public BaseController()
            {
                this.Padding = new Thickness(0, 0, 0, 0);
            }

            protected T FindByViewPrivate<T>(string name)
            {
                if (this.cache.ContainsKey(name))
                {
                    return (T)this.cache[name];
                }

                Type t = this.GetType();
                FieldInfo fi = t.GetRuntimeFields().FirstOrDefault(f => f.Name == name);
                if (fi == null) throw new NullReferenceException(string.Format("Field {0} not found.", name));
                T value = (T)fi.GetValue(this);
                this.cache.Add(name, value);
                return value;
            }
        }
    }
