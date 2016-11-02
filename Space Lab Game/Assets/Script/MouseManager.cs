using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // public Camera theCamera = Camera.main;
    public Camera theCamera;
    public GameObject prefabToSpawn;
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

                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("SnapPoint"))
                {// Now let's spawn new object
                    spawnSpot = hitInfo.collider.transform.position;
                    Quaternion spawnRotation = hitInfo.collider.transform.rotation;

                    GameObject go = (GameObject)Instantiate(prefabToSpawn, spawnSpot, spawnRotation);
                    //attach the new object to other object which get hit
                    go.transform.SetParent(hitInfo.collider.transform);
                }
            }
        }
    }
}