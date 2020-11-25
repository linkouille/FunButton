using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherAI : MonoBehaviour
{

    private Watcher watcher;
    private Rigidbody rb;
    private Animator anim;

    [SerializeField] private List<Vector3> pos;

    [SerializeField] private int state;

    [SerializeField] private bool isReady;

    [SerializeField] private float range;

    [SerializeField] private float speed;


    private void Awake()
    {
        watcher = GetComponent<Watcher>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isReady && state != -1)
        {
            Vector3 dir = pos[state] - transform.position;
            dir = dir.normalized;
            rb.velocity = dir * speed;
            anim.enabled = false;
            if(Vector3.Distance(transform.position, pos[state]) <= range)
            {
                isReady = true;
                anim.enabled = true;
            }

        }
        else
        {
            anim.SetBool("Ready", isReady);
            anim.SetInteger("State", state);
        }
    }
    public void MoveTotheNextPoint()
    {
        state += 1;
        isReady = false;
    }




}

