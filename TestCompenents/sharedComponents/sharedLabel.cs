using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace TestCompenents.sharedComponents
{

#if __IOS__
    public class ICustomLabel : Label
#else
    public class sharedLabel : Label
#endif
    {
        public sharedLabel()
        {
            Debug.WriteLine("test");
        }
    }
}
