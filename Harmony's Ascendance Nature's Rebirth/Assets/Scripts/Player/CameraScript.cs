using UnityEngine;

namespace Player
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private GameObject cameraObject;
        private Transform cameraPos;
        private Transform playerTransform; // Added playerTransform variable

        [SerializeField] private float rotationSpeed = 3f;
        [SerializeField] private float zoomSpeed = 5f; // Adjust as needed
        [SerializeField] private float minZoom = 20f; // Adjust as needed
        [SerializeField] private float maxZoom = 60f;
        [SerializeField] private float verticalOffset = 2f; // Adjust as needed
        [SerializeField] private LayerMask obstacleLayer;

        private void Start()
        {
            if (cameraObject == null)
            {
                Debug.LogError("Camera Object not assigned to the script.");
                enabled = false;
                return;
            }

            cameraPos = cameraObject.transform;
            playerTransform = transform; // Assuming the script is attached to the player object
        }

        void Update()
        {
            HandleRotationInput();
            HandleZoomInput();

            HandleObstacleVisibility();

            UpdateCameraPosition(); // Added method to update camera position
        }

        private void HandleRotationInput()
        {
            if (Input.GetMouseButton(0)) // Left mouse button to rotate
            {
                float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
                cameraPos.RotateAround(playerTransform.position, Vector3.up, horizontalInput);
            }
        }

        private void HandleZoomInput()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - scrollInput * zoomSpeed, minZoom, maxZoom);
        }

        private void HandleObstacleVisibility()
        {
            RaycastHit hit;
            Vector3 direction = playerTransform.position - cameraPos.position;

            if (Physics.Raycast(cameraPos.position, direction, out hit, Mathf.Infinity, obstacleLayer))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;
                }
            }
        }

        private void UpdateCameraPosition()
        {
            // Update camera position to follow the player with an offset
            Vector3 offset = Quaternion.Euler(0, cameraPos.eulerAngles.y, 0) * new Vector3(0, verticalOffset, -10);
            Vector3 targetPosition = playerTransform.position + offset;
            cameraPos.position = Vector3.Lerp(cameraPos.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
