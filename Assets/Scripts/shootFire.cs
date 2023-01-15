using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFire : MonoBehaviour
{
    // Start is called before the first frame update
    //public static fire Instance;
    [SerializeField]
    private GameObject _FireBall;
    [SerializeField]
    private Transform SpawnFire;
    public void shootFireBall()
    {
        Debug.Log("FIRE");
        GameObject fireBall = Instantiate(_FireBall);
        fireBall.transform.position = SpawnFire.position;
        fireBall.transform.forward = transform.forward;
    }
}
