using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public Chest herst;

    public void TriggerChest()
    {
        FindObjectOfType<ChestMeneger>().Button—hest(herst);
    }

}
