using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_platform : MonoBehaviour
{
    public corresponding_wall arrow;
    private bool create_p = false;
    public Transform object_position;
    public Transform object_position2;
    public bool left;
    public bool right;
    public Transform slime;
    public Transform small_arrows;
    public SpriteRenderer SR;
    public Transform top;
    public Transform down;
    private bool middle;
    public corresponding_wall backup_arrow;
    public AudioSource outA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (top.position.y > slime.position.y && down.position.y < slime.position.y)
        {
            middle = true;
        }
        else
        {
            middle = false;
        }

        if (left == true || right == true)
        {
            if (arrow.picked == true && create_p == false)
            {
                PlatformEffector2D p = gameObject.AddComponent(typeof(PlatformEffector2D)) as PlatformEffector2D;
                create_p = true;
            }

            if (create_p == true)
            {
                if (left == true)
                {
                    PlatformEffector2D p = GetComponent<PlatformEffector2D>();
                    p.surfaceArc = 180;
                    p.rotationalOffset = 270;
                }

                if (right == true)
                {
                    PlatformEffector2D p = GetComponent<PlatformEffector2D>();
                    p.surfaceArc = 180;
                    p.rotationalOffset = 90;
                }
            }
        }

        if (arrow == null)
        {
            arrow = backup_arrow;
        }


            if (left == true && middle == true)
            {
                if (slime.position.x > object_position.position.x && slime.position.x < object_position2.position.x)
                {
                    Destroy(small_arrows.gameObject);
                    Destroy(arrow.gameObject);
                    PlatformEffector2D p = GetComponent<PlatformEffector2D>();
                    Destroy(p);
                    left = false;
                    SR.color = Color.green;
                    outA.Play();

                }
            }

            if (right == true && middle == true)
            {
                if (slime.position.x < object_position.position.x && slime.position.x > object_position2.position.x)
                {
                    Destroy(small_arrows.gameObject);
                    Destroy(arrow.gameObject);
                    PlatformEffector2D p = GetComponent<PlatformEffector2D>();
                    Destroy(p);
                    right = false;
                    SR.color = Color.green;
                    outA.Play();
                }
            }
        
    }
}
