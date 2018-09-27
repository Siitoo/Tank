using UnityEngine;
using System.Collections;

public class KinematicSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 5: Set movement velocity to max speed in the direction of the targetS
        // Remember to enable this component in the inspector
        Vector3 dir = move.target.transform.position - move.transform.position;
        dir.y = 0.0f;
        dir.Normalize();
       
        move.SetMovementVelocity(dir * move.max_mov_velocity);
    }
}
