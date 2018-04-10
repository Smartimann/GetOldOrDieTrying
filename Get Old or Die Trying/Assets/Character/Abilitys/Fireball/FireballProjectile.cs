using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: projectile base class
public class FireballProjectile : MonoBehaviour
{

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

        }

        _didHitSomething = true;
        Destroy(this.gameObject);
    }
}
