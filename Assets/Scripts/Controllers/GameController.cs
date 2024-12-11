using UnityEngine;
using Vehicles;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        // Reference to the HorseWithCart instance
        private HorseWithCart horseWithCart;

        // Control parameters
        public float acceleration = 5f;
        public float maxSpeed = 10f;
        public float turnRate = 100f;

        // Current speed of the horse with cart
        private float currentSpeed = 0f;

        void Start()
        {
            // Find the HorseWithCart instance in the scene
            horseWithCart = FindObjectOfType<HorseWithCart>();

            if (horseWithCart == null)
            {
                Debug.LogError("HorseWithCart instance not found in the scene.");
            }
        }

        void Update()
        {
            if (horseWithCart != null)
            {
                HandleInput();
            }
        }

        private void HandleInput()
        {
            // Get input for acceleration and braking
            float moveInput = Input.GetAxis("Vertical");
            float turnInput = Input.GetAxis("Horizontal");

            // Calculate speed based on input
            if (moveInput > 0)
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
            else if (moveInput < 0)
            {
                currentSpeed -= acceleration * Time.deltaTime;
            }
            else
            {
                // Gradually slow down if no input
                currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 2);
            }

            // Clamp the speed to the maximum speed
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

            // Calculate turning
            float turn = turnInput * turnRate * Time.deltaTime;

            // Apply movement and turning to the horse with cart
            Vector3 moveDirection = transform.forward * currentSpeed * Time.deltaTime;
            horseWithCart.Move(moveDirection);
            transform.Rotate(0, turn, 0);
        }
    }
}
