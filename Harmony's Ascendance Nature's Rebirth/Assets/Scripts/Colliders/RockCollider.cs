using System.Collections;
using UnityEngine;

namespace Colliders
{
    public class RockCollider : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                StartCoroutine(disableRockObject(this.gameObject));
            } 
        }

        private IEnumerator disableRockObject(GameObject go)
        {
            yield return new WaitForSeconds(2);
            go.SetActive(false);
        }
    }
}