using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f) && Input.GetKeyDown("f"))
        {
            if(hit.transform.gameObject.tag == "intractable")
            {
                hit.transform.gameObject.GetComponent<interactable>().Interact();
            }
        }
    }
}
