using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_power : MonoBehaviour
{
    public Animator thisAnimator;
    public BoxCollider2D thisBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("laser"))
        {
            thisBox.enabled = true;
        }
        else
        {
            thisBox.enabled = false;
        }
    }
}
