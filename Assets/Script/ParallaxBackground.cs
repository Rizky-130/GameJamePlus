using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [System.Serializable]
    public class parallaxLayer
    {
        public Transform left;
        public Transform right;
        public float speed;
    }
    public parallaxLayer[] layer;

    private float[] width;
    private Vector3[] startPos;

    public DifficultyManager diff;
    // Start is called before the first frame update
    void Start()
    {
        width = new float[layer.Length];
        startPos = new Vector3[layer.Length];

        for (int i = 0; i < layer.Length; i++)
        {
            SpriteRenderer sr = layer[i].left.GetComponent<SpriteRenderer>();
            width[i] = sr.bounds.size.x;
            startPos[i] = layer[i].left.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < layer.Length; i++)
        {
            moveLayer(i);
        }
    }

    void moveLayer(int i)
    {

        float dynamicSpeed = layer[i].speed * diff.currentSpeed;

        layer[i].left.Translate(Vector3.left * dynamicSpeed * Time.deltaTime);
        layer[i].right.Translate(Vector3.left * dynamicSpeed * Time.deltaTime);

        // Reset jika melewati kiri layar
        if (layer[i].left.position.x < startPos[i].x - width[i])
        {
            layer[i].left.position = layer[i].right.position + new Vector3(width[i], 0, 0);
        }
        if (layer[i].right.position.x < startPos[i].x - width[i])
        {
            layer[i].right.position = layer[i].left.position + new Vector3(width[i], 0, 0);
        }
    }
}
