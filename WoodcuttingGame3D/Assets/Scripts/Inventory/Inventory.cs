using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public int space = 20;

    public List<Item> items = new List<Item>();


    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Inventory is full.");
            return false;
        }
        items.Add(item);
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    public int CheckInventorySize()
    {
        int inventorySize = items.Count;
        return inventorySize;
    }

    public void RemoveAll(List<Item> itemList)
    {
        itemList = items;
        for(int i = 0; i < itemList.Count; i++)
        {
            itemList.Remove(itemList[i]);
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
