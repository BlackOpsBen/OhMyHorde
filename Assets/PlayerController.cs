using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
}
