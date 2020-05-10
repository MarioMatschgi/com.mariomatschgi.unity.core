using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MM
{
    namespace Extentions
    {
        public static class SerializedPropertyExtensions
        {
#if UNITY_EDITOR
            /// <summary>
            /// Gets value from SerializedProperty <paramref name="_property"/> - even if value is nested. Return-Type is object, cast if needed
            /// </summary>
            /// <param name="_property"></param>
            /// <returns>the gotten object</returns>
            public static object GetValue(this SerializedProperty _property)
            {
                object _obj = _property.serializedObject.targetObject;

                foreach (string _path in _property.propertyPath.Split('.'))
                    _obj = _obj.GetType().GetField(_path).GetValue(_obj);

                return _obj;
            }

            /// <summary>
            /// Sets value <paramref name="_val"/> for SerializedProperty <paramref name="_property"/> - even if value is nested
            /// </summary>
            /// <param name="_property"></param>
            /// <param name="_val"></param>
            public static void SetValue(this SerializedProperty _property, object _val)
            {
                object _obj = _property.serializedObject.targetObject;

                List<KeyValuePair<FieldInfo, object>> _list = new List<KeyValuePair<FieldInfo, object>>();

                FieldInfo _field = null;
                foreach (string _path in _property.propertyPath.Split('.'))
                {
                    _field = _obj.GetType().GetField(_path);
                    _list.Add(new KeyValuePair<FieldInfo, object>(_field, _obj));
                    _obj = _field.GetValue(_obj);
                }

                // Now set values of all objects, from child to parent
                for (int i = _list.Count - 1; i >= 0; --i)
                {
                    _list[i].Key.SetValue(_list[i].Value, _val);
                    // New 'val' object will be parent of current 'val' object
                    _val = _list[i].Value;
                }
            }
#endif
        }
    }
}