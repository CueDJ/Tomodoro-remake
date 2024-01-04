using UnityEngine;

public class Helper : MonoBehaviour
{
    private string returnString;
    [SerializeField] private Transform[] anchors = new Transform[1];
    private Vector3 oldCamVec;
    private Quaternion oldCamRot;
    private Camera cam;
    private float perc = 0f;
    private float timer = 0f;
    [SerializeField] private float timerDuation = 2f;

    [SerializeField] GameObject player;
    private int anchorSelect = 0;

    private void Start()
    {
        cam = Camera.main;
    }
    public void ReturnFromMenu(string anchorString)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        oldCamRot = cam.transform.rotation;
        oldCamVec = cam.transform.position;
        if (anchorString == "Timer")
        {
            returnString = "Timer";
            anchorSelect = 0;
        }
        else { Debug.Log("Error: Anchor string not found"); }
    }
    private void Update()
    {
        if (returnString != null)
        {
            timer += Time.deltaTime;
            perc = timer / timerDuation;
            cam.transform.SetPositionAndRotation(Vector3.Lerp(oldCamVec, anchors[anchorSelect].position, perc), Quaternion.Lerp(oldCamRot, anchors[anchorSelect].rotation, perc));
            if (timer >= timerDuation)
            {
                returnString = null;
                timer = 0f;
                cam.GetComponent<PlayerRotation>().enabled = true;
                player.transform.position = anchors[anchorSelect].position;
                player.SetActive(true);
            }
        }
    }
}
