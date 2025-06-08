using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movSpeedCam = 0.15f;
    [SerializeField] private Vector3 _offset;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 cameraPosition = _target.position + _offset;
        Vector3 smoothCamera = Vector3.Lerp(transform.position, cameraPosition, _movSpeedCam);

        transform.position = smoothCamera;

    }
}
