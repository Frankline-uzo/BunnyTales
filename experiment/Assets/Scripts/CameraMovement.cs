using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    public Vector2 max;
    public Vector2 min;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetposition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetposition.x = Mathf.Clamp(targetposition.x, min.x, max.x);
            targetposition.y = Mathf.Clamp(targetposition.y, min.y, max.y);

            transform.position = Vector3.Lerp(transform.position, targetposition, smoothing);

        }
    }
}
