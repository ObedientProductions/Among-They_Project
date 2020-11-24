using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    float Timepast = 0;

    public Transform Head , LeftLeg, LeftKnee, RightLeg, RightKnee, Spine, Hips;

    Collider HeadCol, LeftLegCol, LeftKneeCol, RightLegCol, RightKneeCol, SpineCol, HipsCol;
    Rigidbody Headrb, LeftLegrb, LeftKneerb, RightLegrb, RightKneerb, Spinerb, Hipsrb;
    void Update()
    {
        Timepast = Timepast + Time.deltaTime;

        if(Timepast >= 5f) 
        {
            DisableColiders(HeadCol, LeftLegCol, LeftKneeCol, RightLegCol, RightKneeCol, SpineCol, HipsCol);
            DisableRigidbodys(Headrb, LeftLegrb, LeftKneerb, RightLegrb, RightKneerb, Spinerb, Hipsrb);

            transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f * Time.deltaTime, transform.position.z);

            if (Timepast >= 20f)
            {
                Destroy(gameObject);
                Timepast = 0;
            }
        }
    }

    private void Start()
    {
        //Get Coliders
        HeadCol = Head.GetComponent<Collider>();
        LeftLegCol = LeftLeg.GetComponent<Collider>();
        LeftKneeCol = LeftKnee.GetComponent<Collider>();
        RightLegCol = RightLeg.GetComponent<Collider>();
        RightKneeCol = RightKnee.GetComponent<Collider>();
        SpineCol = Spine.GetComponent<Collider>();
        HipsCol = Hips.GetComponent<Collider>();

        //Get Rigidbodys
        Headrb = Head.GetComponent<Rigidbody>();
        LeftLegrb = LeftLeg.GetComponent<Rigidbody>();
        LeftKneerb = LeftKnee.GetComponent<Rigidbody>();
        RightLegrb = RightLeg.GetComponent<Rigidbody>();
        RightKneerb = RightKnee.GetComponent<Rigidbody>();
        Spinerb = Spine.GetComponent<Rigidbody>();
        Hipsrb = Hips.GetComponent<Rigidbody>();
    }

    private void DisableColiders(Collider InputColider1, Collider InputColider2, Collider InputColider3, Collider InputColider4, Collider InputColider5, Collider InputColider6, Collider InputColider7)
    {
        InputColider1.enabled = false;
        InputColider2.enabled = false;
        InputColider3.enabled = false;
        InputColider4.enabled = false;
        InputColider5.enabled = false;
        InputColider6.enabled = false;
        InputColider7.enabled = false;
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
