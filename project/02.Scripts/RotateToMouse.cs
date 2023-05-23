using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5f; // ī�޶� x�� ȸ���ӵ�
    [SerializeField]
    private float rotCamYAxisSpeed = 3; // ī�޶� y�� ȸ�� �ӵ�

    private float limitMinX = -80; // ī�޶� x�� ȸ�� ���� (�ּ�)
    private float limitMaxX = 50; // ī�޶� X �� ȸ�� ���� (�ִ�)
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed; // ���콺 ��/�� �̵����� ī�޶� y�� ȸ��
        eulerAngleX -= mouseY * rotCamXAxisSpeed;

        // ī�޶� x�� ȸ���� ��� ȸ�� ������ ����
        eulerAngleX = ClampAngle(eulerAngleX, limitMaxX, limitMinX);

        transform.rotation = Quaternion.Euler(eulerAngleX,eulerAngleY,0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
