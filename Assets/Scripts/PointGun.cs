using UnityEngine;
using UnityEngine.InputSystem;

public class PointGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {






    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed) { 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        transform.up = mousePosition;
        } 
    }

    
}
