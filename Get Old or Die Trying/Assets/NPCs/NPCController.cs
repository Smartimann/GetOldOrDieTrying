using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class NPCController : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent navMeshAgent;

  //  [SerializeField] private MeshRenderer meshRenderer;
   // [SerializeField] private MaterialPropertyBlock materialPropertyBlock;
    public float viewRange = 5f;
    public Transform player;
    private Color OriginMaterialColor;

    public GameObject Canvas;
    [SerializeField] private PlayerGUI PlayerGui;
    public int Health;
    /* 0 Normal = 100
     * 1 Harder = 150
     * 2 WayHarder = 200
     * 3 Extreme = 300
     */

    public string MonsterName;
    public int[] DifferentHealths = {100,150,200,300};


    [SerializeField, HideInInspector]
    private int _maxHealth;
	// Use this for initialization
	void Start ()
	{
        setMonsterType();
        navMeshAgent = GetComponent<NavMeshAgent>();
	    //meshRenderer = GetComponent<MeshRenderer>();
	    //materialPropertyBlock = new MaterialPropertyBlock();
	    player = FindObjectOfType<PlayerController>().transform;
        //OriginMaterialColor = GetComponent<MeshRenderer>().sharedMaterial.color;
        //PlayerGui = Canvas.GetComponent<PlayerGUI>();
        PlayerGui = FindObjectOfType<PlayerGUI>();
	    _maxHealth = Health;
	}

    public bool PlayedDeadSequence = false;
	// Update is called once per frame
	void Update ()
	{
	    if (Health > 0)
	    {
	        Vector3 position = this.transform.position;
	        if (Vector3.Distance(position, player.position) < viewRange)
	        {
	            navMeshAgent.destination = player.position;
	        }


	    }
        else// he ded
        {

            if (!PlayedDeadSequence) 
	        {
	            PlayedDeadSequence = true;
	            navMeshAgent.enabled = false;
	            GetComponent<Collider>().enabled = false;
                Sequence deadSequence = DOTween.Sequence();
	            deadSequence.Append(transform.DORotate(new Vector3(90f, 0f, 0f), 0.2f, RotateMode.LocalAxisAdd));
	            deadSequence.Append(transform.DOMoveY(0f, 0.2f));
	        }
        }


        //meshRenderer.SetPropertyBlock(materialPropertyBlock);
	}

    private void setMonsterType()
    {
        string MonsterName = this.gameObject.name.ToLower();
        if (MonsterName.Contains("wildschwein"))
        {
            Health = DifferentHealths[1];
            MonsterName = "wildschwein";
        } else if (MonsterName.Contains("skeleton"))
        {
            Health = DifferentHealths[0];
        } else if (MonsterName.Contains("werwolf")) {
            Health = DifferentHealths[2];
            MonsterName = "werwolf";
        }
            
    }

    public void Damage(int damage)
    {
        // Grab a free Sequence to use
       // Sequence mySequence = DOTween.Sequence();
        // Add a rotation tween as soon as the previous one is finished
        //mySequence.Append(meshRenderer.material.DOColor(Color.red, 0.02f));
        // Delay the whole Sequence by 1 second
       
        
        //mySequence.Append(meshRenderer.material.DOColor(OriginMaterialColor, 2f));

        Health -= damage;

        PlayerGui.SetEnemyHealthBar(gameObject, Health / (float) _maxHealth);
        Debug.Log("Damage dealt: " + damage);

    }

    public void Slow() {
        navMeshAgent.speed -= 2; 
    }
}
