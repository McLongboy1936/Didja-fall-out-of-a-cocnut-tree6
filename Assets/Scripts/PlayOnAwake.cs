using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnAwake : MonoBehaviour
{
    public AudioSource source;
    public AudioClip Bonk;
    public AudioClip Victory;
    private void Start()
    {
        source.PlayOneShot(Bonk);
        source.PlayOneShot(Victory);

    }

}
