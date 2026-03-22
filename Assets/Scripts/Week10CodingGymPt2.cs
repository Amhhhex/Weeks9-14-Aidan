using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Week10CodingGymPt2 : MonoBehaviour
{


    public float duration;
    public AnimationCurve curve;

    public Button moveButton;
    public TMP_InputField xInput;
    public TMP_InputField yInput;

    public Vector2 destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        


    }

    private IEnumerator MoveCar(Vector2 position)
    {
        float progress = 0f;

        while(progress < duration)
        {
            transform.up = position;
            progress += Time.deltaTime;

            transform.position = Vector2.Lerp(new Vector2(0f, 0f), position, curve.Evaluate(progress / duration));

            yield return null;
        }


        
    }

    public void OnButtonPress()
    {

        float xValue = float.Parse(xInput.text);
        float yValue = float.Parse(yInput.text);

        destination.x = xValue;
        destination.y = yValue;


        StartCoroutine(MoveCar(destination));
    }
}
