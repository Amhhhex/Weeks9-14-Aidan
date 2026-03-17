using UnityEngine;
using UnityEngine.InputSystem;

public class TrianglePoint : MonoBehaviour
{
    public Vector2 newLookPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = newLookPosition;
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            newLookPosition = Camera.main.ScreenToWorldPoint(context.action.ReadValue<Vector2>());
        }
    }
}
