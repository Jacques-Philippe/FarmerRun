using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private GameManager gameManager;

    /// <summary>
    /// The source from which the sound comes
    /// </summary>
    private AudioSource source;

    /// <summary>
    /// Music to be played when the game is in progress
    /// </summary>
    public AudioClip GameMusic;
    /// <summary>
    /// Music to be played when the game is over
    /// </summary>
    public AudioClip GameOverMusic;

    // Start is called before the first frame update
    void Start()
    {
        this.source = this.GetComponent<AudioSource>();
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine("PlayMusic");
    }

    IEnumerator PlayMusic()
    {
        this.PlayGameMusic();
        yield return new WaitUntil(() => this.gameManager.IsGameOver);
        this.PlayGameOverMusic();
    }

    private void ChangePlayedSong(AudioClip to)
    {
        if (this.source.isPlaying) this.source.Stop();
        this.source.clip = to;
        this.source.loop = true;
        this.source.Play();
    }

    #region AUDIO SCHEMES

    void PlayGameMusic()
    {
        Debug.Log("Playing game music");
        this.ChangePlayedSong(to: this.GameMusic);
    }

    void PlayGameOverMusic()
    {
        Debug.Log("Playing game over music");
        this.ChangePlayedSong(to: this.GameOverMusic);
    }

    

    #endregion
}
