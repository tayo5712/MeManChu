using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ʈ���� ������� ����� : ��ũ��Ʈ#2. Ʈ������
// ���� : ������ ������ �� Ʈ���ſ� ������ ��������� ����մϴ�.
//  �÷��̾��� tag �Ӽ��� 'myplayer'�� �����ְų�, �Ʒ��� �ҽ��� ������ �ֽø� �˴ϴ�.
// �ּ��� �������� �ʴ� �������� �����Ӱ� ����ϼŵ� �˴ϴ�.
// ���� : Cray
// ��α� : ũ������ IT Ž�� https://itadventure.tistory.com/415
public class VileageEnter : MonoBehaviour
{
    // Inspector ������ ǥ���� ������� �̸�
    public string bgmName = "";

    private GameObject CamObject;

    void Start()
    {
        CamObject = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "myplayer")
            CamObject.GetComponent<PlayMusicOperator>().PlayBGM(bgmName);
    }
}