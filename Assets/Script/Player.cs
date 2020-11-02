using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    public bool run;

    [SerializeField] private float speed;
    [SerializeField] private Vector3 dir;

    private Rigidbody rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        anim.SetBool("Run", run);


        if (run)
        {
            rb.velocity = dir * speed;
        }

    }
}
