using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUP : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            

            if (Mathf.Abs(other.transform.rotation.eulerAngles.y % 90) <= 45)
            {

                other.transform.rotation = Quaternion.Euler(0, other.transform.rotation.eulerAngles.y + 90, 0);
            }
            else
            {
                other.transform.rotation = Quaternion.Euler(0, other.transform.rotation.eulerAngles.y - 90, 0);
            }
            
        }
    }

    
}
