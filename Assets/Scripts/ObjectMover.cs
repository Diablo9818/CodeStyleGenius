using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacespoint;

    private Transform[] _arrayPlaces;
    private int _numberOfPlaceInArrayPlaces;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _allPlacespoint.childCount; i++)
        {
            _arrayPlaces[i] = _allPlacespoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var pointByNumberInArray = _arrayPlaces[_numberOfPlaceInArrayPlaces];
        transform.position = Vector3.MoveTowards(
            transform.position,
            pointByNumberInArray.position,
            _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
        {
            MoveToPoint();
        }
    }

    private Vector3 MoveToPoint()
    {
        _numberOfPlaceInArrayPlaces++;

        if (_numberOfPlaceInArrayPlaces == _arrayPlaces.Length)
        {
            _numberOfPlaceInArrayPlaces = 0;
        }

        var thisPointVector = _arrayPlaces[_numberOfPlaceInArrayPlaces].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}
