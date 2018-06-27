using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Basisklasse für alles was lebt.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public abstract class Character : MonoBehaviour
{
    public CharacterSheet CharacterSheet;
    [SerializeField] public int Health, Mana;

    [SerializeField] protected MeshRenderer MeshRenderer;
    [SerializeField, HideInInspector] protected NavMeshAgent NavMeshAgent;
    [SerializeField, HideInInspector] protected Color OriginalMaterialColor;
    private float _lastTimeAddMana;
    protected bool IsDeadSequencePlayed = false;

    [HideInInspector] public Vector3 casterTarget;
    protected void OnEnable()
    {
        Health = CharacterSheet.Health;
        Mana = CharacterSheet.Mana;

        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected void Update()
    {
        if (Health > 0)
        {
            if (Mana < 0) {
                Mana = 0;
            }
          /*  if (Time.time - _lastTimeAddMana > CharacterSheet.ManaRefillRate)
            {
                Mana += Mathf.RoundToInt((Time.time - _lastTimeAddMana) / CharacterSheet.ManaRefillRate);
                Mana = Mathf.Clamp(Mana, 0, CharacterSheet.Mana);
                _lastTimeAddMana = Time.time;
            }*/
        }
        else
        {
            if (!IsDeadSequencePlayed)
            {
                IsDeadSequencePlayed = true;
                NavMeshAgent.enabled = false;
                GetComponent<Collider>().enabled = false;
                Sequence deadSequence = DOTween.Sequence();
                deadSequence.Append(transform.DORotate(new Vector3(90f, 0f, 0f), 0.2f, RotateMode.LocalAxisAdd));
                deadSequence.Append(transform.DOMoveY(0f, 0.2f));
            }
        }

        OnUpdate();
    }

    protected abstract void OnUpdate();

    public void Damage(int damage)
    {
        // Grab a free Sequence to use
        Sequence mySequence = DOTween.Sequence();
        // Add a rotation tween as soon as the previous one is finished
        mySequence.Append(MeshRenderer.material.DOColor(Color.red, 0.02f));
        // Delay the whole Sequence by 1 second
        mySequence.PrependInterval(0.05f);

        mySequence.Append(MeshRenderer.material.DOColor(OriginalMaterialColor, 0.02f));

        Health -= damage;
    }


    public void UseMana(int cost) {
        if (Mana > 0) {
            Mana -= cost;    
        } 
    }

    public int GetMana() {
        return Mana;
    }

}
