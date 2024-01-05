using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private string returnString; //This is a string that is used to determine where the camera should return to when the menu is closed (not coded yet)
    public bool timerActive = false; //This bool is used to determine if the timer should be counting down or not
    [SerializeField] private float[] timer = new float[2]; //This is the timer, it is an array of 2 floats, the first is seconds, the second is minutes


    private void Start()
    {
        timer[0] = 0;
        timer[1] = 0;
    }
    private void Update()
    {
        TimerLogic();
    }


    private void TimerLogic()
    {
        if (timerActive)
        {
            timer[0] -= Time.deltaTime;
            if (timer[0] <= 0)
            {
                if (timer[1] <= 0)
                {
                    timerActive = false;
                    timer[0] = 0;
                    timer[1] = 0;
                }
                else
                {
                    timer[1]--;
                    timer[0] = 59;
                }

            }

        }
    }
    public string TimerDisplay()
    {
        string tempSeconds = Mathf.Round(timer[0]).ToString();
        string tempMinutes = Mathf.Round(timer[1]).ToString();
        if (tempSeconds.Length == 1)
        {
            tempSeconds = "0" + tempSeconds;
        }
        if (tempMinutes.Length == 1)
        {
            tempMinutes = "0" + tempMinutes;
        }

        return tempMinutes + ":" + tempSeconds;
    }



    // Buttons for the UI
    public void StartTimer()
    {
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
        timer[0] = 0;
        timer[1] = 0;
    }

    public void ZeroButton()
    {
        timer[0] = 0;
        timer[1] = 0;
    }
    public void TwentyFiveButton()
    {
        timer[0] = 25;
        timer[1] = 0;
    }

    public void PlusFiveButton()
    {
        timer[1] += 5;
    }

    public void PlusTenButton()
    {
        timer[1] += 10;
    }
}
