using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerTransfer : MonoBehaviourPun
{

    // Update is called once per frame
    void Update()
    {
        base.photonView.RequestOwnership();
    }
}
