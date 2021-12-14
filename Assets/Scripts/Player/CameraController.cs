using System.Collections;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public GameObject player;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 temp = player.transform.position;
        temp.x = -10;
        transform.position = temp;
    }
}
