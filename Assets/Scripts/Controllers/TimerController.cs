using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // TODO: timer is not called, it is just based off events

    public Image ParentImage;

    public float TimeToAnswer;

    private float totalElapsedTime;

    void Start()
    {
        this.totalElapsedTime = 0;
    }

    void Update()
    {
        this.totalElapsedTime += Time.deltaTime;
        Debug.Log(string.Format("Setting [fillAmount: {0}]", (1 - (this.TimeToAnswer / Mathf.Min(this.totalElapsedTime, this.TimeToAnswer)))));
        this.ParentImage.fillAmount = (1 - (this.TimeToAnswer / Mathf.Min(this.totalElapsedTime, this.TimeToAnswer)));
    }

    void FixedUpdate()
    {

    }
}
