using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHolder : MonoBehaviour
{

    [SerializeField] private List<AudioClip> sounds;

    public static SoundHolder current;

    private void Start()
    {
        current = this;
    }

    public void PlaySound(int i)
    {
        AudioSource aS = this.gameObject.AddComponent<AudioSource>();
        aS.clip = sounds[i];
        aS.Play();

        Destroy(aS, sounds[i].length + 0.1f);
    }


}
