using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    itemSO item;


    public void AddItemToUI(itemSO _item)
    {
        item = _item;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearItemFromUI()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
