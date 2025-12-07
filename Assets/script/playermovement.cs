using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;   

public class SimpleJump2D : MonoBehaviour
{
    public float jumpForce = 8f;
    private Animator anim;
    public AudioSource jumpSound;
    public int maxjump = 2;
    [SerializeField] private int currentjump = 0;   
    public AudioSource damageSound;
    [SerializeField] private int health = 1;
    
    private Rigidbody2D rb;
   
    [SerializeField] private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && health > 0)
        {
            if (currentjump < maxjump)
            {
                jumping();

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && health > 0)
        {
            crouch();
        }

        if (health <= 0)
        {
            StartCoroutine(WaitGameOver());
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
            currentjump = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dump"))
        {
            

            health -= 1;
            damageSound.Play();
            anim.SetTrigger("Damage");
        }
    }

    IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(2f);
        Gameover();
    }

    public void Gameover()
    {
        SceneManager.LoadScene("game_over");
    }

    public void jumping()
    {
        currentjump += 1;
        jumpSound.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetBool("Jump", true);
    }

    public void crouch()
    {
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    }
}
