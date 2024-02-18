using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shooting : MonoBehaviour
{
    public AudioClip gunshot;
    public float cooldown = 0.05f;
    public GameObject bulletHole;
    public GameObject muzzleFlash;

    private float lastShot;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > lastShot + cooldown)
        {
            lastShot = Time.time;

            audioSource.PlayOneShot(gunshot);

            muzzleFlash.SetActive(true);
            Invoke(nameof(TurnOffMuzzleFlash), 0.03f);

            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.GetComponent("Enemy"))
                {
                    hit.transform.GetComponent<Enemy>().Die();

                }
                else 
                {
                    Instantiate(bulletHole, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal)); ;
                }
            }
        
        
        }
        
        
    }

    void TurnOffMuzzleFlash()
    { 
        muzzleFlash.SetActive(false);
    
    }
}
