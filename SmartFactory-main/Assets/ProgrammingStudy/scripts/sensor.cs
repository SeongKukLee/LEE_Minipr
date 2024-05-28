using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    public bool isObjectDetected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            isObjectDetected = true;

            if (GetComponent<MeshRenderer>() != null && GetComponent<MeshRenderer>().isVisible)
            {
                GetComponent<MeshRenderer>().material.color = Color.green;
            }

            if (this.gameObject.layer == LayerMask.NameToLayer("Destination"))
            {
                print(this.gameObject.name);
            }
        }
    }
}