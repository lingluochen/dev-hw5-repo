using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class ray_casing : MonoBehaviour
{
    public float maxDistance = 2f;
    public Transform ray_dir;
    SpriteRenderer thisSprite;
    public LayerMask myLayerMask;
    public bool vertical;
    private int one = -1;
    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (one > 0)
        {
            Ray myRay = new Ray(transform.position, ray_dir.position - transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(myRay.origin, myRay.direction, maxDistance, myLayerMask);

            if (rayHit.collider != null && rayHit.collider.gameObject.CompareTag("coll_wall"))
            {
                one *= -1;
            }
        }
        else
        {
            Ray myRay = new Ray(transform.position, transform.position- ray_dir.position );
            RaycastHit2D rayHit = Physics2D.Raycast(myRay.origin, myRay.direction, maxDistance, myLayerMask);

            if (rayHit.collider != null && rayHit.collider.gameObject.CompareTag("coll_wall"))
            {
                one *= -1;
            }
        }
        
        if (vertical == true) {
            transform.Translate(0, -3f * Time.deltaTime * one, 0);
        }
        else
        {
            transform.Translate(-3f * Time.deltaTime * one, 0, 0);
        }
 
    }
}
