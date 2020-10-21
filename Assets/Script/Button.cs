using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{

    private Animator anim;

    [SerializeField] private KeyCode key;

    [SerializeField] private float waitShake;

    [Range(0,5)]
    [SerializeField] private float maxAmount;
    

    [SerializeField] private Camera mainCam;

    [SerializeField] private float shakeSpeed;

    private float shakeAmount = 0;

    private bool keyState;

    [SerializeField]private float timeSpend;

    [SerializeField] private bool playEffect;
    [SerializeField] private bool playSound;

    [SerializeField] private Player p;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        keyState = Input.GetKey(key);
        p.run = keyState;

        anim.SetBool("State", keyState);

        if (Input.GetKeyDown(key) && playEffect)
        {
            if (playEffect)
            {
                EffectHolder.current.PlayEffect(Effect.CLICK, transform.position + (Vector3)(Vector2.one * Random.Range(-1, 1)));
            }
            if (playSound)
            {
                SoundHolder.current.PlaySound(0);
            }
        }

        if (keyState)
        {
            timeSpend += Time.deltaTime;
            if (timeSpend >= waitShake)
            {
                mainCam.transform.DOComplete();
                mainCam.transform.DOShakePosition(0.5f, shakeAmount, 1, 90, false, true);
                shakeAmount = Mathf.Lerp(shakeAmount, maxAmount, shakeSpeed);
            }
        }
        else
        {
            shakeAmount = 0;
            timeSpend = 0;
        }
        
    }

}
