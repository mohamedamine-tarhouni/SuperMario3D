using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAbilities : MonoBehaviour
{    // Update is called once per frame
    private bool _canFire=true;
    [SerializeField]
    private float _fireRate;
    void Update()
    {
       int currentCostume = GetComponent<PlayerController>().currentCostume;
        switch (currentCostume)
        {
            case (1):
                if (Input.GetKeyUp(KeyCode.RightShift) && _canFire)
                {
                    GetComponent<shootFire>().shootFireBall();
                    StartCoroutine(setTimer());
                }
                break;

        }
    }
    IEnumerator setTimer()
    {
        _canFire = false;
        yield return new WaitForSeconds(1f / _fireRate);
        _canFire = true;
    }
}
