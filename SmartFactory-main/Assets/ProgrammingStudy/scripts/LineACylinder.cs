using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineACylinder : MonoBehaviour
{
    public string plcDeviceForwardAddress;
    public string plcDeviceBackwardAddress;
    // Y0
    public int plcForwardValue;            // 0 or 1 plcValue가 1일때 StartCoRoutine 
    public int plcBackwardValue;            // 0 or 1 plcValue가 1일때 StartCoRoutine 
    public Transform cylinderRod;   //실린더 자체의 위치가 아닌 실린더로드의 위치를 바꿔주기 위함.
    public float maxRange;
    public float minRange;
    public float time;
    public float currentTime;
    bool isCylinderMoving = false;

    private void Update()
    {
        if (plcForwardValue == 1 && isCylinderMoving == false)
            StartCoroutine(CoMoveCylinder(minRange, maxRange, time));
        if (plcBackwardValue == 1 && isCylinderMoving == false)
            StartCoroutine(CoMoveCylinder(maxRange, minRange, time));
    }

    //minRange에서 maxRange로 이동하는 함수 
    IEnumerator CoMoveCylinder(float minRange, float maxRange, float time)
    {
        isCylinderMoving = true;
        Vector3 originPos = new Vector3(cylinderRod.localPosition.x, minRange, cylinderRod.localPosition.z); //현재 위치 받아옴
        Vector3 targetPos = new Vector3(cylinderRod.localPosition.x, maxRange, cylinderRod.localPosition.z); //최종 위치 받아옴

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

            cylinderRod.localPosition = newPos;

            yield return new WaitForEndOfFrame();
        }
        isCylinderMoving = false;

    }

    public void OnForwardBtnClkEvent()
    {
        StartCoroutine(CoMoveCylinder(minRange, maxRange, time));
    }

    public void OnBackwardBtnClkEvent()
    {
        StartCoroutine(CoMoveCylinder(maxRange, minRange, time));
    }


}