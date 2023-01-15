using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed;
    // Start is called before the first frame update
    void Update()
    {
            transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>().tag == "Player")
        {
            GameManager.Instance.updateCoins();
            Destroy(gameObject);
        }
    }
}
