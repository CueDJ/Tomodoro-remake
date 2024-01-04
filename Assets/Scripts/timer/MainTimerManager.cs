using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MainTimerManager : MonoBehaviour
{
    public Transform playerPos;
    [SerializeField] private Button[] buttons = new Button[7];
    private new Camera camera;
    [SerializeField] private Transform camAnch;
    private bool moveCam = false;
    private Vector3 oldCamVec;
    private quaternion oldCamRot;
    private float timer = 0f;
    [SerializeField] private float timerDuation = 1f;
    [SerializeField] private float perc = 0f;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void TimerEntrance()
    {
        MoveCamToAnchor();
    }

    private void MoveCamToAnchor()
    {
        oldCamVec = camera.transform.position;
        oldCamRot = camera.transform.rotation;

        camera.GetComponent<PlayerRotation>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        moveCam = true;
    }

    private void Update()
    {
        if (moveCam)
        {
            timer += Time.deltaTime;
            perc = timer / timerDuation;
            camera.transform.SetPositionAndRotation(Vector3.Lerp(oldCamVec, camAnch.position, perc), Quaternion.Lerp(oldCamRot, camAnch.rotation, perc));
            if (timer >= 1f)
            {
                moveCam = false;
                timer = 0f;
                foreach (Button button in buttons)
                {
                    button.interactable = true;
                }
            }
        }
    }


}
