using System;
using System.Collections;
using UnityEngine;

public class MyPlayer : Player
{
    NetworkManager netManager;

    private void Start()
    {
        netManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        StartCoroutine("CoSendPacket");
    }


    IEnumerator CoSendPacket()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            
            C_Move movePacket = new C_Move();
            movePacket.posX = UnityEngine.Random.Range(-50, 50);
            movePacket.posY = 1;
            movePacket.posZ = UnityEngine.Random.Range(-50, 50);
            
            netManager.Send(movePacket.Write());
        }
    }
}
