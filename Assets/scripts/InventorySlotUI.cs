using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    private itemSO item;

    public void AddItemToUI(itemSO _item)
    {
        item = _item;

        if (icon != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
    }

    public void ClearItemFromUI()
    {
        item = null;

        if (icon != null)
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}
