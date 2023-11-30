using System;
using System.Collections;
using UnityEngine;

namespace Objects
{
    public class ClickEffectReturn : MonoBehaviour
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