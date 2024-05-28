using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class grabcylinder : MonoBehaviour
{
    public string plcDeviceGrabAddress;
    public int plcGrabValue;
    public Transform grab1;
    public Transform grab2;
    public float maxRange1;
    public float maxRange2;
    public float minRange1;
    public float minRange2;
    public float time;
    public float currentTime;
    public float currentTime1;
    bool isgrabmoving = false;

    private void Update()
    {
        if (plcGrabValue == 1 && isgrabmoving == false)
        {
            StartCoroutine(CoMoveGrab1(maxRange1, minRange1, time));
            StartCoroutine(CoMoveGrab2(maxRange2, minRange2, time));
        }
    }
    IEnumerator CoMoveGrab1(float minRange1, float maxRange1, float time)
    {
        isgrabmoving = true;
        Vector3 originPos = new Vector3(grab1.localPosition.x, minRange1, grab1.localPosition.z); //현재 위치 받아옴
        Vector3 targetPos = new Vector3(grab1.localPosition.x, maxRange1, grab1.localPosition.z); //최종 위치 받아옴
        
        

        // time동안 pistonRod를 originPos에서 targetPos로 이동
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > time) // 현재 시간이 내가 지정한 time 보다 커질때 
            {
                currentTime = 0; // 현재 시간 초기화
                break;
            }
            Vector3 newPos = Vector3.Lerp(originPos, targetPos, currentTime / time); //newPos에 originPos에서 targetPos로 time 동안 이동하는 값 저장.  


            grab1.localPosition = newPos;

            yield return new WaitForEndOfFrame();
        }
        isgrabmoving = false;

    }
    IEnumerator CoMoveGrab2(float minRange2, float maxRange2, float time)
    {
        isgrabmoving = true;
        Vector3 originPos = new Vector3(grab2.localPosition.x, minRange2, grab2.localPosition.z); //현재 위치 받아옴
        Vector3 targetPos = new Vector3(grab2.localPosition.x, maxRange2, grab2.localPosition.z); //최종 위치 받아옴

        // time동안 pistonRod를 originPos에서 targetPos로 이동
        while (true)
        {
            currentTime1 += Time.deltaTime;
            if (currentTime1 > time) // 현재 시간이 내가 지정한 time 보다 커질때 
            {
                currentTime1 = 0; // 현재 시간 초기화
                break;
            }
            Vector3 newPos = Vector3.Lerp(originPos, targetPos, currentTime1 / time); //newPos에 originPos에서 targetPos로 time 동안 이동하는 값 저장.  

            grab2.localPosition = newPos;

            yield return new WaitForEndOfFrame();
        }
        isgrabmoving = false;

    }

    public void OnGrabBtnClkEvent()
    {
        StartCoroutine(CoMoveGrab1(maxRange1, minRange1, time));
        StartCoroutine(CoMoveGrab2(maxRange2, minRange2, time));
    }
}
