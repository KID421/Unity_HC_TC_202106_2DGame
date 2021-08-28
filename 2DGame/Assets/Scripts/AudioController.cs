using UnityEngine;
using UnityEngine.Audio;        // 引用 音源 API

public class AudioController : MonoBehaviour
{
    [Header("混音器")]
    public AudioMixer mixer;

    // 滑桿 slider 的 On Value Changed 事件：滑動變更數值時時執行一次
    // (Single) 等於 float

    /// <summary>
    /// 設定 BGM 音量
    /// </summary>
    /// <param name="volume">要設定的音量值</param>
    public void SetVolumeBGM(float volume)
    {
        mixer.SetFloat("VolumeBGM", volume);
    }

    /// <summary>
    /// 設定 SFX 音量
    /// </summary>
    /// <param name="volume">要設定的音量值</param>
    public void SetVolumeSFX(float volume)
    {
        mixer.SetFloat("VolumeSFX", volume);
    }
}
