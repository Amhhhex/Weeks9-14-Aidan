//WEEK THIRTEEN
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiPlayer : MonoBehaviour
{
    public Vector2 moveDirection;
    public float moveSpeed;

    public LocalMultiPlayerManager managerScript;

    public float animationTimer;

    public AnimationCurve aniCurve;

    public PlayerInput attackedPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerInput playerInput = GetComponent<PlayerInput>();
            attackedPlayer = managerScript.TryAttack(playerInput);

            if (attackedPlayer != null)
            {
                StartCoroutine(bonk(attackedPlayer.gameObject));
            }


        }
    }

    private IEnumerator bonk(GameObject player)
    {
        float currentTransform = player.transform.localScale.y;


        float timer = 0f;
        while(timer < animationTimer)
        {

            currentTransform -= 0.01f;

            if(currentTransform < 0.5f) {
                currentTransform = 0.5f;
            }

            player.transform.localScale = new Vector3(transform.localScale.x, currentTransform, transform.localScale.z);
            yield return null;
        }
        


        
    }



}
