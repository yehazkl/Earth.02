using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheCamera : MonoBehaviour
{
    Animator anime;
   public ParticleSystem PS;
    public AudioSource audiosource;
    public AudioClip FireM4;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anime.SetBool("Reload", true);
           
        }
        else
        {
            anime.SetBool("Reload", false);
        }

        if (Input.GetMouseButton(0))
        {
            anime.SetBool("Fire", true);
            PS.Play();
         
            
        }
        else
        {
            anime.SetBool("Fire", false);

        }
    }
}
