using UnityEngine;

public class NormalBulletsPickup : MonoBehaviour
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

        player.GetComponent<PlayerController>().bullet = bullet;
        player.GetComponent<PlayerController>().ammo = 10;
        player.GetComponent<PlayerController>().fireRate = 1f;

    }
}
