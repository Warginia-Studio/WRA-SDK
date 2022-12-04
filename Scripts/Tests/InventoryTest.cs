using System.Collections;
using System.Collections.Generic;
using Inventory;
using UIExtension.UI;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] private Item[] items;

    private int id;

    private Inventory.Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory.Inventory>();
        FindObjectOfType<ContainerWindowIniter>().OpenContainer(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            id--;
            if (id < 0)
            {
                id = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            id++;
            if (id >= items.Length)
            {
                id = items.Length-1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inventory.TryAddItem(items[id]))
            {
                Debug.LogError("Added item.");
            }
        }
        
    }
}
