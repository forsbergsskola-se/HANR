using UnityEngine;

namespace Player
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private GameObject cameraObject;
        private Transform cameraPos;
        private Vector3 currentVelocity;
        [SerializeField] private float smoothTime = 0.3f;
        [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0f);

        void FixedUpdate()
        {
            GameObject CameraPosObject = GameObject.Find("CameraPos");
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