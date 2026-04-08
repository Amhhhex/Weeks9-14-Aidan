using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Transform bulletSpawnPoint;

    public Vector2 directionalInput;

    public GameObject bullet;

    public GameObject spawnedBullet;

    public int ammo;

    public float fireRate;

    public List<GameObject> firedBullets;

    private Coroutine currentCoroutine;

    public GameObject normalBulletSprite;
    public GameObject bigBulletSprite;
    public GameObject smallBulletSprite;

    public GameObject normalBullets;
    public GameObject bigBullets;
    public GameObject smallBullets;



    public SpriteRenderer playerSprite;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerSprite = GetComponent<SpriteRenderer>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)directionalInput * speed * Time.deltaTime;

        if(playerSprite.bounds.Contains(normalBulletSprite.transform.position)) {

            bullet = normalBullets;
            ammo = 10;
            fireRate = 1;

        }

        if(playerSprite.bounds.Contains(bigBulletSprite.transform.position))
        {
          
            bullet = bigBullets;
            ammo = 5;
            fireRate = 3;
        }

        if(playerSprite.bounds.Contains(smallBulletSprite.transform.position))
        {
            
            bullet = smallBullets;
            ammo = 20;
            fireRate = 0.3f;
        }

        if (firedBullets != null)
        {
            for (int i = 0; i < firedBullets.Count; i++)
            {
                GameObject currentBullet = firedBullets[i];
                Vector2 bulletPosition = Camera.main.WorldToScreenPoint(currentBullet.transform.position);

                if (bulletPosition.x > 1920)
                {
                    firedBullets.Remove(currentBullet);
                    Destroy(currentBullet);
                }
            }
        }
        

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        
        directionalInput = context.ReadValue<Vector2>();
        
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(shootingUpdate());
            }
        }

    }

    private IEnumerator shootingUpdate()
    {

        while(ammo > 0)
        {
            firedBullets.Add(Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity));
            ammo--;
            yield return new WaitForSeconds(fireRate);
        }

        if(ammo == 0 && currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
            yield return null;
        }


    }
}
