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
    public GameObject rangeOb; //빈 오브젝트(Position), 하위 오브젝트받기

    private void OnMouseDown() // 마우스로 클릭했을때 실행됨, 콜라이더 없으면 안됨
    {
        Dist = Vector3.Distance(handkercheif.transform.position, Player.transform.position);
        Vector2 originpo = rangeOb.transform.position; //지금 빈 오브젝트의 위치값 가져오기
        int pota = Random.Range(1, 10); //1부터 10까지 랜덤값
        
        //Debug.Log(Dist);
        if (Dist < 10)
        {
            Debug.Log("클릭된 오브젝트 : " + gameObject.name);
            FieldItems fieldItems = gameObject.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem())) {
               // fieldItems.DestroyItem();
                Debug.Log("야호");
            }
       
        }

    }


}
