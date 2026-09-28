using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS;

internal class InAndOutKeywords
{
    public static void Test()
    {
        ICovariant<Object> iobj = new Sample<Object>();
        ICovariant<String> istr = new Sample<String>();

        // You can assign istr to iobj because
        // the ICovariant interface is covariant.
        //iobj = istr;

        // Assignment compatibility.
        string str = "test";
        // An object of a more derived type is assigned to an object of a less derived type.
        object obj = str;

        // Covariance.
        IEnumerable<string> strings = new List<string>();
        // An object that is instantiated with a more derived type argument
        // is assigned to an object instantiated with a less derived type argument.
        // Assignment compatibility is preserved.
        IEnumerable<object> objects = strings;

        // Contravariance.
        // Assume that the following method is in the class:
        static void SetObject(object o) { }
        Action<object> actObject = SetObject;
        // An object that is instantiated with a less derived type argument
        // is assigned to an object instantiated with a more derived type argument.
        // Assignment compatibility is reversed.
        Action<string> actString = actObject;
    }
}

// Covariant interface.
interface ICovariant<out R> { }

// Extending covariant interface.
interface IExtCovariant<out R> : ICovariant<R> { }

// Implementing covariant interface.
class Sample<R> : ICovariant<R> { }

