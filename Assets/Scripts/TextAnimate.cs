using UnityEngine;

public class TextAnimate : MonoBehaviour
{
    public bool  Pulse;
    public float pulseSpeed = 10f;
    public float pulseAmount = 0.2f;


    public bool Spin;
    public float spinSpeed = 180f;

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        if (Pulse) PulseAnim();
        if (Spin) SpinAnim();
    }


    private void PulseAnim()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = startScale * scale;
    }

    private void SpinAnim()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }



}
