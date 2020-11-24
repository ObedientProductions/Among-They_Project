using UnityEngine;
using UnityEngine.UI;

public class RagdollMenu : MonoBehaviour
{
    float Timepast = 0;

    public Transform Head , LeftLeg, LeftKnee, RightLeg, RightKnee, Spine, Hips, Astronaut;

    Rigidbody Headrb, LeftLegrb, LeftKneerb, RightLegrb, RightKneerb, Spinerb, Hipsrb;
    void Update()
    {
        transform.position = Astronaut.position;

        Timepast = Timepast + Time.deltaTime;

        if(Timepast >= 7f) 
        {
            DisableRigidbodys(Headrb, LeftLegrb, LeftKneerb, RightLegrb, RightKneerb, Spinerb, Hipsrb);
        }
    }

    private void Start()
    {

        //Get Rigidbodys
        Headrb = Head.GetComponent<Rigidbody>();
        LeftLegrb = LeftLeg.GetComponent<Rigidbody>();
        LeftKneerb = LeftKnee.GetComponent<Rigidbody>();
        RightLegrb = RightLeg.GetComponent<Rigidbody>();
        RightKneerb = RightKnee.GetComponent<Rigidbody>();
        Spinerb = Spine.GetComponent<Rigidbody>();
        Hipsrb = Hips.GetComponent<Rigidbody>();

    }

    private void DisableRigidbodys(Rigidbody InputColider1, Rigidbody InputColider2, Rigidbody InputColider3, Rigidbody InputColider4, Rigidbody InputColider5, Rigidbody InputColider6, Rigidbody InputColider7)
    {
        InputColider1.useGravity = false;
        InputColider2.useGravity = false;
        InputColider3.useGravity = false;
        InputColider4.useGravity = false;
        InputColider5.useGravity = false;
        InputColider6.useGravity = false;
        InputColider7.useGravity = false;
    }
}
