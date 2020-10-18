using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corresponding_wall : MonoBehaviour
{
    public pick_up slime;
    public Rigidbody2D wall;
    public bool picked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.picked == true)
        {
            picked = true;
        }
    }
}
