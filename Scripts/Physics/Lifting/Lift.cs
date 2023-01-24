using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private List<Liftable> liftingObjects = new List<Liftable>();
    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Lift");
    }

    private void OnTriggerEnter(Collider other)
    {
        var liftable = other.GetComponent<Liftable>();

        if (liftable == null)
            return;
        
        liftable.BeginLift(transform);
        liftingObjects.Add(liftable);

    }

    private void OnTriggerExit(Collider other)
    {
        var liftable = liftingObjects.Find(ctg => ctg.transform == other.transform);
        if (liftable == null)
            return;
        liftable.EndLift();
        liftingObjects.Remove(liftable);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var liftable = col.GetComponent<Liftable>();

        if (liftable == null)
            return;
        
        liftable.BeginLift(transform);
        liftingObjects.Add(liftable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var liftable = liftingObjects.Find(ctg => ctg.transform == other.transform);
        if (liftable == null)
            return;
        liftable.EndLift();
        liftingObjects.Remove(liftable);
    }
}
