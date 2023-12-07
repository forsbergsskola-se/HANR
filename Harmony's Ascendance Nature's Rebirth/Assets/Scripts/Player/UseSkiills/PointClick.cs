using System;
using System.Collections;
using CustomObjects;
using UnityEngine;

namespace Player.UseSkills
{
    public class PointClick : MonoBehaviour
    {
        private Camera _camera;
        public Skills skill;
        private Vector3 targetPoint;
        public BoolVariable playerMoving;
        
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
                            if (skill.name == "FireBall")
                            {
                                ShootFireball();
                            } else if (skill.name == "BubbleBeam")
                            {
                                ShootBubbleBeam();
                            }
                            
                        }
                    }
                }
            }
        }
        
        private void RotatePlayer()
        {
            Vector3 dirPlayer = (targetPoint - this.transform.position).normalized;
            this.gameObject.transform.rotation = Quaternion.LookRotation(dirPlayer);
        }

        private void ShootFireball()
        {
            playerMoving.setValue(false);
            RotatePlayer();
            GameObject skGameObject = Instantiate(skill.skillObject);
            GameObject weaponPoint = this.GetComponentInChildren<WeaponEquipped>().gameObject;
            skGameObject.transform.position = weaponPoint.transform.position;
            skGameObject.transform.rotation = this.transform.rotation;
            skGameObject.transform.localScale = Vector3.one * 1.1f;
            Vector3 dir = (targetPoint - skGameObject.transform.position).normalized;
            
            Rigidbody rb = skGameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(dir.x * 10f, dir.y * 10f, dir.z * 10f);
            skill = null;
        }

        private void ShootBubbleBeam()
        {
            playerMoving.setValue(false);
            RotatePlayer();
            GameObject weaponPoint = this.GetComponentInChildren<WeaponEquipped>().gameObject;
            GameObject skGameObject = Instantiate(skill.skillObject);
            skGameObject.transform.position = weaponPoint.transform.position;
            Vector3 dir = (targetPoint - skGameObject.transform.position).normalized;
            skGameObject.transform.rotation = Quaternion.LookRotation(dir);
            StartCoroutine(channelBB(skGameObject));
            skill = null;
        }

        private IEnumerator channelBB(GameObject skillGO)
        {
            yield return new WaitForSeconds(3);
            ParticleSystem ps = skillGO.GetComponent<ParticleSystem>();
            var emissionModule = ps.emission;
            emissionModule.enabled = false;
            ;
        }
    }
}