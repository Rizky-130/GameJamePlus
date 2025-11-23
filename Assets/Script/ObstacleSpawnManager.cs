using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject nyiroroATK;
    public float spawnDistance = 20f;
    private Transform player;
    public DifficultyManager diff;

    private float timer;
    private float timerATK;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerATK += Time.deltaTime;

        // spawnInterval mengikuti currentSpeed
        float currentInterval = Mathf.Clamp(23f / diff.currentSpeed, 0.5f, 20f);
        float currentInterval2 = Mathf.Clamp(40f / diff.currentSpeed, 0.5f, 31f);

        if (timer >= currentInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
        if(timerATK>= currentInterval2)
        {
            SpawnATK();
            timerATK = 0f;
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = player.position + Vector3.right * spawnDistance;
        int randomIndex = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[randomIndex], spawnPos, Quaternion.identity);
    }
    void SpawnATK()
    {
        Vector3 spawnPos = player.position + Vector3.left * spawnDistance;
        spawnPos.y = -3.9f;
        Instantiate(nyiroroATK, spawnPos, Quaternion.identity);
    }
}
