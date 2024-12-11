using UnityEngine;
using Vehicles;

namespace Managers
{
    public class VehicleManager : MonoBehaviour
    {
        // Reference to the HorseWithCart prefab
        public GameObject horseWithCartPrefab;

        // Method to register the HorseWithCart vehicle type
        public void RegisterHorseWithCart()
        {
            // Logic to register the vehicle type
            Debug.Log("Horse with Cart registered as a vehicle type.");
        }

        // Method to instantiate the HorseWithCart
        public GameObject SpawnHorseWithCart(Vector3 position, Quaternion rotation)
        {
            if (horseWithCartPrefab == null)
            {
                Debug.LogError("HorseWithCart prefab is not assigned.");
                return null;
            }

            GameObject horseWithCartInstance = Instantiate(horseWithCartPrefab, position, rotation);
            Debug.Log("Horse with Cart spawned in the game world.");
            return horseWithCartInstance;
        }

        // Method to manage the lifecycle of the HorseWithCart
        public void ManageHorseWithCart(GameObject horseWithCart)
        {
            if (horseWithCart == null)
            {
                Debug.LogError("HorseWithCart instance is null.");
                return;
            }

            // Example of lifecycle management: enabling/disabling components
            horseWithCart.SetActive(true);
            Debug.Log("Horse with Cart is now active and controllable by the player.");
        }

        // Example of player control logic
        public void ControlHorseWithCart(GameObject horseWithCart, Vector3 direction)
        {
            if (horseWithCart == null)
            {
                Debug.LogError("HorseWithCart instance is null.");
                return;
            }

            HorseWithCart horseComponent = horseWithCart.GetComponent<HorseWithCart>();
            if (horseComponent != null)
            {
                horseComponent.Move(direction);
                Debug.Log("Controlling Horse with Cart.");
            }
            else
            {
                Debug.LogError("HorseWithCart component not found on the instance.");
            }
        }
    }
}
