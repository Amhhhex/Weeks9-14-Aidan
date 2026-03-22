using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{


    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1;

    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;
        StartCoroutine(GrowTree());
    }


    
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        StartCoroutine(GrowTree());
    }

    IEnumerator GrowTree()
    {
        float t = 0;

        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        while(t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }

        yield return new WaitForSeconds(appleDelay);

        t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }

    }

}
