using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Get { get; set; } = null;

    public Transform[] Waypoints;

    private void Awake()
    {
        Get = this;
    }

    public Transform GetPoint(int index)
    {
        if (index != Waypoints.Length)
            return Waypoints[index];

        return null;
    }

}
