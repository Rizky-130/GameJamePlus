using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [Header("Kecepatan berdasarkan kurva")]
    public AnimationCurve speedCurve;
    public float baseSpeed = 5;
    public float currentSpeed;
    private float timeProgress;

    [Header("Adaptif dificulty")]
    public float skillFactor = 1f;
    public float skillIncreaseRate = 0.03f;
    public float recoverRate = 0.1f;
    public float maxSkillFactor = 2f;
    // Update is called once per frame
    void Update()
    {
        timeProgress += Time.deltaTime;

        currentSpeed = baseSpeed * speedCurve.Evaluate(timeProgress) * skillFactor;
    }

    public void playerSepuh()
    {
        skillFactor += skillIncreaseRate;
        skillFactor = Mathf.Clamp(skillFactor, 1f, maxSkillFactor);
    }
    public void playerHit()
    {
        Debug.Log("PLAYER HIT! GAME OVER");
        Time.timeScale = 0f; // pause game sementara
    }
}
