using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using cakeslice;
using System.ComponentModel.Design;
public class PlayerController : Character
{
    public PlayerSheet PlayerSheet;
    [SerializeField, HideInInspector] private PlayerGUI playerGui;
    [SerializeField] private LineRenderer lineRenderer;

    public LayerMask LayerMask;


    public int Age;
    /*-------------------------------------------
     * ----This Area defines The Players Stat----
     * -----------------------------------------*/

    public bool PlayedDeadSequence = false;
    public GameObject ClickMarker;

    public Ability[] Abilities;

    // Animation
    public Animator anim;
    public GameObject PlayerModel;
    private Transform lastDestionation;
    private bool hitting = false;
    private float atHit;

    void Start()
    { 
        anim = PlayerModel.GetComponent<Animator>();
        playerGui = FindObjectOfType<PlayerGUI>();
        Abilities = GetComponents<Ability>();
        Age = PlayerSheet.Age;

    }

    
    // Update is called once per frame

    protected override void OnUpdate()
    {
        if (Health > 0)
        {
            if (hitting && Time.time > atHit)
            {
                hitting = false;
                anim.SetBool("isAttacking", false);
            }
            float dist = NavMeshAgent.remainingDistance;
            if (NavMeshAgent.remainingDistance == 0 && NavMeshAgent.velocity == new Vector3(0,0,0))
            {
                Debug.Log("Finished");
                anim.SetBool("isRunning", false);
            }

            if (Input.GetMouseButton(0) && !_isInventoryVisible)
            {
                UpdateInput();
            }
        }
        else
        {

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            _isInventoryVisible = !_isInventoryVisible;
            playerGui.SetInventory(_isInventoryVisible);
            if (_isInventoryVisible)
                GameController.PauseGame();
            else
                GameController.ResumeGame();
        }
    }

    public Transform CasterTransform;
    void UpdateInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 999f, LayerMask.value))
        {
            casterTarget = hit.point;

            Debug.Log("Object hit: " + hit.collider.gameObject.name);
            //Interacting with enemy

            //TODO: NUR EINMAL AUSFÜHREN
            bool OneKeyIsPressed = Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4);
            if (hit.collider.GetComponent<NPCController>() != null || OneKeyIsPressed)
            {
                anim.SetBool("isAttacking", true);
                atHit = Time.time + 1f;
                hitting = true;
                ExecuteCurrentAbility(hit);
                OneKeyIsPressed = false;
               

            } 
            //Ich weiss Vererbung wäre hier schöner gewesen aber es hat sich nicht gelohnt da wieder so viel umzubasteln
            else if (hit.collider.GetComponent<GoodNPCController>() != null)
            {
                Talk(hit, CasterTransform);
            }
            else if (hit.collider.GetComponent<ShopNPC>() != null)
            {
                TalkToBuy(hit, CasterTransform);
            }
            else
            {
                anim.SetBool("isRunning", true);
                NavMeshAgent.destination = hit.point;
                //lastDestionation = hit.point;


                lineRenderer.positionCount = NavMeshAgent.path.corners.Length;
                lineRenderer.SetPositions(NavMeshAgent.path.corners);
                if (hit.collider.gameObject.tag == "Floor")
                {

                    ClickMarker.transform.position = hit.point;
                   
                    Debug.Log("Marker");

                }

            }



            
        }

    }
    //Anlabern Questgeber / NPC
    public void Talk(RaycastHit hit, Transform casterTransform)
    {
        hit.collider.GetComponent<GoodNPCController>().ShowDialogueText();

    }

    //Anlabern Shop
    public void TalkToBuy(RaycastHit hit, Transform casterTransform)
    {
        hit.collider.GetComponent<ShopNPC>().ShowDialogueText();
    }

    void ExecuteCurrentAbility(RaycastHit hit)
    {
        if (AbilityExecuter.SelectedAbility != null)
        {
            AbilityExecuter.SelectedAbility.Execute(this,hit);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawCube(casterTarget, Vector3.one * 0.1f);
    }

    [SerializeField, HideInInspector] private bool _isInventoryVisible = false;
}

