using UnityEngine;
using UnityEngine.UI;

public class MicroTest : MonoBehaviour
{
    public Button startButton;
    public Button stopButton;
    
    private void Awake() 
    {
        startButton.onClick.AddListener(this.OnStartClick);
        stopButton.onClick.AddListener(this.OnStopClick);
    }

    /// <summary>
    /// 开始录制
    /// </summary>
    void OnStartClick()
    {
        Debug.Log("OnStartClick");
        
        if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            StartCoroutine(MicrophoneInput.Instance.RequestMicrophoneAuth());
            return;
        }
        
        MicrophoneInput.Instance.StartRecord();
    }
    
    /// <summary>
    /// 停止录制
    /// </summary>
    private void OnStopClick()
    {
        Debug.Log("OnStopClick");

        int length = MicrophoneInput.Instance.StopRecord();
        var path = Application.persistentDataPath + "/micro.pcm";
        Debug.Log(path);
        MicrophoneInput.Instance.SaveAudioFile(path, length);

        PlayAudio();
    }

    /// <summary>
    /// 播放录音
    /// </summary>
    private void PlayAudio()
    {
        var path = Application.persistentDataPath + "/micro.pcm";
        //读取本地文件播放
        MicrophoneInput.Instance.ReadAudioFile(path);
    }

}
