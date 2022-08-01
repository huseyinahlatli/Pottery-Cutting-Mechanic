using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollider : MonoBehaviour
{
    public int index;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        index = transform.GetSiblingIndex();
    }

    public void HitCollider(float damage)
    {
        if (_boxCollider.size.y - damage > 0.0f)
        {
            var size = _boxCollider.size;
            size = new Vector3(size.x, size.y - damage, size.z);
            _boxCollider.size = size;
        } 
        else
            Destroy(this);
    }
}
