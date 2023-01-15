using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class blockScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _item;
    [SerializeField]
    private UnityEvent _blockEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManagerScript.Instance.playBumpSound();
            _blockEvent.Invoke();
            spawnItem();
        }
    }
    private void spawnItem()
    {
        if (_item != null)
        {
        GameObject item = Instantiate(_item);
        item.transform.position = transform.position;
            //item.transform.rotation = ;
            if (item.tag != "Coin")
            {
                AudioManagerScript.Instance.playPowerUpOut();
            item.transform.position += new Vector3(0, 1,-2);
            }
            else
            {
                GameManager.Instance.updateCoins();
                Destroy(item);
            }
        }
            _item = null;
    }
}
