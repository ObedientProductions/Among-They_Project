using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviourPunCallbacks
{
    public static bool Grounded = false;

    public float JumpForce;
    float Speed = 18;

    public Rigidbody rb;
    public Transform GroundCheck;
    public LayerMask GroundMask;

    float GroundDistance = 0.6f;

    float VelZ;
    float VelX;

    private void Update()
    {
        //MOVMENT
        VelZ = Input.GetAxis("Vertical") * Speed;
        VelX = Input.GetAxis("Horizontal") * Speed;
    }
    void FixedUpdate()
    {

        if (photonView.IsMine)
        {
            rb.velocity = transform.TransformDirection(new Vector3(VelX, rb.velocity.y, VelZ));

            //JUMP
            if (Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
                }

                Grounded = true;
            }

            else
            {
                Grounded = false;
            }
        }
    }
}
