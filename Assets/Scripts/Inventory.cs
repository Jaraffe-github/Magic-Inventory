using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private Slot itemSlot;

    [SerializeField]
    private List<Item> itemDatas;

    private List<Slot> itemSlots = new List<Slot>();

    private void OnValidate()
    {
        //slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        foreach (var item in itemDatas)
        {
            Slot newSlot = Instantiate(itemSlot, slotParent);
            newSlot.item = item;
            itemSlots.Add(newSlot);
        }

        FreshSlot();
    }

    public void FreshSlot()
    {
        //int i = 0;
        //for (; i < items.Count && i < slots.Length; ++i)
        //{
        //    slots[i].item = items[i];
        //}
        //for (; i < slots.Length; ++i)
        //{
        //    slots[i].item = null;
        //}
    }

    public void AddItem(Item _item)
    {
        //if (items.Count < slots.Length)
        //{
        //    items.Add(_item);
        //    FreshSlot();
        //}
        //else
        //{
        //    print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        //}
    }
}
