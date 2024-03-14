using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChanger : MonoBehaviour
{
    public ParticleSystem effect;
    // Start is called before the first frame update

    private void OnDestroy()
    {
        effect.Stop();
    }

    // Update is called once per frame
}
