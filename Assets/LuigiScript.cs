using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuigiScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Animator _anim;

    // Update is called once per frame
    void Update()
    {
        Vector3 clampVel = _rb.velocity;
        clampVel.z = Mathf.Clamp(clampVel.z, 0, 0);
        clampVel.x = Mathf.Clamp(clampVel.x, 0, 0);
        _anim.SetFloat("speed", 0);

    }
}
