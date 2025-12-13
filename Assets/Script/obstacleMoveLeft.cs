using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMoveLeft : MonoBehaviour
{
    public DifficultyManager diff;
    public float speed;
    public float lifeTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifeTime);

        diff = FindObjectOfType<DifficultyManager>();
    }

    // Update is called once per frame
        void Update()
    {
        transform.Translate(Vector3.left * (diff.currentSpeed + speed) * Time.deltaTime);
    }

    
}
