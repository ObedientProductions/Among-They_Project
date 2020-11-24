using UnityEngine;
using Photon.Pun;

public class PickUp : MonoBehaviourPunCallbacks
{
    public Camera FPSCam;
    public Transform HoldingTransform;

    Transform Item;
    Rigidbody ItemRB;
    Collider ItemColider;

    bool HasItem;
    RaycastHit hit;

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                photonView.RPC("Pickup", RpcTarget.All);
                Debug.Log(photonView.ViewID);
            }


            if (HasItem)
            {
                photonView.RPC("ConstraintItem", RpcTarget.All);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    photonView.RPC("DropItem", RpcTarget.All);
                }
            }
        }
    }

    [PunRPC]
    public void Pickup()
    {
        if (photonView.IsMine)
        {
            if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit))
            {
                if (hit.transform.tag == "Consumable")
                {
                    ItemRB = hit.transform.GetComponent<Rigidbody>();
                    ItemColider = hit.transform.GetComponent<Collider>();

                    hit.transform.parent = HoldingTransform;
                    hit.transform.position = HoldingTransform.position;

                    Item = hit.transform;
                    HasItem = true;
                }
            }
        }

        else 
        {
            

            
        }
    }

    [PunRPC]
    public void ConstraintItem() 
    {
        if (photonView.IsMine)
        {
            Item.position = HoldingTransform.position;
            Item.localEulerAngles = Vector3.zero;
            ItemRB.angularVelocity = Vector3.zero;
            ItemRB.velocity = Vector3.zero;
            ItemRB.useGravity = false;
            ItemColider.enabled = false;
        }
    }

    [PunRPC]
    public void DropItem() 
    {
            HasItem = false;
            ItemColider.enabled = true;
            ItemRB.useGravity = true;

            Item.transform.parent = null;
    }
}
