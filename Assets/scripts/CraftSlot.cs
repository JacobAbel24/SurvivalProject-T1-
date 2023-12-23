using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftSlot : MonoBehaviour
{
    public Image image;
    private ItemSO item;
    public TMP_Text tmptext;

    public void AddItemToCraftUI(ItemSO _item, int _amount)
    {
        item = _item;
        tmptext.text = _amount.ToString();
        if (image != null)
        {
            image.sprite = item.icon;
            image.enabled = true;
            image.raycastTarget = true;
            if (tmptext.text != null)
            {
                tmptext.enabled = true;
            }
        }
    }

    public void ClearItemFromCraftUI()
    {
        item = null;

        if (image != null)
        {
            image.sprite = null;
            image.enabled = false;
            image.raycastTarget = false;
            tmptext.enabled = false;
        }
    }
}
