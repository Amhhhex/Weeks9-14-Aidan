using UnityEditor;
using UnityEngine;

public class HeartRateMonitor : MonoBehaviour
{

    public float timer;
    public AnimationCurve curve;
    public TrailRenderer trail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;

        Vector2 position = transform.position;

        position.x += 2 * Time.deltaTime;

        Vector2 worldToScreenPosition = Camera.main.WorldToScreenPoint(position);

        Debug.Log(worldToScreenPosition.x);

        if(worldToScreenPosition.x < Screen.width)
        {
            trail.emitting = true;
        }

        float newYPosition = curve.Evaluate(timer);

        position.y = newYPosition;

        if(timer > 3f)
        {
            timer = 0f;
        }

        if(worldToScreenPosition.x > Screen.width - 5)
        {
            trail.emitting = false;
        }

        if (worldToScreenPosition.x > Screen.width)
        {
            worldToScreenPosition.x = 0;
            position = Camera.main.ScreenToWorldPoint(worldToScreenPosition);
        }
        transform.position = position;

    }
}
