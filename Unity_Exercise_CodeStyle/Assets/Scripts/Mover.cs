using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _allWayoints;
    [SerializeField] private float _speed;

    private int _currentWaypointIndex;

    void Start()
    {
        _waypoints = new Transform[_allWayoints.childCount];

        for (int i = 0; i < _allWayoints.childCount; i++)
            _waypoints[i] = _allWayoints.GetChild(i);
    }

    public void Update()
    {
        Transform currentWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
    }
}