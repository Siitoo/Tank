using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;
    public float changedir = 1.0f;
    private float timer = 0.0f;
    Vector3  vec;
	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        vec = new Vector3(0, 0, 0);
        timer = changedir;
	}

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        timer += Time.deltaTime;
        if (timer >= changedir)
        {
            float angle = RandomBinominal() * max_angle;
            if (RandomBinominal() < 0.5)
                angle = -angle;
            Vector3 random_vel = new Vector3(-Mathf.Sin(angle), 0.0f, Mathf.Cos(angle));
            random_vel.Normalize();
            random_vel *= move.max_mov_velocity;

            vec = random_vel;
        }

        move.SetMovementVelocity(vec);
    }
}
