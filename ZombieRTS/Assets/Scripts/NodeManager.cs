using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    public enum ResourceTypes { Wood, Stone, Clay }     // Declare Enum
        
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
