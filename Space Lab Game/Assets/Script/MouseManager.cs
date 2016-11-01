using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // public Camera theCamera = Camera.main;
    public Camera theCamera;
    public GameObject prefabToSpawn;
    private float boxOffsetScale = 2.2f;
    private Vector3 spawnSpot;
    void Update()
    {//was the mouse pressed down this frame?
        if (Input.GetMouseButtonDown(0))
        { //Yes, the left mouse button  //Is the mouse over a cube
            //Ray ray = new Ray(theCamera.transform.position, theCamera.transform.forward);
            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("We hit: " + hitInfo.collider.gameObject.name);
                // Now let's spawn new object
                if (prefabToSpawn.tag == "box") //then add the box offset
                    spawnSpot = hitInfo.collider.transform.position + (hitInfo.normal * boxOffsetScale);
                else
                    spawnSpot = hitInfo.collider.transform.position + hitInfo.normal;

                Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);

                Instantiate(prefabToSpawn, spawnSpot, spawnRotation);
            }
        }
    }
}