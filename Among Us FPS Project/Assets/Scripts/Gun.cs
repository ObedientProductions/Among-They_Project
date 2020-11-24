using Photon.Pun;
using UnityEngine;

public class Gun : MonoBehaviourPunCallbacks
{
    public static Vector3[] ListOfSpawnPoints = { new Vector3(3.07f, 3.359f, 40.72f), new Vector3(-19.1f, 3.359f, -57.9f), new Vector3(-70.8f, 3.359f, -13.4f), new Vector3(27.4f, 3.359f, -14.2f) };

    public static int SelectedCharacter = 0;

    float HealthAmount = 100;

    public Transform gun;
    public Transform HoldingPlace;
    public Transform CameraTransform;
    public Transform Spine;
    public Transform Player;
    public Transform PlayerParent;
    public Transform Astronaut;

    public AudioSource AudioPlayer;

    public GameObject RagDollRed, RagDollBlue, RagDollBlack, RagDollYellow;
    public GameObject BloodSplat;

    public Transform BulletPoint;

    public Animator GunAnimator;

    public ParticleSystem MussleFlash;

    public PhotonView PV;

    RaycastHit hit;

    PhotonView TargetView;
    void Update()
    {
        if (PV.IsMine)
        {
            gun.position = HoldingPlace.position;

            sliderStuff.HealthBar.value = HealthAmount / 100;

            if (Input.GetMouseButtonDown(0))
            {
                photonView.RPC("FireGun", RpcTarget.All);

                if (Physics.Raycast(BulletPoint.position, CameraTransform.forward, out hit))
                {
                    HitMarker.HitTarget = true;

                    if (hit.transform.gameObject.layer == 10)
                    {
                        Debug.Log(hit.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(1).GetChild(0).GetChild(0));
                        TargetView = hit.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<PhotonView>();
                        HitMarker.HitMarkerAnimator.Play("HitMarker_Hit");
                        TargetView.RPC("TakeDamage", RpcTarget.All, 10f, hit.point, Player.localEulerAngles);

                        if (TargetView == null) { }

                        else 
                        {
                            if (hit.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<Gun>().HealthAmount == 0)
                            {
                                MatchManager.Eliminations = MatchManager.Eliminations + 1;
                                TargetView.RPC("SpawnRagDoll", RpcTarget.All);
                            }
                        }
                    }

                    else 
                    {
                        PhotonNetwork.Instantiate("WhiteSmoke", hit.point, Quaternion.LookRotation(hit.normal));

                    }
                }
            }
        }

        else
        {
            gun.position = HoldingPlace.position;

            if (HealthAmount <= 0)
            {
                
            }
        }
    }

    private void LateUpdate()
    {
        if (HealthAmount == 0)
        {
            photonView.RPC("Die", RpcTarget.All);
        }
    }

    private void Start()
    {
        if(PV.IsMine)
        {
            //PV.RPC("SETCHAR", RpcTarget.All);
        }

        else 
        {
            HoldingPlace.parent = Spine;
        }
    }

    [PunRPC]
    void TakeDamage(float Damage, Vector3 HitPoint, Vector3 HitRotation) 
    {
        Instantiate(BloodSplat, HitPoint, Quaternion.Euler(HitRotation));
        HealthAmount = HealthAmount - Damage;
    }

    [PunRPC]
    void FireGun() 
    {
        GunAnimator.Play("Shoot");
        MussleFlash.Play();
        AudioPlayer.Play();
    }

    bool Dead = false;
    [PunRPC]
    void Die() 
    {
        Dead = true;
        if (Dead)
        {

            Astronaut.gameObject.SetActive(false);
            Player.GetComponent<Movement>().enabled = false;

            photonView.RPC("Respawn", RpcTarget.All);
            Dead = false;
        }
    }

    [PunRPC]
    void Respawn() 
    {
        Astronaut.gameObject.SetActive(true);
        Player.GetComponent<Movement>().enabled = true;
        HealthAmount = 100f;

        if (PV.IsMine)
        {
            PlayerParent.position = ListOfSpawnPoints[Random.Range(0, 4)];
        }
    }

    [PunRPC]
    void SpawnRagDoll() 
    {
        if (PlayerParent.name == "Player Red(Clone)")
        {
            Instantiate(RagDollRed, PlayerParent.position, Player.rotation);
        }

        if (PlayerParent.name == "Player Blue(Clone)")
        {
            Instantiate(RagDollBlue, PlayerParent.position, Player.rotation);
        }

        if (PlayerParent.name == "Player Black(Clone)")
        {
            Instantiate(RagDollBlack, PlayerParent.position, Player.rotation);
        }

        if (PlayerParent.name == "Player Yellow(Clone)")
        {
            Instantiate(RagDollYellow, PlayerParent.position, Player.rotation);
        }
    }
}
