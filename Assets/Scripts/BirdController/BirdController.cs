using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    private GameObject spawer;

    public float flag = 0;
    public int score = 0;


    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
        spawer = GameObject.Find("Spawner Pipe");
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }

    void _BirdMoveMent()
    {
        if (isAlive == true)
        {
            if (didFlap == true)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
        //     audioSource.PlayOneShot(flyClip);
        // }

        if (myBody.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 70, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -45, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void FlapButton()
    {
        didFlap = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            audioSource.PlayOneShot(pingClip);
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore(score);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive == true)
            {
                isAlive = false;
                Destroy(spawer);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._BirdDiedShowPanel(score);
            }
        }
    }
}
