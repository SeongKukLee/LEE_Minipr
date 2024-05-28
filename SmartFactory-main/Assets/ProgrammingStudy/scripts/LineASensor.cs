using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineASensor : MonoBehaviour
{
    public string plcAddress;
    public int plcValue;
    public bool isArrived = false;
    public Transform box;
    Vector3 originPos;
    Quaternion originRot;
    public bool isEndSensor = false;

    void Start()
    {
        originPos = box.position;
        originRot = box.rotation;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Box"))
        {
            LineAMxComponent.instance.SetDevice(plcAddress, 1);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Box"))
        {
            if (isEndSensor)
            {
                //Sensor B
                other.transform.position = originPos;
                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                return;
            }

            // Sensor A
            LineAMxComponent.instance.SetDevice(plcAddress, 1);
        }
    }
}