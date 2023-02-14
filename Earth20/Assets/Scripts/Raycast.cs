using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Vector3 origin;
    float maxDistance;
    RaycastHit hit;
    public GameObject cameraPos;
    public LayerMask rayCsatHitAble;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
           
           
            origin = cameraPos.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(origin, cameraPos.transform.forward, out hit, maxDistance, rayCsatHitAble))
            {
                hit.transform.GetComponent<MeshRenderer>().material.color = Color.green;

            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Cursor.visible = !Cursor.visible;
        }
    }
}

