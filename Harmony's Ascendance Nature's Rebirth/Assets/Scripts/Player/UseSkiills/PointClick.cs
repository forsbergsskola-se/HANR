using System;
using UnityEngine;

namespace Player.UseSkills
{
    public class PointClick : MonoBehaviour
    {
        private Camera _camera;
        public Skills skill;
        private Vector3 targetPoint;
        
        private void Start()
        {
            _camera = Camera.main;
        }
        private void Update()
        {
            GetMouseInput();
        }

        private void GetMouseInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_camera)
                {
                    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (skill)
                        {
                            targetPoint = raycastHit.point;
                            ShootSkill();
                        }
                    }
                }
            }
        }

        private void ShootSkill()
        {
            Vector3 dirPlayer = (targetPoint - this.transform.position).normalized;
            this.gameObject.transform.rotation = Quaternion.LookRotation(dirPlayer);
            
            GameObject skGameObject = Instantiate(skill.skillObject);
            GameObject weaponPoint = this.GetComponentInChildren<WeaponEquipped>().gameObject;
            skGameObject.transform.position = weaponPoint.transform.position;
            skGameObject.transform.rotation = this.transform.rotation;
            Vector3 dir = (targetPoint - skGameObject.transform.position).normalized;
            
            Rigidbody rb = skGameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(dir.x * 5f, dir.y * 5f, dir.z * 5f);
            skill = null;
        }
    }
}