using UnityEngine;

public class TimerDisplayer : MonoBehaviour
{
    public TimerScript timerScript;
    public TMPro.TextMeshProUGUI text;
    void Update()
    {
        text.text = timerScript.TimerDisplay();
    }
}
