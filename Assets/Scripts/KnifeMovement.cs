using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private WoodRotation woodRotation;
    
    [Header ("FX")]
    [SerializeField] private ParticleSystem woodFx;
    private ParticleSystem.EmissionModule _woodFxEmission;
    
    private Rigidbody _rigidbody;
    private Vector3 _movementVector;
    private bool _isMoving = false; 
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _woodFxEmission = woodFx.emission;
    }

    private void Update()
    {
        _isMoving = Input.GetMouseButton(0);
        
        if (_isMoving)
            _movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * (movementSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            _rigidbody.position += _movementVector;
    }

    private void OnCollisionExit(Collision collision)
    {
        _woodFxEmission.enabled = false;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        WoodCollider woodCollider = collision.collider.GetComponent<WoodCollider>();
        if (woodCollider != null)
        {
            _woodFxEmission.enabled = true ;
            woodFx.transform.position = collision.contacts[0].point ;
            
            woodCollider.HitCollider(hitDamage);
            woodRotation.Hit(woodCollider.index, hitDamage);
        }
    }

}
