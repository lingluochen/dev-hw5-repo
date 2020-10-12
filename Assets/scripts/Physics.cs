using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Physics : MonoBehaviour
{
    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody;
    public float force;
    public float jumpForce;
    public GroundCheck onGround;
    public float gravityInAir;
    public bool inDDZ;
    public float enter_ddz;
    public bool white = false;
    public bool black = false;
    public door_move white_door;
    public door_move black_door;
    public door_move shut;
    public float coin = 0;
    public Text uiTxt;
    public Image whiteD;
    public Image blackD;
    public GameObject lastPlat;
    public bool move = true;
    public AudioSource coinA;
    public AudioSource jumpA;
    public AudioSource arrowA;
    public AudioSource bounceA;
    public Transform teleport;
    public Animator slimeAnim;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        whiteD.enabled = false;
        blackD.enabled = false;
        lastPlat.SetActive(false);
    }

    // move
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && move == true)
        {
            transform.Translate(-force * Time.deltaTime, 0, 0);
            if (thisSprite.flipX == true)
            {
                thisSprite.flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.D) && move == true)
        {
            transform.Translate(force * Time.deltaTime, 0, 0);
            if (thisSprite.flipX == false)
            {
                thisSprite.flipX = true;
            }
        }
    }
    //jump, coin, teleport
    void Update()
    {
        Math.Ceiling(coin);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (white == true && black == true)
        {
            lastPlat.SetActive(true);
        }

        //jump
        if (onGround.isGrounded == true)
        {

            slimeAnim.SetBool("jump", false);
            if (Input.GetKeyDown(KeyCode.Space) && move == true)
            {
                
                thisRigidbody.isKinematic = false;
                thisRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpA.Play();
               
            }
        }
        else
        {
            thisRigidbody.gravityScale = gravityInAir;
            slimeAnim.SetBool("jump", true);
        }

        string coinS = coin.ToString();
        uiTxt.text = coinS;

        //teleport
        if (move == false)
        {
            counter += 1;
            if (counter > 300)
            {
                transform.position = teleport.position;
                move = true;
            }
        }

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        //diamond collect
        if (other.name == "white_diamond")
        {
            white = true;
            Destroy(other.gameObject);
            whiteD.enabled = true;
            arrowA.Play();
        }

        if (other.name == "black_diamond")
        {
            black = true;
            Destroy(other.gameObject);
            blackD.enabled = true;
            arrowA.Play();
        }

        if (other.name == "door_middle")
        {
            if (black == true && white == true)
            {
                white_door.moving_out = true;
                black_door.moving_out = true;
            }
        }

        //door close
        if (other.name == "door_close" && black == true && white == true)
        {
            white_door.moving_in = true;
            black_door.moving_in = true;
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.sortingOrder = -10;
            move = false;
        }

        //bounce
        if (other.tag == "bounce")
        {
            thisRigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            bounceA.Play();
        }

    }

   //pick up coins
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            coin += 0.5f;
            
            coinA.Play();
            
        }
    }

    //bounce

}

