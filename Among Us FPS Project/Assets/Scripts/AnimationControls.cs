using Photon.Pun;
using UnityEngine;

public class AnimationControls : MonoBehaviourPunCallbacks
{
    public Transform CameraTransform;
    public Transform Spine;

    Animator PlayerAnimator;
    Rigidbody rb;

    public AudioSource AudioPlayer;

    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    float CameraX;
    void Update()
    {
        if (photonView.IsMine)
        {
            //Move Spine With Camera
            CameraX = CameraTransform.rotation.eulerAngles.x;
            //Debug.Log(Movement.Grounded);

            Spine.localEulerAngles = new Vector3(CameraX, 0, 0);


            //Play Animations
            PlayWalkingAnimation();
            PlayAnimation("Is Jumping", Movement.Grounded);
        }
    }


    //FUNCTIONS
    bool AnimationCalled;
    void PlayAnimation(string AnimationName, bool PlayIfThisTrue)
    {

        if (PlayIfThisTrue == true)
        {
            if (AnimationCalled == true)
            {
                PlayerAnimator.SetBool(AnimationName, false);
                AnimationCalled = false;
            }
        }

        else
        {
            if (AnimationCalled == false)
            {
                PlayerAnimator.SetBool(AnimationName, true);
                AnimationCalled = true;
            }
        }
    }


    bool IsPlaying = false;
    void PlayWalkingAnimation() 
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (IsPlaying == true)
            {
                PlayerAnimator.SetBool("Is Walking", true);

                IsPlaying = false;
            }
        }

        else
        {
            if (IsPlaying == false)
            {
                PlayerAnimator.SetBool("Is Walking", false);
                IsPlaying = true;
            }
        }
    }
}
