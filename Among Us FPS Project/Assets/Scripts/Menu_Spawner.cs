using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Spawner : MonoBehaviour
{
    public GameObject RagDollRed, RagDollBlue, RagDollBlack, RagDollYellow;

    public GameObject[] ListOfRagDolls = { null, null, null, null };

    private void Start()
    {
        ListOfRagDolls[0] = RagDollRed;
        ListOfRagDolls[1] = RagDollBlue;
        ListOfRagDolls[2] = RagDollBlack;
        ListOfRagDolls[3] = RagDollYellow;

        Instantiate(ListOfRagDolls[Random.Range(0,4)], new Vector3(Random.Range(-71.4f, 65f), transform.position.y, Random.Range(9f, 104.6f)), new Quaternion(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), transform.parent);
    }
}
