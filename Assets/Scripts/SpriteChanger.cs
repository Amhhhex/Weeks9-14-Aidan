using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{

    public SpriteRenderer sprite;

    public List<SpriteRenderer> renders = new List<SpriteRenderer>();

    int listIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        listIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    public void ChangeSprite()
    {
        if(listIndex >= renders.Count)
        {
            listIndex = 0;
        }

        sprite.sprite = renders[listIndex].sprite;

        listIndex++;

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Phase: " + context);

        if(context.performed)
        {
            Debug.Log("ummm");
            ChangeSprite();
        }
    }
}
