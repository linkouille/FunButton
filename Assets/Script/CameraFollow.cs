using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;

    [SerializeField] private bool follow;

    [SerializeField] private bool axisX;
    [SerializeField] private bool axisY;
    [SerializeField] private bool axisZ;

    [SerializeField] private Vector3 offset;

    private Vector3 wantedPos;

    private void Update()
    {
        if (target == null)
            follow = false;
        if (follow)
        {
            wantedPos = transform.position = target.position + offset;

            transform.position = new Vector3(axisX ? wantedPos.x : offset.x, axisY ? wantedPos.y : offset.y, axisZ ? wantedPos.z : offset.z);
        }
    }

}
