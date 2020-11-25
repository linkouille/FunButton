using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerZone : MonoBehaviour
{
    public UnityEvent function;

    private Collider col;

    [SerializeField] private List<string> tags;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        foreach (string s in tags)
        {
            if(collision.tag == s)
            {
                Debug.Log("trigger");
                function.Invoke();
                Destroy(this.gameObject);
            }
        }
    }

}
