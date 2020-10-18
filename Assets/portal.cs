using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform teleport1;
    public Transform teleport2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "portal1")
        {
            transform.position = teleport2.position;
        }
        if (collision.name == "portal2")
        {
            transform.position = teleport1.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
