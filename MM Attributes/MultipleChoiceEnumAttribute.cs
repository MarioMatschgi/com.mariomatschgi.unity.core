using System;
using System.Collections.Generic;
using UnityEngine;

namespace MM
{
    namespace Attributes
    {
        /// <summary>
        /// Put this Attribute on an enum variable if you want it to be able to have multiple values
        /// </summary>
        public class MultipleChoiceEnumAttribute : PropertyAttribute
        {
            public MultipleChoiceEnumAttribute()
            {

            }
        }
    }

    namespace Extentions
    {
        public static class MultipleChoiceEnumExtentions
        {
            /// <summary>
            /// Returns the all values of an enum, if the variable has the Attriute MultiChoiceEnum
            /// </summary>
            /// <param name="_enum"></param>
            /// <returns></returns>
            public static List<int> ReturnAllEnumValues(this Enum _enum)
            {
                List<int> selectedElements = new List<int>();
                for (int i = 0; i < Enum.GetValues(_enum.GetType()).Length; i++)
                {
                    int layer = 1 << i;
                    if (((int)(IConvertible)_enum & layer) != 0)
                        selectedElements.Add(i);
                }

                return selectedElements;
            }
        }
    }
}
