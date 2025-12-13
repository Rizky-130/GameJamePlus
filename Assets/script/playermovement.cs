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
    public Collider2D colstand;
    public Collider2D coldown;
    private Rigidbody2D rb;
    private bool isDead = false;


    [SerializeField] private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coldown.enabled = false;

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

        if (health <= 0 && !isDead)
        {
            StartCoroutine(DeathAnimation());
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
        if (other.gameObject.CompareTag("Dump"))
        {
            health -= 1;
            damageSound.Play();
            anim.SetTrigger("Damage");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;

        }
    }

    // private void OnCollisionEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Dump"))
    //     {


    //         health -= 1;
    //         damageSound.Play();
    //         anim.SetTrigger("Damage");
    //     }
    // }

    IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(2f);
        Gameover();
    }

    IEnumerator crouchtime()
    {
        yield return new WaitForSeconds(0.5f);
        coldown.enabled = false;
        colstand.enabled = true;
    }

    public void Gameover()
    {
        FindObjectOfType<ScoreUI>().SaveScoreOnGameOver();
        SceneManager.LoadScene("game_over");
    }

    public void jumping()
    {
        currentjump += 1;
        jumpSound.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetBool("Jump", true);
        Debug.Log("jump");
    }

    public void crouch()
    {
        jumpSound.Play();
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        anim.SetTrigger("Crouch");
        colstand.enabled = false;
        coldown.enabled = true;
        StartCoroutine(crouchtime());
    }
    IEnumerator DeathAnimation()
    {
        isDead = true;

        // Matikan kontrol & collider
        colstand.enabled = false;
        coldown.enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;

        Vector3 startPos = transform.position;
        float duration = 0.7f;
        float jumpHeight = 2f;
        float fallDistance = 4f;
        float spinSpeed = 720f;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;

            // Gerak lompat → jatuh (parabola)
            float yOffset = Mathf.Sin(progress * Mathf.PI) * jumpHeight
                            - progress * fallDistance;

            transform.position = startPos + Vector3.up * yOffset;

            // Putar
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

            yield return null;
        }

        rb.gravityScale = 1;
        Gameover();
    }

}
