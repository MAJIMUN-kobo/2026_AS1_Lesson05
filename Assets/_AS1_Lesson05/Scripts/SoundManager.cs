using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("* * * ミキサー設定 * * *")]
    public AudioMixer audioMixer;   // AudioMixerアセット
    public float bgmVolume;         // BGMの音量
    public float seVolume;          // SEの音量

    [Header("* * * uGUI 設定 * * *")]
    public Slider bgmSlider;        // BGMのスライダー参照
    public Slider seSlider;         // SEのスライダー参照


    void Start()
    {
        LoadVolume();       // 音量の読み込み
    }


    void Update()
    {
        SaveVolume();       // 音量の保存
        SoundMixerUpdate(); // Mixerの音量調整
        UpdateBgmVolume();  // BGMの音量を変更
        UpdateSeVolume();   // SEの音量を変更
    }


    /// <summary>
    /// 音量を保存するメソッド
    /// </summary>
    public void SaveVolume()
    {
        // PlayerPrefs を用いた値の保存
        // PlayerPrefs.SetFloat(string 保存名, float 保存値)
        PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SeVolume", seSlider.value);

        // Setした値を保存する
        PlayerPrefs.Save();
    }


    /// <summary>
    /// 音量を読み込むメソッド
    /// </summary>
    public void LoadVolume()
    {
        // PlayerPrefs.GetFload(string 保存名)
        bgmSlider.value = PlayerPrefs.GetFloat("BgmVolume");
        seSlider.value = PlayerPrefs.GetFloat("SeVolume");
    }


    /// <summary>
    /// 実際に音量を反映するメソッド
    /// </summary>
    public void SoundMixerUpdate()
    {
        // AudioMixerに保存している音量を設定する
        // AudioMixer.SetFloat(string パラメータ名, float 設定値)
        audioMixer.SetFloat("BgmVolume", bgmVolume);
        audioMixer.SetFloat("SeVolume", seVolume);
    }


    /// <summary>
    /// BGMをスライダーで設定するメソッド
    /// </summary>
    public void UpdateBgmVolume()
    {
        // 👉スライダーの値(value)は 0～1 しか出ない。
        // 👉AudioMixerの値は 20～-80の間で設定する。
        bgmVolume = (bgmSlider.value * 100) - 80;
    }


    /// <summary>
    /// SEをスライダーで設定するメソッド
    /// </summary>
    public void UpdateSeVolume()
    {
        seVolume = (seSlider.value * 100) - 80;
    }
}
