using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionArea : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        print("Enter Collision:" +  collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        print("Collision Stay:"+ collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Collision Exit:" + collision.gameObject.name);
    }
}
