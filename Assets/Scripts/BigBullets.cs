using UnityEngine;

public class BigBullets : MonoBehaviour
{
    public float speed;

    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentPosition = transform.position;

        currentPosition.x += speed * Time.deltaTime;

        transform.position = currentPosition;


    }
}
