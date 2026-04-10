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

    public float dashTimer;

    public AnimationCurve aniCurve;

    public PlayerInput attackedPlayer;

    public Coroutine currentCoroutine;
    public Coroutine dashCoroutine;

    TrailRenderer playerTrail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTrail = GetComponent<TrailRenderer>();
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
                currentCoroutine = StartCoroutine(bonk(attackedPlayer.gameObject));
            }


        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            StartCoroutine(Dash());

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
            timer += Time.deltaTime;
            yield return null;
        }
        


        
    }

    private IEnumerator Dash()
    {
        float timer = 0f;
        playerTrail.emitting = true;

        while(timer < dashTimer)
        {
            moveSpeed = 5f;
            yield return null;
            timer += Time.deltaTime;
        }

        playerTrail.emitting = false;
        moveSpeed = 3f;




        yield return null;
    }



}
