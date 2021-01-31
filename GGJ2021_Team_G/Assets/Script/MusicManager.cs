using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [Header("環境聲音")]
    public AudioClip ambientClip;
    public AudioClip musicClip;//BGM

    [Header("FX音效")]
    public AudioClip bossAttackClip;
    public AudioClip finishClip;//BGM
    public AudioClip pickUpClip;

    public AudioSource ambientSource;
    public AudioSource musicSource;
    public AudioSource soundFxSource;

    private bool unlock = false;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void UnlockFunction()
    {
        unlock = true;
        PlayBGM();
    }

    public void PlayAmbient()
    {
        if (unlock == false)
        {
            return;
        }
        ambientSource.clip = ambientClip;
        ambientSource.Play();
    }

    public void PlayBGM()
    {
        if (unlock == false)
        {
            return;
        }
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlayBossAttackSound()
    {
        if (unlock == false)
        {
            return;
        }
        soundFxSource.PlayOneShot(bossAttackClip);
    }

    /// <summary>
    /// 目前的BOSS攻擊音效有點長，手動關閉。
    /// </summary>
    public void StopBossAttackSound()
    {
        soundFxSource.Stop();
    }

    public void PlayPickUpSound()
    {
        if (unlock == false)
        {
            return;
        }
        soundFxSource.PlayOneShot(pickUpClip);
    }

    public void PlayFinishBGM()
    {
        if (unlock == false)
        {
            return;
        }
        musicSource.Stop();
        musicSource.clip = finishClip;
        musicSource.Play();
    }
}
