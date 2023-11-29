using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> audioSources;

    private const string VolumePrefsKey = "VolumeLevel";
    private const string MutePrefsKey = "MuteToggle";

    private static SoundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Configura o valor inicial do volume para o valor salvo (ou 1 se não houver valor salvo)
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefsKey, 1f);
        SetVolume(savedVolume);

        // Configura o estado inicial do mudo com base no PlayerPrefs
        bool isMuted = PlayerPrefs.GetInt(MutePrefsKey, 0) == 1;
        SetMute(isMuted);
    }

    public void SetVolume(float volume)
    {
        // Atualiza o volume de todos os AudioSources na lista
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        // Salva o volume atual no PlayerPrefs
        PlayerPrefs.SetFloat(VolumePrefsKey, volume);
        PlayerPrefs.Save();
    }

    public void SetMute(bool isMuted)
    {
        // Atualiza o volume de todos os AudioSources na lista
        float volume = isMuted ? 0f : PlayerPrefs.GetFloat(VolumePrefsKey, 1f);

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        // Salva o estado do mudo no PlayerPrefs
        PlayerPrefs.SetInt(MutePrefsKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
