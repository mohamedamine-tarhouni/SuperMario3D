using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "item")
        {
            gameObject.GetComponent<changeCostume>().ChangeSkin(collision.gameObject.GetComponent<itemScript>().idItem);
            gameObject.GetComponent<PlayerController>().currentCostume = collision.gameObject.GetComponent<itemScript>().idItem;
            GameManager.Instance.updateScore(1000);
            Destroy(collision.gameObject);
        }
    }
}
