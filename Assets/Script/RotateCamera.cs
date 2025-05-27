using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5; //카메라 x축 회전속도
    [SerializeField]
    private float rotCamYAxisSpeed = 5; //카메라 y축 회전속도

    private float limitMinX = -80;  //카메라 x축 회전 범위(최소)
    private float limitMaxX = 50;   //카메라 x축 회전 범위(최대)
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float X, float Y)
    {
        eulerAngleY += X * rotCamXAxisSpeed;    //좌/우 이동으로 카메라 y축 회전
        eulerAngleX -= Y * rotCamYAxisSpeed;    //위/아래 이동으로 카메라 x축 회전

        // 카메라 x축 회전의 경우 회전 범위를 설정
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        // 캐릭터 전체 회전(좌우 Y축만 적용)
        transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);

        // 카메라 위아래 (pitch)

    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
