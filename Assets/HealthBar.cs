using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image green;

    public void SetPercent(float percent)
    {
        if (percent < 0) percent = 0;

             green.transform.localScale = new Vector3(percent,
                                              green.transform.localScale.y,
                                              green.transform.localScale.z);
    }
}
