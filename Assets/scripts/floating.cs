using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour
{
    public Transform top;
    public Transform down;
    public bool movingT;
    public bool movingD;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingT == true)
        {
            transform.Translate(0, speed, 0);
            if (transform.position.y > top.position.y)
            {
                movingD = true;
                movingT = false;
            }
        }

        if (movingD == true)
        {
            transform.Translate(0, -speed, 0);
            if (transform.position.y < down.position.y)
            {
                movingT = true;
                movingD = false;
            }
        }
    }
}
