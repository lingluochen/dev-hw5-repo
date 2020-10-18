using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeDetector : MonoBehaviour
{
    public bool onEdge = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onEdge = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onEdge = false;
    }
}
