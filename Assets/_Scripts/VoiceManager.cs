using UnityEngine;
using AudioRecorder;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour
{
    
    Recorder recorder;
    AudioSource _audioSource;
    AudioClip testClip;

    public GameObject https;
    public Text debug_txt;

    public GameObject panel1;
    public GameObject panel2;
    public Button play_btn;
    public Button send_btn;

    public GameObject webViewManager;

    float second;
    bool voiceStart;

    public Text TimeTxt;
    public bool autoPlay; //자동 재생
    
    void OnEnable()
    {
        recorder = new Recorder();
        Recorder.onInit += OnInit;
        Recorder.onFinish += OnRecordingFinish;
        Recorder.onError += OnError;
        Recorder.onSaved += OnRecordingSaved;
    }
    void OnDisable()
    {
        Recorder.onInit -= OnInit;
        Recorder.onFinish -= OnRecordingFinish;
        Recorder.onError -= OnError;
        Recorder.onSaved -= OnRecordingSaved;
    }

    void Start()
    {
        recorder.Init();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (voiceStart)
        {
            second += Time.deltaTime;
            TimeTxt.text = second.ToString("0:00");
        }
        

    }
    public void recorder_Start()
    {
        if (recorder.IsReady)
        {
            if (!recorder.IsRecording)
            {
                voiceStart = true;
                recorder.StartRecording(false, 60);
            }
        }
    }
    

    public void recorder_Stop()
    {
        if (recorder.IsReady)
        {
            if (recorder.IsRecording)
            {
                voiceStart = false;
                second = 0;
                TimeTxt.text = "0:00";
                recorder.StopRecording();
                recorder_Save();
                send_btn.interactable = true;
                play_btn.interactable = true;
            }
        }
    }

    public void recorder_Play()
    {
        if (recorder.IsReady)
        {
            if (recorder.hasRecorded)
            {
                recorder.PlayAudio(System.IO.Path.Combine(Application.persistentDataPath, "Audio123.wav"), _audioSource);
            }
        }
    }

    public void recorder_Save()
    {
        if (recorder.IsReady)
        {
            if (recorder.hasRecorded)
            {
                recorder.Save(System.IO.Path.Combine(Application.persistentDataPath, "Audio123.wav"), recorder.Clip);
            }
        }
    }

    public void recorder_Dipose()
    {
        if (recorder.hasRecorded)
        {
            recorder.Dispose();
        }
    }

    public void send_voice()
    {
        https.GetComponent<https>().Send_voice();
        second = 0;
        TimeTxt.text = "0:00";
        //조건
        play_btn.interactable = false;
        send_btn.interactable = false;

        panel1.SetActive(false);
        panel2.SetActive(false);

        webViewManager.GetComponent<WebViewScript>().OnWebView();
        
    }

    public void recorder_Load()
    {
        WWW fileLoad = new WWW("file://" + Application.persistentDataPath + "/Audio123.wav");
        WWWForm form = new WWWForm();
        form.AddBinaryData("sound", fileLoad.bytes, "Audio123.wav", "multipart/form-data");
        Debug.Log("fileLoadbytes : " + fileLoad.bytes.Length);
    }

    void OnInit(bool success)
    {
        Debug.Log("Success : " + success);
        //debug_txt.text = "Success : " + success;
    }

    void OnError(string errMsg)
    {
        Debug.Log("Error : " + errMsg);
        //debug_txt.text = "Error : " + errMsg;
    }

    void OnRecordingFinish(AudioClip clip)
    {
        if (autoPlay)
        {
            recorder.PlayAudio(clip, _audioSource);

            // or you can use
            //recorder.PlayRecorded(audioSource);
        }
    }

    void OnRecordingSaved(string path)
    {
        Debug.Log("File Saved at : " + path);
        //debug_txt.text = "File Saved at : " + path;
        //recorder.PlayAudio (path, _audioSource);
    }


}