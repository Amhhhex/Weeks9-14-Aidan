using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class Week10CodingGym : MonoBehaviour
{

    public GameObject spawnObject;
    private GameObject spawnedObject;
    public AnimationCurve curve;

    public SpriteRenderer[] components;

    public Coroutine currentRoutine;

    public float duration;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            StartCoroutine(BuildingGrow());

        }

    }


    private IEnumerator BuildingGrow()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        spawnedObject = Instantiate(spawnObject, mousePosition, Quaternion.identity);


        components = spawnedObject.GetComponentsInChildren<SpriteRenderer>();

        currentRoutine = StartCoroutine(GrowSprite(components[0]));
        yield return currentRoutine;

        currentRoutine = StartCoroutine(GrowSprite(components[1]));
        yield return currentRoutine;

        currentRoutine = StartCoroutine(GrowSprite(components[2]));
        


        yield return null;
    }

    private IEnumerator GrowSprite(SpriteRenderer sprite)
    {
        float progress = 0f;

        while (progress < duration)
        {
            progress += Time.deltaTime;
            sprite.transform.localScale = curve.Evaluate(progress / duration) * Vector2.one;

            yield return null;
        }
    }

   
}
