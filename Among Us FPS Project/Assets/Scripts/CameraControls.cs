using UnityEngine;
using Photon.Pun;

public class CameraControls : MonoBehaviourPunCallbacks
{
    public Transform CameraTransform;
    public Transform PlayerTransform;

    public GameObject Astronaut;

    Rigidbody rb;

    public float Sensitivity;

    float Yrotation;
    float Xrotation;
    void Update()
    {
        if (photonView.IsMine)
        {
            float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

            Yrotation = Yrotation + MouseY * -1;
            Xrotation = Xrotation + MouseX;

            Yrotation = Mathf.Clamp(Yrotation, -90, 90);

            PlayerTransform.localRotation = Quaternion.Euler(new Vector3(0, Xrotation, 0));
            CameraTransform.localRotation = Quaternion.Euler(new Vector3(Yrotation, 0, 0));
        }

        else
        {
            CameraTransform.gameObject.SetActive(false);
            Astronaut.layer = LayerMask.NameToLayer("Not Player");
            gameObject.layer = LayerMask.NameToLayer("Not Player");
        }
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Application.targetFrameRate = 60;

            rb = GetComponent<Rigidbody>();
        }

        DontDestroyOnLoad(gameObject);
    }
}
