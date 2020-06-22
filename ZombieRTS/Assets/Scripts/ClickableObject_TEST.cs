using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject_TEST : MonoBehaviour
{

    private PlayerTestMove playerTestMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerTestMovement = FindObjectOfType<PlayerTestMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("Moving to: " + hit.transform.gameObject.name);
                playerTestMovement.target = hit.transform;
            }
        }
    }

}
