using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<SlotUI> slotsUI = new List<SlotUI>();

    public void open(List<Inventory.Slot> slots)
    {
        Setup(slots);
        inventoryPanel.SetActive(true);
    }

    public void close()
    {
        inventoryPanel.SetActive(false);
    }

    void Setup(List<Inventory.Slot> slots)
    {
        for(int i = 0; i < slotsUI.Count; i++)
        {
            if(slots[i].type != CollectableType.NONE)
                slotsUI[i].setItem(slots[i]);
            else
                slotsUI[i].setEmpty();
        }
    }

    void Close()
    {
        slotsUI.Clear();
    }
}
