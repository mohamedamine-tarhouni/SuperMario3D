using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCostume : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer[] renderers;
    [SerializeField]
    private Material[] Skins;
    // Start is called before the first frame update
    public void ChangeSkin(int id)
    {
        if (GetComponent<PlayerController>().currentCostume != id)
        {
            AudioManagerScript.Instance.playgetPowerUp();
        }
        
        for (int i = 0; i < renderers.Length; i++)
        {

            renderers[i].material = Skins[id];
        }
    }

}
