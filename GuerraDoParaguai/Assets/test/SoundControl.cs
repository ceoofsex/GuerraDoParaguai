using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;

    private const string VolumePrefsKey = "VolumeLevel";

    private void Start()
    {
        // Configura o valor inicial do slider para o volume salvo (ou 1 se não houver valor salvo)
        volumeSlider.value = PlayerPrefs.GetFloat(VolumePrefsKey, 1f);

        // Adiciona um ouvinte de mudança ao slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        // Adiciona um ouvinte de mudança ao toggle de mudo
        muteToggle.onValueChanged.AddListener(ToggleMute);

        // Atualiza o estado inicial do mudo com base no PlayerPrefs
        muteToggle.isOn = PlayerPrefs.GetInt("MuteToggle", 0) == 1;
    }

    private void ChangeVolume(float volume)
    {
        // Atualiza o volume globalmente
        AudioListener.volume = volume;

        // Salva o volume atual no PlayerPrefs
        PlayerPrefs.SetFloat(VolumePrefsKey, volume);
    }

    private void ToggleMute(bool isMuted)
    {
        // Atualiza o volume globalmente
        AudioListener.volume = isMuted ? 0f : volumeSlider.value;

        // Salva o estado do mudo no PlayerPrefs
        PlayerPrefs.SetInt("MuteToggle", isMuted ? 1 : 0);
    }
}
