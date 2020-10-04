using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour
{
    private Collider2D arrow;
    private Collider2D wall;
    public bool picked;
    public AudioSource arrowA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (picked == true && arrow != null) 
        {
            arrow.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "arrow")
        {
            arrow = collision;
            picked = true;
            arrowA.Play();
        }
    }

    
}
