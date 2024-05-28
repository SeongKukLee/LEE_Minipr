using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSylinder : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion newQ = Quaternion.Euler(0f, 0f, 30f);
            transform.rotation *= newQ;
            //transform.rotation = Quaternion.Euler(30, 30, 30);
        }
    }
    /*
     * 
     * 
    Vector3 direction = target.postion - transform.postion;
    Quaternion newRotation = Quaternion.LookRotation(direction);
    transform.rotation = newRotation;*/
}
