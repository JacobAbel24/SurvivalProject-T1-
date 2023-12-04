using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] 
    private Image icon;
    private itemSO item;
    [SerializeField] 
    private TMP_Text tmptext;

    public void AddItemToUI(itemSO _item, int _amount)
    {
        item = _item;
        tmptext.text = _amount.ToString();
        if (icon != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            if(tmptext.text != null && tmptext.text != "1")
            {
                tmptext.enabled = true;
            }
        }
    }

    public void ClearItemFromUI()
    {
        item = null;

        if (icon != null)
        {
            icon.sprite = null;
            icon.enabled = false;
            tmptext.enabled = false;
        }
    }
}
