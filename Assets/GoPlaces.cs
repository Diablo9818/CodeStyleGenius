using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
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
        var _pointByNumberInArray = _arrayPlaces[_numberOfPlaceInArrayPlaces];
        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position)
        {
            NextPlaceTakerLogic();
        }
    }

    private Vector3 NextPlaceTakerLogic()
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
