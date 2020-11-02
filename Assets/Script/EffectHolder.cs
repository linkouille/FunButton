using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHolder : MonoBehaviour
{

    [SerializeField] private List<GameObject> effect;

    public static EffectHolder current;

    private void Start()
    {
        current = this;
    }

    public void PlayEffect(Effect id, Vector3 pos)
    {
        GameObject e = GameObject.Instantiate(effect[(int)id], pos, Quaternion.Euler(50,0,0), null);
        float lifeTime = e.GetComponent<ParticleSystem>() ? e.GetComponent<ParticleSystem>().main.duration : 5;
        Destroy(e.gameObject, lifeTime);
    }
}


public enum Effect
{
    CLICK,
    STRESS
}