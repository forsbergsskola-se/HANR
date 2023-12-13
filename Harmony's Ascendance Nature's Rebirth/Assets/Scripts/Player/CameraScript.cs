using System;
using NPC;
using UnityEngine;

namespace Player
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private GameObject cameraObject;
        private Transform cameraPos;
        private Transform playerTransform;
        private bool locked;
        private bool talkingBearMan;
        private bool talkingRanger;


        [SerializeField] float DialoguezoomSpeed = 5f;
        [SerializeField] private float zoomDistance = 15f;
        [SerializeField] private float rotationSpeed = 3f;
        [SerializeField] private float zoomSpeed = 5f;
        [SerializeField] private float minZoom = 20f;
        [SerializeField] private float maxZoom = 60f;
        [SerializeField] private float verticalOffset = 2f;
        [SerializeField] private LayerMask obstacleLayer;
        [SerializeField] private Dialogue dialogue;
        [SerializeField] private Transform Ranger;
        [SerializeField] private Transform BearMan;
        [SerializeField] private Vector3 Dialogueoffset = new Vector3(0, 5, 0);

        private void Start()
        {
            if (cameraObject == null)
            {
                Debug.LogError("Camera Object not assigned to the script.");
                enabled = false;
                return;
            }

            cameraPos = cameraObject.transform;
            playerTransform = transform;

            dialogue.druidToRanger.AddListener(lockCameraRanger);
            dialogue.druidToBearMan.AddListener(lockCameraBearman);

        }

        private void OnDestroy()
        {
            dialogue.druidToRanger.RemoveListener(lockCameraRanger);
            dialogue.druidToBearMan.RemoveListener(lockCameraBearman);
        }

        void Update()
        {

            if (!locked)
            {
                HandleRotationInput();
                HandleZoomInput();
                HandleObstacleVisibility();
                UpdateCameraPosition();
            }
            else if (talkingBearMan)
            {
                CameraBearMan();
            }
            else if (talkingRanger)
            {
                CameraRanger();
            }

        }

        private void HandleRotationInput()
        {
            if (Input.GetMouseButton(0))
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

            Vector3 offset = Quaternion.Euler(0, cameraPos.eulerAngles.y, 0) * new Vector3(0, verticalOffset, -10);
            Vector3 targetPosition = playerTransform.position + offset;
            cameraPos.position = Vector3.Lerp(cameraPos.position, targetPosition, Time.deltaTime * 5f);
        }

        private void lockCameraRanger()
        {
            locked = true;
            talkingRanger = true;
        }

        private void lockCameraBearman()
        {
            locked = true;
            talkingBearMan = true;
        }

        private void UnLock()
        {
            locked = false;
        }

        private void CameraRanger()
        {
            ZoomIn(Ranger);

            void ZoomIn(Transform character)
            {

                if (character != null)
                {
                    Vector3 targetPosition = character.position + (Vector3.forward * zoomDistance + Dialogueoffset);

                    // Use Lerp for smooth camera movement
                    cameraObject.transform.LookAt(character);
                    cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, targetPosition,
                        Time.deltaTime * DialoguezoomSpeed);

                }
            }

            locked = true;
        }

        private void CameraBearMan()
        {
            ZoomIn(BearMan);

            void ZoomIn(Transform character)
            {

                if (character != null)
                {
                    Vector3 targetPosition = character.position + (Vector3.forward * zoomDistance + Dialogueoffset);

                    // Use Lerp for smooth camera movement
                    cameraObject.transform.LookAt(character);
                    cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, targetPosition,
                        Time.deltaTime * DialoguezoomSpeed);

                }
            }

            locked = true;
        }
    }
}
