using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HarpoonInteraction : MonoBehaviour
{
    public Transform target;
    private float _newTargetPositionX;
    private float _cameraAngleX;
    public Rigidbody harpoonPrefab;

    private Rigidbody _harpoon;
    private Transform _origin;

    private Transform _player;
    private Transform _camera;

    private Transform _originalParent;

    private bool _lockedIn;

    

    

    private void Start()
    {
        _origin = transform.GetChild(0);
        _harpoon = null;
        _player = GameObject.FindWithTag("Player").transform;
        _camera = GameObject.FindWithTag("MainCamera").transform;
        _originalParent = transform.parent;
    }

    private void FixedUpdate()
    {
        if (_harpoon == null || _harpoon.velocity == Vector3.zero) return;
        _harpoon.rotation = Quaternion.LookRotation(_harpoon.velocity);
        if (_harpoon.position.y <= _origin.position.y - 20)
        {
            Destroy(_harpoon.gameObject);
        }
    }

    private void Update()
    {
        if (!_lockedIn) return;
        _cameraAngleX = (_camera.rotation.eulerAngles.x + 540) % 360 - 180;
        _newTargetPositionX = _cameraAngleX - 25;
        target.localPosition = new Vector3(_newTargetPositionX, target.localPosition.y, target.localPosition.z);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_harpoon != null)
            {
                Destroy(_harpoon.gameObject);
            }

            Shoot(Mathf.Clamp(_newTargetPositionX / 10, .5f, 1.5f));
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            LockOut();
        }
    }

    public void LockIn()
    {
        Debug.Log("Harpoon locked in!");
        _player.GetComponent<PlayerMovement>().enabled = false;
        _camera.GetComponent<MouseLook>().harpooning = true;
        _player.position = new Vector3(transform.position.x + 1, _player.position.y, transform.position.z);
        _player.rotation = transform.rotation;
        _player.Rotate(0, -90, 0);
        transform.parent = _player;
        transform.tag = "Untagged";
        _lockedIn = true;
    }

    private void LockOut()
    {
        Debug.Log("Harpoon locked out!");
        _player.GetComponent<PlayerMovement>().enabled = true;
        _camera.GetComponent<MouseLook>().harpooning = false;
        _camera.position = new Vector3(_player.position.x, _camera.position.y, _player.position.z);
        transform.parent = _originalParent;
        transform.position = _originalParent.position;
        transform.rotation = _originalParent.rotation;
        transform.tag = "Selectable";
        _lockedIn = false;
    }
    
    public void Shoot(float time)
    {
        Vector3 calculatedVelocity = CalculateVelocity(time);
        //Rigidbody _harpoon = Instantiate(harpoonPrefab, _origin.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        _harpoon = Instantiate(harpoonPrefab, _origin.position, Quaternion.identity);
        _harpoon.velocity = calculatedVelocity;
        //_harpoon.rotation = Quaternion.LookRotation(_harpoon.velocity);
    }

    private Vector3 CalculateVelocity(float time)
    {
        Vector3 distance = target.position - transform.position;
        Vector3 distanceXZ = distance;
        // distanceXZ.Normalize();
        distanceXZ.y = 0f;

        float y = distance.y;
        float xz = distanceXZ.magnitude;

        float Vxz = xz / time;
        float Vy = y / time + .5f * Mathf.Abs(Physics.gravity.y) * time;

        // Vector3 result = distanceXZ * Vxz;
        // result.y = Vy;
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }
}