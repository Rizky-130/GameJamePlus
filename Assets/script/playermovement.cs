using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;   

public class SimpleJump2D : MonoBehaviour
{
    public float jumpForce = 8f;
    private Animator anim;
    public AudioSource jumpSound;
    public AudioSource damageSound;
    [SerializeField] private int health = 2;
    public TMP_Text healthText;
    private Rigidbody2D rb;
   
    [SerializeField] private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && health > 0)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("Jump", true);
        }

        if (health <= 0)
        {
            StartCoroutine(WaitGameOver());
        }

        healthText.text = "Nyawa sisa " + health +"x";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
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
        yield return new WaitForSeconds(5f);
        Gameover();
    }

    public void Gameover()
    {
        SceneManager.LoadScene("game_over");
    }
}
