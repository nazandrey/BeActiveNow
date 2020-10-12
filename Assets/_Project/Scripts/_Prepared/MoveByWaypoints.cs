using UnityEngine;

public class MoveByWaypoints : MonoBehaviour
{
    [SerializeField]
    private float closeEnoughDistance = 1f;
    
    private Vector2[] waypoints;
    private float speed = 0.1f;
    private bool waypointsInitialized = false;
    private int currentWaypoint = 0;
    
    private void Update()
    {
        if (waypoints.Length == 0 || !waypointsInitialized)
            return;        

        float step = speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, waypoints[currentWaypoint]) <= closeEnoughDistance)        
            currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint], step);        
    }

    public void SetWaypoints(Vector2[] waypoints)
    {
        this.waypoints = waypoints;
        waypointsInitialized = true;
        //По вейпоинтам движение гораздо меньше, чтобы было похоже, делим на константу
        //TODO: заменить настройки по уровням и убрать это
        speed /= 20;
    }

    public void SetSpeed(float NewSpeed)
    {
        speed = NewSpeed;
    }
}
