using System.Collections;
using UnityEngine;

namespace Objects
{
    public class DefaultAttackEffectReturn : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(ReturnEffect(this.gameObject));
        }

        private IEnumerator ReturnEffect(GameObject effect)
        {
            yield return new WaitForSeconds(5f);
            effect.SetActive(false);
        }
    }
}