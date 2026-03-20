using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TreeGrower : MonoBehaviour
{
    public AnimationCurve growCurve;
    public float duration;

    public Transform appleSpawnerTransform;
    public float maxSpawnDistance;

    public GameObject applePreFab;
    public float appleGrowDuration;

    private Coroutine treeCoroutine;
    private Coroutine appleCoroutine;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            



    }

    public void OnGrowPress()
    {

        //StartCoroutine is just like Instantiate(), where upon calling the method it returns a coroutine as a return type
        //if we wanted to stop a specific coroutine we need to store the one we call into a variable
        //so that later in StopCoroutine() we can stop a specific instance of that coroutine
        treeCoroutine = StartCoroutine(TreeGrowUpdate());
        

    }

    private IEnumerator TreeGrowUpdate()
    {
        float progress = 0f;

        //The contents of the while loop run whle the condition is true
        while (progress < duration)
        {
            progress += Time.deltaTime;

            transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;
            //Relinquishes control of Unity so that everything else ca run
            //For the rest of this frame
            //IEnumerators require this to properly run
            yield return null;
        }

        //Relinquish control of Unity until the apple has finished growing
        //yield return new WaitForSeconds(appleGrowDuration); //DELAY -> appleGrowDuration

        appleCoroutine = StartCoroutine(appleGrowUpdate());
        //Relinquish control of Unity until the coroutine for the apple has finished executing
        yield return appleCoroutine;


        appleCoroutine = StartCoroutine(appleGrowUpdate());
        yield return appleCoroutine;

        StartCoroutine(appleGrowUpdate());

    }

    private IEnumerator appleGrowUpdate()
    {
        float progress = 0f;
        Vector2 spawnPosition = appleSpawnerTransform.position;
        spawnPosition += UnityEngine.Random.insideUnitCircle * maxSpawnDistance;


    GameObject spawnedApple = Instantiate(applePreFab, spawnPosition, Quaternion.identity);

        spawnedApple.transform.localScale = Vector3.zero;
        progress = 0f;


        while (progress < appleGrowDuration)
        {

            progress += Time.deltaTime;

            spawnedApple.transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;
            yield return null;
        }
    }

    public void OnStopPress()
    {
        //This null check prevents an error in the code when someone hits the stop button before the coroutine has started
        //To solve this issue, we do a null check on these variables
        if(treeCoroutine != null)
        {
            StopCoroutine(treeCoroutine);


        }
        if(appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);

        }
    }
}