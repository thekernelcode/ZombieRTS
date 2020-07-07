using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClickableObject_TEST : MonoBehaviour
{
    public NodeManager.ResourceTypes heldResourceType;      //---I THINK THIS IS DEFAULTING TO WOOD AS ITS FIRST IN ENUM

    private PlayerTestMove playerTestMovement;

    public bool isGathering = false;

    public int heldResource;                                //---THIS IS JUST THE QUANTITY OF 'x' RESOURCE.  IT IS UNAWARE OF RESOURCE TYPE...DOES THIS MEAN
    public int maxHeldResource;                             //---CURRENTLY WE CAN ONLY HOLD ONE TYPE OF RESOURCE?...ENUM MAY NEED TO BE DICTIONARY TO HAVE MULTIPLE RESOURCES CARRIED

    public Transform dropOffPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GatherTick());
        playerTestMovement = FindObjectOfType<PlayerTestMove>();
    }

    // Update is called once per frame
    void Update()
    {

        /*-------MOVEMENT-------*/

        if (heldResource >= maxHeldResource)
        {
            playerTestMovement.target = dropOffPoint;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Ground")
                {
                    Debug.Log("Moving to: " + hit.transform.gameObject.name);
                    playerTestMovement.target = hit.transform;
                }
                else if (hit.collider.tag == "Resource")
                {
                    playerTestMovement.target = hit.collider.gameObject.transform;
                    Debug.Log("Harvesting");

                }
            }
           
        }
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("Something entered me!!!");
        GameObject hitObject = otherCollider.gameObject;

        if (hitObject.tag == "Resource")
        {
            Debug.Log(hitObject.name);
            hitObject.GetComponent<NodeManager>().numberOfGatherers++;
            heldResourceType = hitObject.GetComponent<NodeManager>().resourceType;
            isGathering = true;
        }

      
    }

    public void OnTriggerExit(Collider otherCollider)
    {
        GameObject hitObject = otherCollider.gameObject;

        if (hitObject.tag == "Resource")
        {
            hitObject.GetComponent<NodeManager>().numberOfGatherers--;
            isGathering = false;
        }

    }

    IEnumerator GatherTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (isGathering)
            {
                heldResource++;
            }
            // TODO - change held resource to be resource dependent.  Right now keeps ticking up regardless of resource type.  Multiple ints - resource dependent.
        }
    }
}
