﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class door_move : MonoBehaviour
{
    public bool white;
    public bool black;
    public bool moving_out = false;
    public bool moving_in = false;
    private float counter1 = 0;
    private float counter2 = 0;
    private bool door_open = false;
    public bool shut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving_out == true)
        {

            counter1 += 1;
            if (counter1 < 20)
            {
                if (white == true)
                {
                    transform.Translate(-5f*Time.deltaTime, 0, 0);
                }
                if (black == true)
                {
                    transform.Translate(5f*Time.deltaTime, 0, 0);
                }
            }
            else
            {
                moving_out = false;
                door_open = true;
            }
        }

        if (moving_in == true && door_open == true)
        {
            counter2 += 1;
            if (counter2 < 20)
            {
                if (white == true)
                {
                    transform.Translate(5f*Time.deltaTime, 0, 0);
                }
                if (black == true)
                {
                    transform.Translate(-5f*Time.deltaTime, 0, 0);
                }
            }else 
            {
                moving_in = false;
            }

        }
    }
}
