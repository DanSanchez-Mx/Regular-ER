using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;

    public float jumpForce;
    private bool spJump;
    private bool isGrounded;
    private bool die;

    [SerializeField] private ParticleSystem Dust;
    private ParticleSystem.EmissionModule emissionDust;

    private const string STATE_ALIVE = "isAlive";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        emissionDust = Dust.emission;
    }

    // Update is called once per frame
    void Update()
    {
        //spJump = true;

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("Estroy brincando");
            Jump();
        }


        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Estoy Agachado");
            Slide();
        }
        else
        {
            anim.SetTrigger("GetUp");
        }

        Die();

        CheckDust();

    }

    void CheckDust()
    {
        if (isGrounded)
        {
            emissionDust.rateOverTime = 30;
        }
        else
        {
            emissionDust.rateOverTime = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            spJump = true;
        }
        else if (spJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            spJump = false;
        }
    }

    public void Slide()
    {
        anim.SetTrigger("Slide");
    }

    void Die()
    {
        if (die == true)
        {
            //animator.SetBool(STATE_ALIVE, false);
            //SoundManager.Instance.EjecutarSonido(dead);
            GameManager.sharedInstance.gameOver();
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            die = true;
        }
        else
        {
            die = false;
        }
    }
}
