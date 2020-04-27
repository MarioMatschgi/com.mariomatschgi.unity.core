using System;
using System.Collections.Generic;
using UnityEngine;

namespace MM
{
    namespace Attributes
    {
        public class MultiChoiceEnumAttribute : PropertyAttribute
        {
            public MultiChoiceEnumAttribute()
            {

            }
        }
    }

    namespace Extentions
    {
        public static class MultiChoiceEnumExtentions
        {
            public static List<int> ReturnSelectedElements(this Enum _enum)
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
