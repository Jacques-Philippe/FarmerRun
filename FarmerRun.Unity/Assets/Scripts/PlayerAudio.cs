using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> mJumpSounds;

    /// <summary>
    /// The source from which the sound comes
    /// </summary>
    private AudioSource source;

    private void Start()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        var randIndex = Random.Range(0, mJumpSounds.Count);
        var sound = mJumpSounds[randIndex];
        this.source.PlayOneShot(sound);
    }
}
