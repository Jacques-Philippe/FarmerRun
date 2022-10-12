using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreReceiver : MonoBehaviour
{
    /// <summary>
    /// The UI element containing the text where state information is displayed
    /// </summary>
    protected TextMeshProUGUI text;

    /// <summary>
    /// The value of the angle, in degrees
    /// </summary>
    private string score;

    /// <summary>
    /// The public-facing accessor and mutator for the angle value. <br />
    /// Note changing this value will update the UI
    /// </summary>
    public string Score
    {
        get => score;
        set
        {
            this.ThreadsafeUpdate(newValue: value);
            this.score = value;
        }
    }

    /// <summary>
    /// A queue to contain all enqueued text to update the UI with
    /// </summary>
    /// <remarks>this is done so that updates to the UI are made properly</remarks>
    protected ConcurrentQueue<string> mQueuedText = new ConcurrentQueue<string>();

    private void Start()
    {
        this.text = this.GetComponent<TextMeshProUGUI>();
    }

    void ThreadsafeUpdate(string newValue)
    {
        mQueuedText.Enqueue($"{newValue}");
    }

    protected virtual void UpdateText()
    {
        string newAngle;
        while (mQueuedText.TryDequeue(out newAngle))
        {
            text.text = $"{newAngle}";
        }
    }

    private void Update()
    {
        UpdateText();
    }
}
