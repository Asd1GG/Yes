using UnityEngine;
using System.Collections.Generic;

namespace Vehicles
{
    public class HorseWithCart : MonoBehaviour
    {
        // Properties
        public float Speed { get; private set; }
        public int Capacity { get; private set; }
        private List<string> items;

        // Constructor
        public HorseWithCart(float speed, int capacity)
        {
            Speed = speed;
            Capacity = capacity;
            items = new List<string>();
        }

        // Method to move the horse with cart
        public void Move(Vector3 direction)
        {
            // Implement movement logic here
            transform.Translate(direction * Speed * Time.deltaTime);
        }

        // Method to load an item onto the cart
        public bool LoadItem(string item)
        {
            if (items.Count < Capacity)
            {
                items.Add(item);
                return true;
            }
            else
            {
                Debug.Log("Cart is full, cannot load more items.");
                return false;
            }
        }

        // Method to unload an item from the cart
        public bool UnloadItem(string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                return true;
            }
            else
            {
                Debug.Log("Item not found in the cart.");
                return false;
            }
        }

        // Unique behavior: Example of a unique interaction
        public void Neigh()
        {
            Debug.Log("The horse neighs!");
        }
    }
}
