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
    public int coin = 0;
    public Text uiTxt;
    public Image whiteD;
    public Image blackD;
    public GameObject lastPlat;
    public bool move = true;
    public AudioSource coinA;
    public AudioSource jumpA;
    public AudioSource arrowA;

    // Start is called before the first frame update
    void Start()
    {
        whiteD.enabled = false;
        blackD.enabled = false;
        lastPlat.SetActive(false);
    }

    // Update is called once per frame
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
    void Update()
    {
        if (white == true && black == true)
        {
            lastPlat.SetActive(true);
        }

        if (onGround.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && move == true)
            {
                thisRigidbody.isKinematic = false;
                thisRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpA.Play();
            }
            //thisRigidbody.gravityScale = 2;
        }
        else
        {
            thisRigidbody.gravityScale = gravityInAir;
        }

        string coinS = coin.ToString();
        uiTxt.text = coinS;

    }

    public void OnTriggerStay2D(Collider2D other)
    {
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

        if (other.name == "door_close" && black == true && white == true)
        {
            white_door.moving_in = true;
            black_door.moving_in = true;
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.sortingOrder = -10;
            move = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            coin += 1;
            Destroy(collision.gameObject);
            coinA.Play();
            
        }
    }
}

