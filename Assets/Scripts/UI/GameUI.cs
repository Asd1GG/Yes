using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        // UI Elements
        public Button mountButton;
        public Button dismountButton;
        public Button manageInventoryButton;
        public Text inventoryStatusText;

        // Reference to the VehicleManager
        private Managers.VehicleManager vehicleManager;
        private GameObject currentHorseWithCart;

        void Start()
        {
            // Initialize the VehicleManager reference
            vehicleManager = FindObjectOfType<Managers.VehicleManager>();

            // Set up button listeners
            mountButton.onClick.AddListener(OnMountButtonClicked);
            dismountButton.onClick.AddListener(OnDismountButtonClicked);
            manageInventoryButton.onClick.AddListener(OnManageInventoryButtonClicked);

            // Initialize UI state
            UpdateUIState(false);
        }

        // Method to handle mounting the horse with cart
        private void OnMountButtonClicked()
        {
            if (currentHorseWithCart == null)
            {
                currentHorseWithCart = vehicleManager.SpawnHorseWithCart(Vector3.zero, Quaternion.identity);
                UpdateUIState(true);
            }
        }

        // Method to handle dismounting the horse with cart
        private void OnDismountButtonClicked()
        {
            if (currentHorseWithCart != null)
            {
                Destroy(currentHorseWithCart);
                currentHorseWithCart = null;
                UpdateUIState(false);
            }
        }

        // Method to handle managing the cart's inventory
        private void OnManageInventoryButtonClicked()
        {
            if (currentHorseWithCart != null)
            {
                Vehicles.HorseWithCart horseComponent = currentHorseWithCart.GetComponent<Vehicles.HorseWithCart>();
                if (horseComponent != null)
                {
                    // Example inventory management logic
                    bool itemLoaded = horseComponent.LoadItem("Sample Item");
                    inventoryStatusText.text = itemLoaded ? "Item loaded successfully." : "Failed to load item.";
                }
            }
        }

        // Method to update the UI state based on interaction
        private void UpdateUIState(bool isMounted)
        {
            mountButton.interactable = !isMounted;
            dismountButton.interactable = isMounted;
            manageInventoryButton.interactable = isMounted;
            inventoryStatusText.text = isMounted ? "Manage your inventory." : "Mount the horse to manage inventory.";
        }
    }
}
