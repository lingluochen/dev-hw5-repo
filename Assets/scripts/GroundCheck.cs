using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;
    public void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
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
