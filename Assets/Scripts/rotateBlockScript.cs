using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlockScript : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed_Z;    
    [SerializeField]
    private float _rotationSpeed_X;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-_rotationSpeed_X * Time.deltaTime, 0, -_rotationSpeed_Z * Time.deltaTime));
    }
}
