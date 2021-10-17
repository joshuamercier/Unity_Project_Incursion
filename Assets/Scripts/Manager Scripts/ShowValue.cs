using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    // Class variables
    [SerializeField]  Slider thisSlider;
    // Update is called once per frame
    public void AdjustText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = ((int)thisSlider.value).ToString() + " %";
    }
}
