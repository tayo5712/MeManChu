using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Singleton

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }
    private void Start()
    {
        SlotCnt = 4;
    }

    public bool AddItem(Item _item) {

        if (items.Count < SlotCnt) {
            items.Add(_item);
            if (onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    public GameObject handkercheif;
    public GameObject Player;
    private float Dist;
    public GameObject rangeOb; //�� ������Ʈ(Position), ���� ������Ʈ�ޱ�

    private void OnMouseDown() // ���콺�� Ŭ�������� �����, �ݶ��̴� ������ �ȵ�
    {
        Dist = Vector3.Distance(handkercheif.transform.position, Player.transform.position);
        Vector2 originpo = rangeOb.transform.position; //���� �� ������Ʈ�� ��ġ�� ��������
        int pota = Random.Range(1, 10); //1���� 10���� ������
        
        //Debug.Log(Dist);
        if (Dist < 10)
        {
            Debug.Log("Ŭ���� ������Ʈ : " + gameObject.name);
            FieldItems fieldItems = gameObject.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem())) {
               // fieldItems.DestroyItem();
                Debug.Log("��ȣ");
            }
       
        }

    }


}
