using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // TODO: timer is not called, it is just based off events

    public Image ParentImage;

    public float TimeToAnswer;

    private float maxFillAmount;

    private float elapsedTime;

    private bool isTimerActive;

    void Start()
    {
        this.maxFillAmount = 1;
        this.elapsedTime = 0;
        this.isTimerActive = false;
    }

    void FixedUpdate()
    {
        this.elapsedTime += Time.deltaTime;
        this.UpdateTimerImage(this.ParentImage, this.maxFillAmount, this.elapsedTime, this.TimeToAnswer);
    }

    public void StartTimer()
    {
        this.isTimerActive = true;
    }

    public void StopTimer()
    {
        this.isTimerActive = false;
        this.elapsedTime = 0;
    }

    private void UpdateTimerImage(Image image, float maxFillAmount, float elapsedTime, float timeToAnswer)
    {
        float total = Mathf.Max(maxFillAmount - (elapsedTime / TimeToAnswer), 0);
        this.ParentImage.fillAmount = total;

#if UNITY_EDITOR
        Debug.Log(string.Format("{0}: Mathf.Max({1} - ({2} / {3}), 0)", total, maxFillAmount, elapsedTime, timeToAnswer));
#endif
    }
}
