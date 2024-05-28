using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamSensor : MonoBehaviour
{
    public string plcAddress;
    public int plcValue;
    public bool isArrived = false;
    public Transform Icecream;
    public MeshRenderer led;
    Vector3 originPos;
    public bool isEndSensor = false;

    void Start()
    {
        originPos = Icecream.position;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<MeshRenderer>() != null && GetComponent<MeshRenderer>().isVisible)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (other.gameObject.name.Contains("Icecream"))
        {
            IceMxComponent.instance.SetDevice(plcAddress, 1);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Icecream"))
        {
            
            if (isEndSensor)
            {
                led.material.color = Color.white;
                IceMxComponent.instance.SetDevice(plcAddress, 1);
                //Sensor B
                /*other.transform.position = originPos;
                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                return;*/
            }

            
        }
    }
}