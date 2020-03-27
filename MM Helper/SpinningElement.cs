using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningElement : MonoBehaviour
{
    [Header("General")]
    public Vector3 rotationAxis;
    public float rotationSpeed;


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Start()
    {
        
    }

    void Update()
    {
        // Rotate
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }    

    #endregion

    #region Gameplay Methodes
    /*
     *
     * 
     *  Gameplay Methodes
     *
     *  
     */

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}
