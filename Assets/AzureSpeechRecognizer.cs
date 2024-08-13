using UnityEngine;
using Microsoft.CognitiveServices.Speech;

public class AzureSpeechRecognizer : MonoBehaviour
{
    private string subscriptionKey = "72e5e5f65f9146818ccbb55bb90f20b0"; // API KEY
    private string region = "uksouth"; // ServiceRegion

    private SpeechRecognizer recognizer;

    void Start()
    {
        InitializeRecognizer();
    }

    private async void InitializeRecognizer()
    {
        var config = SpeechConfig.FromSubscription(subscriptionKey, region);
        recognizer = new SpeechRecognizer(config);

        recognizer.Recognizing += (s, e) =>
        {
            Debug.Log($"Recognizing: {e.Result.Text}");
        };

        recognizer.Recognized += (s, e) =>
        {
            Debug.Log($"Recognized: {e.Result.Text}");
            OnSpeechRecognized(e.Result.Text);
        };

        recognizer.Canceled += (s, e) =>
        {
            Debug.LogError($"Canceled: {e.Reason}");
        };

        recognizer.SessionStopped += (s, e) =>
        {
            Debug.Log($"SessionStopped");
        };

        await recognizer.StartContinuousRecognitionAsync();
    }

    private void OnDestroy()
    {
        recognizer.StopContinuousRecognitionAsync().Wait();
        recognizer.Dispose();
    }

    private void OnSpeechRecognized(string text)
    {
        
        Debug.Log($"Speech recognized: {text}");
    }
}
