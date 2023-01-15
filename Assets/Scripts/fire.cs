using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private LayerMask _mask;
    [SerializeField]
    private Transform footTransform;
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
        Destroy(gameObject, 5);
        if (isGrounded())
        {
            //_rb.AddForce(transform.up * 5);
            Vector3 gravity = 120 * Vector3.down; //cant simulate fireball bounces with normal realworld gravity, so i ad a downwards force that i can change from script, simulating gravity for fireball only
            _rb.AddForce(gravity, ForceMode.Acceleration);

        //    if (_rb.velocity.y < 0)
        //{
        //    _rb.velocity += Vector3.up * Physics.gravity.y * 2 * Time.deltaTime;
        //}
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _speed = -_speed;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    _rb.AddForce(transform.up * 75);
    //}
    private bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.BoxCast(footTransform.position, new Vector3(0.5f, 0.5f, 0.5f), Vector3.down, out hit, Quaternion.identity, 1.0f, _mask))
        {
            return true;
        };
        return false;
    }
    //private Rigidbody rb;

    //public Vector3 velocity;
    //// Use this for initialization
    //void Start()
    //{

    //    rb = GetComponent<Rigidbody>();
    //    velocity = rb.velocity;


    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 gravity = 120 * Vector3.down; //cant simulate fireball bounces with normal realworld gravity, so i ad a downwards force that i can change from script, simulating gravity for fireball only
    //    rb.AddForce(gravity, ForceMode.Acceleration);

    //    if (rb.velocity.y < velocity.y) //to avoid arcs formed when mario initially shoots fireball
    //    {
    //        rb.velocity = velocity;
    //    }




    //}


    //void OnCollisionEnter(Collision col)
    //{

    //    if (col.contacts[0].normal.y > 0.4 && col.contacts[0].normal.y < 1.6)
    //    {
    //        rb.velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
    //    }

    //    //reflect
    //    if (col.contacts[0].normal.x > 0.3 || col.contacts[0].normal.z > 0.3f || col.contacts[0].normal.x < -0.3f || col.contacts[0].normal.z < -0.3f)
    //    {
    //        Vector3 oldVel = velocity;
    //        oldVel = oldVel.normalized;
    //        oldVel *= 1900 * Time.deltaTime;

    //        Vector3 newvel = Vector3.Reflect(oldVel, col.contacts[0].normal);

    //        velocity = new Vector3(newvel.x, oldVel.y, newvel.z);
    //        //rb.velocity = rb.velocity;
    //    }

    //}
    //public IEnumerator Destroy()
    //{
    //    transform.GetComponent<MeshRenderer>().enabled = false;
    //    transform.GetComponent<SphereCollider>().enabled = false;
    //    transform.GetComponent<ParticleSystem>().Stop();
    //    GameObject Dissolve = transform.GetChild(0).gameObject;
    //    GameObject Clone = Instantiate(Dissolve, transform.position, Dissolve.transform.rotation);
    //    Clone.GetComponent<ParticleSystem>().Play();
    //    Destroy(Clone, 5);
    //    yield return new WaitForSeconds(1);
    //    Destroy(gameObject);
    //}
}
