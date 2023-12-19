using System;
using CustomObjects;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace NPC.Slime
{
    public class SlimeMovement : MonoBehaviour
    {
        public Face faces;
        public GameObject slimeBody;
        public BoolVariable slimeMoving;
        public BoolVariable playSlimeMoving;
        public GameObject harmony;
   
        public Animator animator;
        public NavMeshAgent agent;
        public GameObject firstDestinationPoint;
        public GameObject secondDestinationPoint;

        public Quest quest;
        
        private Material faceMaterial;
        private Vector3 originPos;
        [SerializeField] private float turnRate;

        private void Awake()
        {
            slimeMoving.ValueChanged.AddListener(MoveSlime);
        }

        private void OnDestroy()
        {
            slimeMoving.ValueChanged.RemoveListener(MoveSlime);
        }

        void Start()
        {
            originPos = transform.position;
            faceMaterial = slimeBody.GetComponent<Renderer>().materials[0];
        }

        private void LateUpdate()
        {
            if (agent.hasPath)
            {
                if (agent.velocity.magnitude > 0)
                {
                    animator.SetBool("SlimeWalking",true);
                    SetFace(faces.WalkFace);
                }
                else
                {
                    animator.SetBool("SlimeWalking", false);
                }
            }
            else
            {
                animator.SetBool("SlimeWalking", false);
                SetFace(faces.Idleface);
                LookAtHarmony();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (quest.currentBossState == Quest.BossQuestLine.WalkWithMimi)
            {
                if (other.gameObject == firstDestinationPoint)
                    quest.questProgression.Invoke(3); //State goes to DefendMimi
            }
            if (quest.currentBossState == Quest.BossQuestLine.WalkWithMimiToBoss)
            {
                if (other.gameObject == secondDestinationPoint)
                    quest.questProgression.Invoke(5); //State goes to WalkWithMimiToBoss
            }
        }

        public void MoveSlime(bool slimeMoving)
        {
            if (quest.currentBossState == Quest.BossQuestLine.WalkWithMimi)
            {
                if (this.slimeMoving)
                {
                    agent.isStopped = false;
                    agent.SetDestination(firstDestinationPoint.transform.position);
                    playSlimeMoving.setValue(true);
                }
                else
                {
                    agent.isStopped = true;
                    playSlimeMoving.setValue(false);
                }
            }
            else if (quest.currentBossState == Quest.BossQuestLine.WalkWithMimiToBoss)
            {
                if (this.slimeMoving)
                {
                    agent.isStopped = false;
                    agent.SetDestination(secondDestinationPoint.transform.position);
                    playSlimeMoving.setValue(true);
                }
                else
                {
                    agent.isStopped = true;
                    playSlimeMoving.setValue(false);
                }
            }
        }
        
        void SetFace(Texture tex)
        {
            faceMaterial.SetTexture("_MainTex", tex);
        }

        
        void LookAtHarmony()
        {
            Vector3 direction = (harmony.transform.position - agent.transform.position).normalized;
            direction.y = 0;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime*turnRate);  
        }
    }
}