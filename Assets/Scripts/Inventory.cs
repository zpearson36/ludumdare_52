using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    [SerializeField] private GameObject ui;
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public Sprite sprite;
        public int count;
        public int maxAllowed;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool canAdd()
        {
            bool canAdd = true;
            if(count == maxAllowed)
                canAdd = false;

            return canAdd;
        }

        public void addItem(Collectable collectable)
        {
            type = collectable.type;
            sprite = collectable.sprite;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    void Start()
    {
        for(int i = 0; i < 28; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void add(Collectable collectable)
    {
        foreach(Slot slot in slots)
        {
            if(slot.type == collectable.type && slot.canAdd())
            {
                slot.addItem(collectable);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.addItem(collectable);
                return;
            }
        }
    }

    public void open()
    {
        ui.GetComponent<InventoryUI>().open(slots);
    }

    public void close()
    {
        ui.GetComponent<InventoryUI>().close();
    }
}
