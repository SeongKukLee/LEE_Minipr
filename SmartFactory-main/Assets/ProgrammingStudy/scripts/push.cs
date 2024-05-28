using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public float speed = 3;
    public float resetTime = 5; // 원래 위치로 돌아가기까지의 시간
    public float currentTime = 0;
    public GameObject pushObj;
    Vector3 pushObjOriginPos;

    public void Start()
    {

    }
    public void TurnOnConveyor()
    {
        pushObjOriginPos = pushObj.transform.localPosition;
        pushObj.SetActive(true);

        StartCoroutine(CoMovePushObject());
    }

    IEnumerator CoMovePushObject()
    {
        while (true)
        {
            currentTime += Time.deltaTime;

            if (currentTime > resetTime)
            {
                currentTime = 0;
                pushObj.transform.localPosition = pushObjOriginPos;
                break;
            }

            pushObj.transform.position += (-transform.forward) * Time.deltaTime * speed;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}