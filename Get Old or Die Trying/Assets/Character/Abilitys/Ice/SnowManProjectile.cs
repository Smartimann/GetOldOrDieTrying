using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManProjectile : MonoBehaviour {
 public float Velocity;
    public Vector3 Direction;

    public int damage = 10;
	// Update is called once per frame
	void Update ()
	{
	    transform.position += Direction * Velocity * Time.deltaTime;
	    transform.rotation = Quaternion.LookRotation(Direction);
	}

    [SerializeField] private bool _didHitSomething;
    private void OnTriggerEnter(Collider other)
    {
        if(_didHitSomething)
            return;

        var npcController = other.gameObject.GetComponent<NPCController>();
        if (npcController != null)
        {
            npcController.Damage(this.damage);
			npcController.Slow();
            Debug.Log(other.gameObject);

        }

        _didHitSomething = true;
        Destroy(this.gameObject);
    }
}
