using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float SmoothTime = 0.3f;
    Vector3 thisVelocity = Vector3.zero;
    public bool inDeadzone;
    public Physics PhysicsScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PhysicsScript.inDDZ == false)
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10f));
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref thisVelocity, SmoothTime);
        }
    }
}
