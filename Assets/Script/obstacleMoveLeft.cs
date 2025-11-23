using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMoveLeft : MonoBehaviour
{
    public DifficultyManager diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = FindObjectOfType<DifficultyManager>();
    }

    // Update is called once per frame
        void Update()
    {
        transform.Translate(Vector3.left * diff.currentSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
