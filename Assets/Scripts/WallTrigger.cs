using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.rotation = Quaternion.Euler(0, other.transform.rotation.eulerAngles.y * -1, 0);
        }
    }
}
