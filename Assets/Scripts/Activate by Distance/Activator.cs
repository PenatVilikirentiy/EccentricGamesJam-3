using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate;
    public Transform PlayerTransform;

    private void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(PlayerTransform.position);
        }
    }


}
