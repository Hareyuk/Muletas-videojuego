using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    static AudioSource audioSource;
    public bool loop = false;
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        if (loop)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
        /*if (this.transform.name == "Setup Data")
        {
            //audioSource.PlayOneShot(bgm_sound);
        }*/
    }
    public void PlaySound(string clip)
    {
        AudioClip audio = Resources.Load<AudioClip>("Audio/" +clip);
        audioSource.PlayOneShot(audio);
    }
}
