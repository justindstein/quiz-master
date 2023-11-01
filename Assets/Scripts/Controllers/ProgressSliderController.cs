using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSliderController : MonoBehaviour
{
    public IntVariable QuizSize;

    public GameObject ProgressSliderPrefab;

    public IntVariable QuizAnswerCount;

    public void CreateProgressSlider(Component component, System.Object obj)
    {
        this.DestroyProgressSliders();

        GameObject progressSlider = Instantiate(this.ProgressSliderPrefab);
        progressSlider.GetComponent<Slider>().maxValue = this.QuizSize.Value;
        progressSlider.transform.SetParent(this.transform);

        this.UpdateProgress(null, null);
    }

    public void DestroyProgressSliders(Component component, System.Object obj)
    {
        this.DestroyProgressSliders();
    }

    private void DestroyProgressSliders()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    public void UpdateProgress(Component component, System.Object obj)
    {
        this.transform.GetComponentInChildren<Slider>().value = this.QuizAnswerCount.Value;
    }
}
