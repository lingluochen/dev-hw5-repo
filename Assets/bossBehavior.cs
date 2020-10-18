using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    private float r = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r += 20;
        transform.rotation = Quaternion.Euler(0, 0, r * Time.deltaTime);

    }
}
