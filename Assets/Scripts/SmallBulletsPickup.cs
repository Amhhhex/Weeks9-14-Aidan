using UnityEngine;

public class SmallBulletsPickup : MonoBehaviour
{
    public GameObject player;

    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        //PlayerController playerController = player.GetComponent<PlayerController>();

        //playerController.ammo = 20;
        //playerController.fireRate = 0.3f;
        //playerController.bullet = bullet;

        player.GetComponent<PlayerController>().bullet = bullet;
        player.GetComponent <PlayerController>().ammo = 20;
        player.GetComponent<PlayerController>().fireRate = 0.3f;
            
    }


}
