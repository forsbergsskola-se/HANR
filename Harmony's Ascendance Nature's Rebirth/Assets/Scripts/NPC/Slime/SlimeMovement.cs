using UnityEngine;
using UnityEngine.AI;

namespace NPC.Slime
{
    public class SlimeMovement : MonoBehaviour
    {
        public Face faces;
        public GameObject SmileBody;
        public SlimeAnimationState currentState; 
   
        public Animator animator;
        public NavMeshAgent agent;
        public Transform[] waypoints;
        
        private int m_CurrentWaypointIndex;

        private bool move;
        private Material faceMaterial;
        private Vector3 originPos;
        
        void Start()
        {
            originPos = transform.position;
            faceMaterial = SmileBody.GetComponent<Renderer>().materials[0];
        }
        
        public void WalkToNextDestination()
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            SetFace(faces.WalkFace);
        }
        
        void SetFace(Texture tex)
        {
            faceMaterial.SetTexture("_MainTex", tex);
        }
        
    }
}