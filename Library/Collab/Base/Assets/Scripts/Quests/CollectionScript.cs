using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    //public int distanceToItem;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        scoringSystem.theScore += 1;
        Destroy(gameObject);
    }





    //void Collect()
    //{
    //    if(Input.GetMouseButtonUp(1))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if(Physics.Raycast(ray,out hit, distanceToItem))
    //        {
    //            if(gameObject)
    //            {
    //                Debug.Log("item hit");
    //                scoringSystem.theScore += 1;
    //                Destroy(gameObject);
    //            }
    //        }
    //    }
    //}
}