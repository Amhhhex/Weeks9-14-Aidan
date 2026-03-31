using UnityEngine;

public class KnightFootsteps : MonoBehaviour
{

    public AudioSource sfx1;
    public AudioSource sfx2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footsteps()
    {
        int randomNumber = Random.Range(0, 2);
        Debug.Log(randomNumber);

        if(randomNumber == 0 )
        {
            Debug.Log("Sound 1");
            sfx1.Play();
        }
        if(randomNumber == 1 ) 
        {
            Debug.Log("Sound 2");
            sfx2.Play();
        }

        Debug.Log("Step");
    }
}
