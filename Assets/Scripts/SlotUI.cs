using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image sprite;
    public TextMeshProUGUI amount;

    public void setItem(Inventory.Slot slot)
    {
        if(slot != null)
        {
            sprite.sprite = slot.sprite;
            sprite.color = new Color(1, 1, 1, 1);
            amount.text = slot.count.ToString();
        }
    }

    public void setEmpty()
    {
        sprite.sprite = null;
        sprite.color = new Color(1, 1, 1, 0);
        amount.text = "";
    }
}
