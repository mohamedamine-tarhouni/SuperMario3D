using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _initspeed = 1f;
    private float _speed;
    [SerializeField]
    private float _jumpForce = 250f;

    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    public Animator _anim;
    [SerializeField]
    private float _acceleration = 1;
    //private bool _isGrounded = true;
    private bool _isRunning = false;
    private bool _isJumping = false;
    [SerializeField]
    private LayerMask _mask;
    [SerializeField]
    private Transform footTransform;
    public int currentCostume;
    void Start()
    {
        currentCostume = 0;
        _speed = _initspeed;
    }
    void Update()
    {
        if (!MenuManager.Instance.isPaused && !MenuManager.Instance.isTuto)
        {
            float acceleration_value = 7;

            _isJumping = false;
            if (_isRunning && isGrounded())
            {
                acceleration_value = 14;
            }
            else if(!isGrounded())
            {
                acceleration_value = 9;
            }
            else
            {
                acceleration_value = 7;
            }
            float frameDependentSpeed = _speed * Time.deltaTime;
            //Debug.Log(frameDependentSpeed);
            //if (frameDependentSpeed > 4 && !_isRunning)
            //{
            //    frameDependentSpeed = 4;
            //}
            //else if (_isRunning && frameDependentSpeed > 5)
            //{
            //    frameDependentSpeed = 5;
            //}
            Vector3 dir = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.Q))
            {
                transform.rotation = Quaternion.LookRotation(-Vector3.right, Vector3.up);
                //_rb.AddForce(transform.forward * frameDependentSpeed);
                dir.z += 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
                //_rb.AddForce(transform.forward * frameDependentSpeed);
                dir.z += 1;
            }
            if (Input.GetKey(KeyCode.Z))
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
                //_rb.AddForce(transform.forward * frameDependentSpeed);
                dir.z += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.LookRotation(-Vector3.forward, Vector3.up);
                //_rb.AddForce(transform.forward * frameDependentSpeed);
                dir.z += 1;
            }
            if (Input.GetKeyDown(KeyCode.RightShift) && !_isJumping)
            {
                _isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                _isRunning = false;
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                _rb.AddForce(new Vector3(0, _jumpForce, 0));
                _anim.SetTrigger("jump");
                _isJumping = true;
                AudioManagerScript.Instance.playMarioJump();
            }
            dir = dir.x * transform.right + dir.z * transform.forward;
            dir *= frameDependentSpeed;
            Vector3 TargetVelocity = new Vector3(dir.x * (2 + acceleration_value), _rb.velocity.y, dir.z * (2 + acceleration_value));
            //Vector3 TargetVelocity = new Vector3(dir.x , _rb.velocity.y, dir.z);
            //Debug.Log(acceleration_value);
            //Debug.Log(TargetVelocity.x);
            _rb.velocity = Vector3.Lerp(_rb.velocity, TargetVelocity, Time.deltaTime * _acceleration);
            if (_rb.velocity.y < 0)
            {
                _rb.velocity += Vector3.up * Physics.gravity.y * 5 * Time.deltaTime;
            }
            //_rb.velocity=Vector3.ClampMagnitude(new Vector3(_rb.velocity.x,0,_rb.velocity.z), acceleration_value);
            Vector3 clampVel = _rb.velocity;
            clampVel.z = Mathf.Clamp(clampVel.z, -acceleration_value, acceleration_value);
            clampVel.x = Mathf.Clamp(clampVel.x, -acceleration_value, acceleration_value);
            _rb.velocity = clampVel;
            _anim.SetFloat("speed", Mathf.Abs(_rb.velocity.x + _rb.velocity.z));
            _anim.SetBool("isRunning", _isRunning);
            _anim.SetBool("isJumping", _isJumping);
            _anim.SetBool("isFalling", !isGrounded());
        }
        

    }
    private bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.BoxCast(footTransform.position, new Vector3(0.5f, 0.5f, 0.5f), Vector3.down, out hit, Quaternion.identity, 0.5f, _mask))
        {
            return true;
        };
        return false;
    }
}
