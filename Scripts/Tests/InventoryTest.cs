using DependentObjects.ScriptableObjects;
using DependentObjects.ScriptableObjects.Managment;
using Managment;
using UIExtension.Controls.Containers;
using UnityEngine;

namespace Tests
{
    public class InventoryTest : MonoBehaviour
    {
        [SerializeField] private Inventory inventory1;
        [SerializeField] private Armament inventory2;
    
        [SerializeField] private ContainerItem[] items;

        private int id;
    
        void Start()
        {
            // FindObjectOfType<AdvancedContainerWindowIniter>().InitContainer(inventory1, inventory2);
            // FindObjectOfType<ContainerWindowIniter>().OpenContainer(inventory);
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
                // if (inventory1.TryAddItem(items[id]))
                // {
                //     Debug.LogError("Added item.");
                // }
            }
        
        }
    }
}
