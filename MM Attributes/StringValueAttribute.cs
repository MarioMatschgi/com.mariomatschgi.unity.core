using System;
using System.Reflection;
using MM.Attributes;

namespace MM
{
    namespace Attributes
    {
        public class StringValueAttribute : Attribute
        {
            /// <summary>
            /// Holds the stringvalue for a value in an enum
            /// </summary>
            public string stringValue { get; protected set; }

            /// <summary>
            /// Constructor used to init a StringValueAttribute with a string value <paramref name="_value"/>
            /// </summary>
            /// <param name="_value"></param>
            public StringValueAttribute(string _value)
            {
                stringValue = _value;
            }
        }
    }

    namespace Extentions
    {
        public static class StringValueAttributeExtention
        {
            /// <summary>
            /// Gets the string value of the StringValueAttribute
            /// </summary>
            /// <param name="_value"></param>
            /// <returns>the gotten string value</returns>
            public static string GetStringValue(this Enum _value)
            {
                // Get the stringvalue attributes
                StringValueAttribute[] _attribs = _value.GetType().GetField(_value.ToString()).GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                // Return the first if there was a match.
                return _attribs.Length > 0 ? _attribs[0].stringValue : null;
            }
        }
    }
}