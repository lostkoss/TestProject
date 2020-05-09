using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
   public  GameHandler gameHandler;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameHandler.DeactivateBlocks(this.gameObject);
            other.GetComponent<BallMoover>().SetDefaultPosition();
           // gameObject.SetActive(false);
        }
    }
}
