using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Transform bulletSpawnPoint;

    public Vector2 directionalInput;

    public GameObject bullet;

    public GameObject spawnedBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)directionalInput * speed * Time.deltaTime;

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        
        directionalInput = context.ReadValue<Vector2>();
        
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        }

    }
}
