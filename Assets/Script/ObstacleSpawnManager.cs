using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject bird;
    public GameObject nyiroroATK;
    public float spawnDistance = 20f;
    private Transform player;
    public DifficultyManager diff;

    private float timer;
    private float timerATK;
    private float timerBird;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerATK += Time.deltaTime;
        timerBird += Time.deltaTime;

        // spawnInterval mengikuti currentSpeed
        float currentInterval = Mathf.Clamp(23f / diff.currentSpeed, 0.5f, 20f);
        float currentInterval2 = Mathf.Clamp(40f / diff.currentSpeed, 0.5f,33f);
        float currentInterval3 = Mathf.Clamp(55f / diff.currentSpeed, 0.5f, 53f);

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
        if (timerBird >= currentInterval3)
        {
            spawnBird();
            timerBird =0;
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = player.position + Vector3.right * spawnDistance;
        spawnPos.y = -3;
        int randomIndex = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[randomIndex], spawnPos, Quaternion.identity);
    }
    void SpawnATK()
    {
        Vector3 spawnPos = player.position + Vector3.left * spawnDistance;
        spawnPos.y = -3.9f;
        Instantiate(nyiroroATK, spawnPos, Quaternion.identity);
    }
    void spawnBird()
    {
        Vector3 spawnPos = player.position + Vector3.right * spawnDistance;
        spawnPos.y = 3f;
        Instantiate(bird, spawnPos, Quaternion.identity);
    }
}
