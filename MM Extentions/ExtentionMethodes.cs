using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class ExtentionMethodes
{
#if UNITY_EDITOR
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";

        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
#endif


    #region Extention Methodes
    /*
     *
     * 
     *  Extention Methodes
     *
     *  
     */
    
    public static List<T> GetComponentsRecursive<T>(this GameObject gameObject)
    {
        int length = gameObject.transform.childCount;
        List<T> components = new List<T>(length + 1);
        T comp = gameObject.transform.GetComponent<T>();
        if (comp != null) components.Add(comp);
        for (int i = 0; i < length; i++)
        {
            comp = gameObject.transform.GetChild(i).GetComponent<T>();
            if (comp != null) 
                components.Add(comp);
        }
        return components;
    }
     
    /// <summary>
    /// Returns a List of all direct children
    /// </summary>
    /// <param name="_gameObject"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> GetComponentsInDirectChildren<T>(this GameObject _gameObject)
    {
        int _length = _gameObject.transform.childCount;
        List<T> _components = new List<T>(_length);
        for (int i = 0; i < _length; i++)
        {
            T _comp = _gameObject.transform.GetChild(i).GetComponent<T>();
            if (_comp != null) 
                _components.Add(_comp);
        }
        return _components;
    }

    /// <summary>
    /// Remaps the float <paramref name="_value"/> between <paramref name="_from1"/> and <paramref name="_to1"/> to a float between <paramref name="_from2"/> and <paramref name="_to2"/>
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_from1"></param>
    /// <param name="_to1"></param>
    /// <param name="_from2"></param>
    /// <param name="_to2"></param>
    /// <returns></returns>
    public static float Remap(this float _value, float _from1, float _to1, float _from2, float _to2) // Debug.Log(2.5f.Remap(0, 5, 0, 1));   // 0.5
    {
        return (_value - _from1) / (_to1 - _from1) * (_to2 - _from2) + _from2;
    }

    private static bool isSelectionRoutineRunning;
    /// <summary>
    /// Firt Deselects the current selected GameObject and then selects <paramref name="_gameObject"/>
    /// </summary>
    /// <param name="_eventSystem"></param>
    /// <param name="_gameObject"></param>
    public static void SetSelectedGameObjectReal(this EventSystem _eventSystem, GameObject _gameObject)
    {
        if (!isSelectionRoutineRunning)
            _eventSystem.StartCoroutine(SetSelectedGameObjectCorrutine(_eventSystem, _gameObject));
    }
    private static IEnumerator SetSelectedGameObjectCorrutine(EventSystem _eventSystem, GameObject _gameObject)
    {
        _eventSystem.SetSelectedGameObject(null);

        isSelectionRoutineRunning = true;

        yield return null;

        _eventSystem.SetSelectedGameObject(_gameObject);

        isSelectionRoutineRunning = false;
    }

    public static float Floor(this float number, int decimalPlaces)
    {
        return (float)(Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
    }

    /// <summary>
    /// Removes elements of the list which are invalid / missing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_list"></param>
    /// <returns></returns>
    public static List<T> RemoveMissingElements<T>(this List<T> _list)
    {
        for (int i = _list.Count - 1; i > -1; i--)
            if (_list[i] == null || _list[i].Equals(null))
                _list.RemoveAt(i);

        return _list;
    }

    /// <summary>
    /// Copys this string to the clipboard
    /// </summary>
    /// <param name="s"></param>
    public static void CopyToClipboard(this string s)
    {
        TextEditor te = new TextEditor();
        te.text = s;
        te.SelectAll();
        te.Copy();
    }

    /// <summary>
    /// Sorts all children by name A -> Z
    /// </summary>
    /// <param name="_parent"></param>
    public static void SortChildrenByName(this GameObject _parent)
    {
        List<Transform> children = new List<Transform>();

        for (int i = _parent.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = _parent.transform.GetChild(i);
            children.Add(child);
            child.parent = null;
        }

        children.Sort((Transform t1, Transform t2) => { return t1.name.CompareTo(t2.name); });

        foreach (Transform child in children)
            child.parent = _parent.transform;
    }

    #region Angle Methodes
    /*
     *
     * Angle Methodes
     *
     */

    /// <summary>
    /// Transforms this float angle between 0° and 360° to an angle between -180° and 180°
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static float WrapAngle(this float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    /// <summary>
    /// Transforms this float angle between -180° and 180° to an angle between 0° and 360°
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static float UnwrapAngle(this float angle)
    {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }

    #endregion


    #region Vector Methodes
    /*
     *
     * Vector Methodes
     *
     */

    /// <summary>
    /// Rounds this Vector to ints
    /// </summary>
    /// <param name="_in_vector"></param>
    /// <returns></returns>
    public static Vector3 RountToInt(this Vector3 _in_vector)
    {
        Vector3 _out_vector = _in_vector;
        _out_vector.x = Mathf.RoundToInt(_out_vector.x);
        _out_vector.y = Mathf.RoundToInt(_out_vector.y);
        _out_vector.z = Mathf.RoundToInt(_out_vector.z);

        return _out_vector;
    }

    /// <summary>
    /// Clamps this Vector between <paramref name="_min"/> and <paramref name="_max"/>
    /// </summary>
    /// <param name="_in_vector"></param>
    /// <param name="_min"></param>
    /// <param name="_max"></param>
    /// <returns></returns>
    public static Vector3 Clamp(this Vector3 _in_vector, float _min, float _max)
    {
        Vector3 _out_vector = _in_vector;
        _out_vector.x = Mathf.Clamp(_out_vector.x, _min, _max);
        _out_vector.y = Mathf.Clamp(_out_vector.y, _min, _max);
        _out_vector.z = Mathf.Clamp(_out_vector.z, _min, _max);

        return _out_vector;
    }

    #endregion

    #endregion
}
