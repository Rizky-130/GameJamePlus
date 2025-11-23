using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyiRoroKidulATK : MonoBehaviour
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
        transform.Translate(Vector3.right * (1.2f * diff.currentSpeed) * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
