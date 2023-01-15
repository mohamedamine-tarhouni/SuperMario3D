using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineScript : MonoBehaviour
{
    [SerializeField]
    private float _bumpForce = 100;
    private void OnCollisionEnter(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>()._anim.SetTrigger("jump");
            AudioManagerScript.Instance.playMarioHighJump();
        }
        collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * _bumpForce * 2);
    }
}
