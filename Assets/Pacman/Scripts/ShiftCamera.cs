using UnityEngine;
using System.Collections;

public class ShiftCamera : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;

    bool ChangeCamera = true;

    void Start ()
    {
        Camera1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {

            Camera2.gameObject.SetActive(false);
            Camera1.gameObject.SetActive(true);
            ChangeCamera = false;

        }
        else
        {
            Camera1.gameObject.SetActive(false);
            Camera2.gameObject.SetActive(true);
            ChangeCamera = true;
        }
    }
}
