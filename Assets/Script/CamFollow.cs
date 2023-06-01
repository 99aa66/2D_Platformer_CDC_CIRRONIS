using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] public Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
