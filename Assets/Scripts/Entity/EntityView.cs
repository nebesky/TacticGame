using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameSession;
using UnityEngine;

public class EntityView : MonoBehaviour, IEntityView
{
    public SpriteRenderer targetAuraSpriteRenderer;
    public Animator Animator;
    public Transform runPosition;
    public SkinnedMeshRenderer SkinnedMeshRenderer2;
    public event Action OnMovingEnd;
    
    private bool isRunning;

    public void RunTo(List<Vector3> transforms)
    {
        StartCoroutine(St(transforms));
    }

    private IEnumerator St(IReadOnlyList<Vector3> transforms)
    {
        for (var i = transforms.Count - 1; i >= 0; i--)
        {
            isRunning = true;

            transform
                .DOLookAt(transforms[i], 0.3f)
                .SetEase(Ease.OutCubic);

            Animator.SetBool("isRun", true);

            while (true)
            {
                if (Vector3.Distance(transform.position, transforms[i]) < 0.5f)
                {
                    Animator.SetBool("isRun", false);
                    isRunning = false;

                    OnMovingEnd?.Invoke();
                    
                    break;
                }

                yield return null;
            }
        }
    }

    public void Run(Vector3 transform)
    {
        var step = new List<Vector3> { transform };

        RunTo(step);
    }

    public void SetRotation(Quaternion rotation) => transform.rotation = rotation;

    public void SetLocalPosition(Vector3 position) => transform.position = position;

    public void SetTeamColor(Color color)
    {
        targetAuraSpriteRenderer.color = color;
        
        SkinnedMeshRenderer2.materials[0].SetColor("_EmissionColor", color);  
        SkinnedMeshRenderer2.materials[1].SetColor("_EmissionColor", color);  
    }

    public void ShowTargetAura() => targetAuraSpriteRenderer.enabled = true;
    
    public void HideTargetAura() => targetAuraSpriteRenderer.enabled = false;
}