using System;
using UnityEngine;

namespace Player
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private GameObject cameraObject;
        private Transform cameraPos;
        private Vector3 currentVelocity;
        [SerializeField] private float smoothTime = 0.3f;
        [SerializeField] private Vector3 offset = new Vector3(10f, 10f, 0f);
        private GameObject CameraPosObject;

        private void Start()
        {
            // Instead of this we should assign a  class to the cameraPos GameObject and then use that to find this game object.
            // Using the get component method
            CameraPosObject = this.GetComponentInChildren<CameraPosObject>().gameObject;
        }

        void Update()
        {
            cameraPos = CameraPosObject.transform;
            Vector3 newPosition = transform.position + offset;
            cameraPos.position = newPosition;
            cameraObject.transform.position = Vector3.SmoothDamp(
                cameraObject.transform.position,
                new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z),
                ref currentVelocity,
                smoothTime
            );
        }
    }
}