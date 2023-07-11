using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioClip[] bgms;
    [SerializeField] AudioClip[] sfxs;
    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] float sfxVolume = 1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetBgmVolume(float volume) => bgmPlayer.volume = volume;

    public void PlayBgm(BGM bgm)
    {
        bgmPlayer.clip = bgms[(int)bgm];
        bgmPlayer.Play();
    }

    public void PlaySfx(SFX sfx, GameObject obj)
    {
        if (!obj.TryGetComponent(out AudioSource tmp))
        {
            obj.AddComponent<AudioSource>().volume = sfxVolume;
        }
        else
        {
            tmp.volume = sfxVolume;
        }
        tmp.PlayOneShot(sfxs[(int)sfx]);
    }
}

public enum BGM { MAIN_MENU, LOBBY }
public enum SFX { MOUSE_CLICK }