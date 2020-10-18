using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topCheck : MonoBehaviour
{
    public bool headTouch = false;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        headTouch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        headTouch = false;
    }
}
