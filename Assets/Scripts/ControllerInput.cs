using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed;

    public Vector2 directionalInput;





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
        

        Debug.Log("Attack Time("+ context.phase +")");

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();

        transform.up = look;

        Debug.Log("On Look " + context.ReadValue<Vector2>());

    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {

        }

        Vector2 mousePosition = context.ReadValue<Vector2>();

        Vector2 worldToMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        Debug.Log("OnPoint " + worldToMousePosition);

    }


}
