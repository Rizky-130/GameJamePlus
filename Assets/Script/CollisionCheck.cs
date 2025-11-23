using UnityEngine;
public class CollisionCheck : MonoBehaviour
{
    public DifficultyManager diff;
    public Transform player;
    private bool passed = false;

    void Start()
    {
        diff = FindObjectOfType<DifficultyManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Jika obstacle sudah lewat posisi Player di sumbu X
        if (!passed && transform.position.x < player.position.x)
        {
            passed = true;
            diff.playerSepuh(); // speed naik!
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            diff.playerHit();
        }
    }
}
