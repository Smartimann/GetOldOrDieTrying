using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using cakeslice;

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
    // Use this for initialization
    void Start()
    {
        playerGui = FindObjectOfType<PlayerGUI>();
        Abilities = GetComponents<Ability>();
        Age = PlayerSheet.Age;

    }



    // Update is called once per frame

    protected override void OnUpdate()
    {
        if (Health > 0)
        {
            UpdateActiveAbility();

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

    public int AbilityActiveIndex;

    void UpdateActiveAbility()
    {
        bool abilityIndexChanged = false;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AbilityActiveIndex = 0;
            abilityIndexChanged = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AbilityActiveIndex = 1;
            abilityIndexChanged = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AbilityActiveIndex = 2;
            abilityIndexChanged = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AbilityActiveIndex = 3;
            abilityIndexChanged = true;
        }

        if (abilityIndexChanged)
        {
            playerGui.SetActiveAbility(AbilityActiveIndex);
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
            if (hit.collider.GetComponent<NPCController>() != null)
            {
                ExecuteCurrentAbility();
            }
            else if (hit.collider.GetComponent<GoodNPCController>() != null)
            {
                Talk(hit, CasterTransform);
            }
            else
            {
                NavMeshAgent.destination = hit.point;

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

    public void Talk(RaycastHit hit, Transform casterTransform)
    {
        hit.collider.GetComponent<GoodNPCController>().ShowDialogueText();

    }

    void ExecuteCurrentAbility()
    {
        if (AbilityActiveIndex < Abilities.Length && Abilities[AbilityActiveIndex])
        {
            Abilities[AbilityActiveIndex].Execute(this);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawCube(casterTarget, Vector3.one * 0.1f);
    }

    [SerializeField, HideInInspector] private bool _isInventoryVisible = false;
}

