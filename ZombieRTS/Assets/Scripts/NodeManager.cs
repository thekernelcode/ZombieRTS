using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    public enum ResourceTypes { Wood, Stone, Clay }     // Declare Enum  TODO - THIS PROBABLY NEEDS TO BE SET OUT INTO A 'RESOURCE CLASS'
                                                        // CLASS COULD HAVE THINGS LIKE, AMOUNT AVAILABLE, TIME TO HARVEST, HARDNESS SO ONLY SOME TOOLS CAN USE
                                                        // UNLOCK STAGE DEPENDING ON TECH LEVEL
        
    public ResourceTypes resourceType;                  // Declare one of the enums

    public float timeToHarvest;
    public float availableResource;

    public int numberOfGatherers = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ResourceTick());  // Used to run IEnumerators;
    }

    // Update is called once per frame
    void Update()
    {
        if (availableResource < 0)
        {
            Destroy(gameObject);
        }
    }

    public void ResourceGather()
    {
        if (numberOfGatherers != 0)
        {
            availableResource -= numberOfGatherers;
        }
    }

    IEnumerator ResourceTick()
    {
        while (true)  // While IEnumerator is running
        {
            yield return new WaitForSeconds(timeToHarvest);
            ResourceGather();

        }
    }

}
