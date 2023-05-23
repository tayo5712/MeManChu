using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item) {

        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;

    }

    public Item GetItem() {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);

    }


}
