using UnityEngine;

public class Helper : MonoBehaviour
{
    private string returnString;
    [SerializeField] private Transform[] anchors = new Transform[1];
    [SerializeField] private Transform[] oldAnchors = new Transform[1];
    private Camera cam;
    private float perc = 0f;
    private float timer = 0f;
    [SerializeField] private float timerDuation = 2f;

    private void Start()
    {
        cam = Camera.main;
    }
    public void ReturnFromMenu(string hey)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (hey == "Timer")
        {
            returnString = "Timer";
        }
    }
    private void Update()
    {
        while (returnString != null)
        {
            if (returnString == "Timer")
            {
                timer += Time.deltaTime;
                perc = timer / timerDuation;
                cam.transform.SetPositionAndRotation(Vector3.Lerp(oldAnchors[0].position, anchors[0].position, perc), Quaternion.Lerp(oldAnchors[0].rotation, anchors[0].rotation, perc));
                if (timer >= timerDuation)
                {
                    returnString = null;
                    timer = 0f;
                }
            }
        }
    }
}
