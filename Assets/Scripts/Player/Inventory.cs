using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;
    

    public bool Add (Item item)
    {
        if (!item.isDefault)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space!");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }

        }

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }
     
}
