using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MTCameraPanning : MonoBehaviour
{
    [Header("General")]
    public int zoomOffset;
    [Space]
    public List<Transform> targets;
    [Space]
    public float smoothTime;
    public float minZoom = 5;
    public float maxYX;
    public float maxYZ;
    public float zoomDividerX;
    public float zoomDividerZ;

    private Vector3 positioning_velocity;


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

    }

    void LateUpdate()
    {
        targets.RemoveMissingElements();

        if (targets.Count <= 0 || targets[0] == null)
            return;

        // Positioning
        Vector3 _pos = GetCenterPoint();

        Camera _mainCam = GetComponent<Camera>();
        Bounds _bounds = GetBounds();
        _bounds.size += Vector3.one * zoomOffset;// * MapGenerator.instance.grid.tile_size;

        maxYX = ((_bounds.size.x / 3) + 2) / Mathf.Tan((_mainCam.fieldOfView / 2) * Mathf.Deg2Rad);
        maxYZ = ((_bounds.size.z / 2) + 2) / Mathf.Tan((_mainCam.fieldOfView / 2) * Mathf.Deg2Rad);

        float _yx = Mathf.Lerp(0, maxYX, _bounds.size.x / (_bounds.size.x - 2));
        float _yz = Mathf.Lerp(0, maxYZ, _bounds.size.z / (_bounds.size.z - 2));

        if (_yx > _yz)
        {
            _pos.y = _yx;
            _pos.y = Mathf.Clamp(_pos.y, minZoom, maxYX);
        }
        else
        {
            _pos.y = _yz;
            _pos.y = Mathf.Clamp(_pos.y, minZoom, maxYZ);
        }

        transform.position = Vector3.SmoothDamp(transform.position, _pos, ref positioning_velocity, smoothTime);
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

    /// <summary>
    /// Returns a float representing the greatest distance in the BoundsRect
    /// </summary>
    /// <returns></returns>
    public float GetGreatestDistance()
    {
        return Mathf.Max(GetBounds().size.x, GetBounds().size.y, GetBounds().size.z);
    }

    /// <summary>
    /// Returns a Vector3 representing the center point of the BoundsRect
    /// </summary>
    /// <returns></returns>
    public Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;

        return GetBounds().center;
    }

    /// <summary>
    /// Returns the Bounds in which all targets are encapsulated
    /// </summary>
    /// <returns></returns>
    public Bounds GetBounds()
    {
        var _bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
            _bounds.Encapsulate(targets[i].position);

        return _bounds;
    }

    #endregion
}
