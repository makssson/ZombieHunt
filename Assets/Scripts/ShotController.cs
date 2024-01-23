using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private PlayerInput playerInput;
    private AudioSource shootingSound;
    private ParticleSystem shootSmoke;
  
  
    public float bulletSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        shootingSound = GetComponent<AudioSource>();
        shootSmoke = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletShot();
    }

    void BulletShot()
    {
        if (playerInput.actions.FindAction("Shoot").WasPressedThisFrame())
        {
            shootingSound.Play();
            shootSmoke.Play();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            
        }
    }
}
