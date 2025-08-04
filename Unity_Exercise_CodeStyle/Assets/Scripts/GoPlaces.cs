using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    private Transform[] _places;
    private Transform _allPlacesPoint;
    private float _speed;
    private int _numberOfPlaceInPlaces;

    void Start()
    {
        _places = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _places[i] = _allPlacesPoint.GetChild(i);
    }
    
    public void Update()
    {
        Transform pointByNumberInArray = _places[_numberOfPlaceInPlaces];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position) 
            NextPlaceTakerLogic();
    }

    public Vector3 NextPlaceTakerLogic()
    {
        _numberOfPlaceInPlaces++;

        if (_numberOfPlaceInPlaces == _places.Length)
            _numberOfPlaceInPlaces = 0;

        Vector3 thisPoint = _places[_numberOfPlaceInPlaces].transform.position;
        transform.forward = thisPoint - transform.position;
        return thisPoint;
    }
}