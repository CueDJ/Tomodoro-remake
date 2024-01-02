using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private Transform playerOrientation;
    private Camera cam;
    [SerializeField] private float CamOffset = 0.5f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerOrientation = gameObject.GetComponent<Transform>();
        cam = Camera.main;
    }

    void Update()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + CamOffset, transform.position.z);
        transform.rotation = Quaternion.Euler(0f, cam.transform.rotation.eulerAngles.y, 0f);

        // Move the player
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 8.0f;
        }
        else
        {
            playerSpeed = 4.0f;
        }
        Vector3 move = playerOrientation.forward * Input.GetAxis("Vertical") + playerOrientation.right * Input.GetAxis("Horizontal");
        controller.Move(playerSpeed * Time.deltaTime * move);



        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}