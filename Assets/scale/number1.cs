using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number1 : MonoBehaviour
{
    public int speed;
    public int Jump;
    Rigidbody2D myRig;
    Animator myanim;
    AudioSource _Adioplayer;
    public  AudioClip sound_jump;
    public bool Ground;
    public GameObject Menu;
    public GameObject Win;
    bool Go_Left, Go_Right;
    bool Move = true;

    // Use this for initialization
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        _Adioplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (Go_Right)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(1.04f, transform.localScale.y, transform.localScale.z);
                myanim.SetBool("Run", true);
            }
            if (Go_Left)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(-1.04f, transform.localScale.y, transform.localScale.z);
                myanim.SetBool("Run", true);


            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(1.04f, transform.localScale.y, transform.localScale.z);
                myanim.SetBool("Run", true);

            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(-1.04f, transform.localScale.y, transform.localScale.z);
                myanim.SetBool("Run", true);
            }

            if (!Input.GetKey(KeyCode.S) && (!Input.GetKey(KeyCode.A)) & Go_Left == false && Go_Right == false)
            {
                myanim.SetBool("Run", false);

            }
            if (Input.GetKeyDown(KeyCode.Space) && Ground)
            {
                myRig.velocity = new Vector2(myRig.velocity.x, Jump);
                myanim.Play("jump");
                _Adioplayer.PlayOneShot(sound_jump);
            }
            if (transform.position.y < -5)
            {
                Menu.SetActive(true);
                Destroy(gameObject);

            }
        }
        if (Move == false)
        {
            myanim.SetBool("Run", false);
        }
    }
 
    void onCollisionEnter2D(Collision2D tagsplayer)
    {
        if (tagsplayer.gameObject.tag == "Ground")
        {
            Ground = true;
        }
    }
    void onCollisionExit2D(Collision2D tagsplayer)
    {
        if (tagsplayer.gameObject.tag == "Ground")
        {
            Ground = false;
        }
    }
    void OnTriggerEnter2D(Collider2D tagsplayer)
    {
        if (tagsplayer.tag == "Win")
        {
            Move = false;
            Win.SetActive(true);

        }
        if (tagsplayer.tag == "Enemy")
        {
            Destroy(gameObject);
            Menu.SetActive(true);
        }
    }
    public void Click_Down_Right()
    {
        Go_Right = true;
    }
    public void Click_Up_Right()
    {
        Go_Right = false;
    }
    public void Click_Down_Left()
    {
        Go_Left =true;
    }
    public void Clik_Up_Left()
    {
        Go_Left = false;
    }
    public void Clik_jump()
    {
        if (Ground)
        {
            myRig.velocity = new Vector2(myRig.velocity.x, Jump);
            myanim.Play("jump");
            _Adioplayer.PlayOneShot(sound_jump);
        }

    }

    public float jump { get; set; }

    public AudioClip Sound_Jump { get; set; }
}