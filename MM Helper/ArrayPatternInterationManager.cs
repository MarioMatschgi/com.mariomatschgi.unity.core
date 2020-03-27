using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayPatternInterationManager
{


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    #endregion

    #region Gameplay Methodes
    /*
     *
     * 
     *  Gameplay Methodes
     *
     *  
     */

    public static int[] GetIndexSpiral(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexInvertedSpiral(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexBottomTopToCenter(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexLeftRightToCenter(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexBottomToTop(int _x, int[] _bounds)
    {
        int[] arr = { 0, 0 };

        arr[0] = _x - (_bounds[0] * Mathf.FloorToInt(_x / _bounds[0]));
        arr[1] = Mathf.FloorToInt(_x / _bounds[0]);

        return arr;
    }

    public static int[] GetIndexTopToBottom(int _x, int[] _bounds)
    {
        int[] arr = { 0, 0 };

        arr[0] = _bounds[0] - 1 - (_x - (_bounds[0] * Mathf.FloorToInt(_x / _bounds[0])));
        arr[1] = _bounds[1] - 1 - Mathf.FloorToInt(_x / _bounds[0]);

        return arr;
    }

    public static int[] GetIndexLeftToRight(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexRightToLeft(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexDiagonalLU(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexDiagonalLO(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexDiagonalRO(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexDiagonalRU(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    public static int[] GetIndexRandom(int _x)
    {
        int[] arr = { 0, 0 };

        return arr;
    }

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}
