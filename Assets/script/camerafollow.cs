using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.25f; // makin kecil = makin cepat kamera mengejar

    private float originalY;
    private float currentVelocityY; // dipakai internal oleh SmoothDamp
    private bool isNaik = false;

    // Hysteresis: batas naik dan turun dibedakan biar tidak flip-flop
    private const float batasNaik = 3.06f;
    private const float batasTurun = 2.0f; // sesuaikan, harus lebih kecil dari batasNaik

    private void Start()
    {
        originalY = transform.position.y;
    }

    private void LateUpdate()
    {
        float yValue = target.position.y;

        // Cek naik/turun pakai 2 batas berbeda, bukan 1 batas tunggal
        if (!isNaik && yValue >= batasNaik)
        {
            isNaik = true;
        }
        else if (isNaik && yValue <= batasTurun)
        {
            isNaik = false;
        }

        float targetY = isNaik ? 4.13f : originalY;

        Vector3 current = transform.position;
        float smoothedY = Mathf.SmoothDamp(current.y, targetY, ref currentVelocityY, smoothTime);

        transform.position = new Vector3(current.x, smoothedY, current.z);
    }
}