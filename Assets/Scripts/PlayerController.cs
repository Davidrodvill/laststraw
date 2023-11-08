using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    [SerializeField] float _speed;
    public bool canMove = true;
    Rigidbody2D _rb;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (!canMove)
        {
            return;
        }
    }
}
