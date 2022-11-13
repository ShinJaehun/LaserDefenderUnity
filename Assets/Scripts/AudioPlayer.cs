using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;
    // public AudioPlayer GetInstance()
    // {
    //     return instance;
    // }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if (instanceCount > 1)
        // {
        //     gameObject.SetActive(false);
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     DontDestroyOnLoad(gameObject);
        // }

        if (instance != null) //이런 형식의 코드가 훨씬 더 이해하기 쉬운데!
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // public void PlayShootingClip()
    // {
    //     if (shootingClip != null)
    //     {
    //         AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
    //     }
    // }

    // public void PlayDamageClip()
    // {
    //     if (damageClip != null)
    //     {
    //         AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
    //     }
    // }

    public void PlayShootingClip()
    {
        PlayerClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayerClip(damageClip, damageVolume);
    }

    void PlayerClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
