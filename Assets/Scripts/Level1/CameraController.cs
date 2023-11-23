using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject _player; //player reference
    Vector3 _offset; //distance between player and camera
    public float minX, maxX, minY, maxY;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player");

        //offset = the difference in player position and camera position
        //_offset = _player.transform.position - transform.position;

        _offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera position = offset + player position
        transform.position = _offset + _player.transform.position;

        //track player position
        Vector3 pos = _offset + _player.transform.position;

        //only follow up to max/min x and y
        if (pos.x > maxX)
            pos = new Vector3(maxX, pos.y, pos.z);
        if (pos.x < minX)
            pos = new Vector3(minX, pos.y, pos.z);
        if (pos.y > maxY)
            pos = new Vector3(pos.x, maxY, pos.z);
        if (pos.y < minY)
            pos = new Vector3(pos.x, minY, pos.z);

        transform.position = pos;

        /*
        //camera position = player position - offset
        transform.position = _player.transform.position - _offset;

        //camera position = offset + player position
        transform.position = _offset + _player.transform.position;

        //track player position
        Vector3 pos = _offset + _player.transform.position;

        //only follow up to max/min x and y
        if (pos.x > maxX)
            pos = new Vector3(maxX, pos.y, pos.z);
        if (pos.x < minX)
            pos = new Vector3(minX, pos.y, pos.z);
        if (pos.y > maxY)
            pos = new Vector3(pos.x, maxY, pos.z);
        if (pos.y < minY)
            pos = new Vector3(pos.x, minY, pos.z);

        transform.position = pos;
        */
    }
}
