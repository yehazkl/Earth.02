using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheCamera : MonoBehaviour
{
    Animator anime;
   
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
            
        }
        else
        {
            anime.SetBool("Fire", false);

        }
    }
}
