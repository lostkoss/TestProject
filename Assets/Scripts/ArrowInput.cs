using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInput : MonoBehaviour
{
    [SerializeField] public GameObject arrowPrefab;
    GameObject arrowGO;

    public BallMoover ballComponent;

    bool firstTouch;

    float minScale;
    float maxScale;

    public float more;
    public float low;

    public float rot_z;
    public float zpoc;
    void Start()
    {
        minScale = 0.3f;
        maxScale = 1f;


        firstTouch = true;
        arrowGO = Instantiate(arrowPrefab);
        arrowGO.GetComponent<Transform>().rotation = Quaternion.Euler(90, 0, 0);
        arrowGO.SetActive(false);
    }

    void Update()
    {
        if (!ballComponent.isMooving)
        {

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 pos = touch.position;
                pos.z = 20;
                pos = Camera.main.ScreenToWorldPoint(pos);


                if (firstTouch)
                {
                    arrowGO.SetActive(true);
                    firstTouch = false;
                }

                ChangeArrowAngle(pos);

                ChangeArrowScale(pos);

            }
            else if (!firstTouch)
            {
                firstTouch = true;
                ballComponent.SetDirection(arrowGO.transform.rotation.eulerAngles.y);
                ballComponent.SetSpeed(arrowGO.transform.localScale.x);
                ballComponent.isMooving = true;
                arrowGO.SetActive(false);

            }
        }

    }
    private void ChangeArrowScale(Vector3 pos)
    {
        arrowGO.transform.localScale = new Vector3(Mathf.Clamp(
                   Vector3.Distance(arrowGO.transform.position, pos) / 10, minScale, maxScale),
                   Mathf.Clamp(Vector3.Distance(arrowGO.transform.position, pos) / 10, minScale, maxScale));
    }
    private void ChangeArrowAngle(Vector3 pos)
    {
        if(pos.z > arrowGO.transform.position.z)
        {
        Vector3 diff = pos - arrowGO.transform.position;

         rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        arrowGO.transform.rotation = Quaternion.Euler(90, 0, rot_z);

        }
        else
        {
            if (pos.x > arrowGO.transform.position.x)
            {
                pos.z += Mathf.Abs(pos.z - arrowGO.transform.position.z) * 2;
                pos.x -= Mathf.Abs(pos.x - arrowGO.transform.position.x) * 2;
                Vector3 diff = pos - arrowGO.transform.position;

                rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                arrowGO.transform.rotation = Quaternion.Euler(90, 0, -rot_z );

            }
            else
            {
                pos.z += Mathf.Abs(pos.z - arrowGO.transform.position.z) * 2;
                pos.x += Mathf.Abs(pos.x - arrowGO.transform.position.x) * 2;
                Vector3 diff = pos - arrowGO.transform.position;

                rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

                arrowGO.transform.rotation = Quaternion.Euler(90, 0, -rot_z);

            }
        }
        zpoc = arrowGO.transform.rotation.eulerAngles.z % 90;

    }
}
