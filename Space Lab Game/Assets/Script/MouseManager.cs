using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour
{
    // public Camera theCamera = Camera.main;
    public Camera theCamera;
    public GameObject prefabToSpawn;
    void Start()
    {

    }

    void Update()
    {
        //was the mouse pressed down this frame? 
        if (Input.GetMouseButtonDown(0))
        {            //Yes, the left mouse button
                     //              //Is the mouse over a cube

            //Ray ray = new Ray(theCamera.transform.position, theCamera.transform.forward);
            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("We hit: " + hitInfo.collider.gameObject.name);
                // Now let's spawn new object
                if (hitInfo.collider.gameObject.tag == "box")
                {
                    Vector3 spawnSpot = hitInfo.point;
                    Instantiate(prefabToSpawn, spawnSpot, Quaternion.identity);
                }

            }
        }
    }
}