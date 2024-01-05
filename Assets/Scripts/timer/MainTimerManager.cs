using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MainTimerManager : MonoBehaviour
{
    public Transform playerPos;
    [SerializeField] private Button[] buttons = new Button[7];
    private Camera cam;
    [SerializeField] private Transform camAnch;
    private bool moveCam = false;
    private Vector3 oldCamVec;
    private quaternion oldCamRot;
    private float timer = 0f;
    [SerializeField] private float timerDuation = 1f;
    private float perc = 0f;
    private TimerScript timerScript;
    private bool inMenu = false;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        timerScript = GameObject.Find("GameManager").GetComponent<TimerScript>();
    }
    public void TimerEntrance()
    {
        MoveCamToAnchor();
    }

    private void MoveCamToAnchor()
    {
        oldCamVec = cam.transform.position;
        oldCamRot = cam.transform.rotation;

        cam.GetComponent<PlayerRotation>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        moveCam = true;

    }

    private void Update()
    {
        if (moveCam)
        {
            timer += Time.deltaTime;
            perc = timer / timerDuation;
            cam.transform.SetPositionAndRotation(Vector3.Lerp(oldCamVec, camAnch.position, perc), Quaternion.Lerp(oldCamRot, camAnch.rotation, perc));
            if (timer >= timerDuation)
            {
                moveCam = false;
                timer = 0f;
                foreach (Button button in buttons)
                {
                    button.interactable = true;
                }
                inMenu = true;
            }
        }
        if (inMenu)
        {
            if (timerScript.timerActive)
            {
                for (int i = 1; i < 6; i++)
                {
                    buttons[i].interactable = false;
                    buttons[0].interactable = true;
                }
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    buttons[i].interactable = true;
                    buttons[0].interactable = false;
                }
            }
        }
    }
    public void Return()
    {
        inMenu = false;
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        GameObject.Find("GameManager").GetComponent<Helper>().ReturnFromMenu("Timer");
    }

}
