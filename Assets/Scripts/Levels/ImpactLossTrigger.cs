using System;
using System.Collections.Generic;
using System.Linq;
using Doozy.Engine.UI;
using UnityEngine;

public class ImpactLossTrigger : MonoBehaviour
{
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private List<CollisionCatcher> _impacts;
    [SerializeField] private UIView _lossPanel;
    
    private void Start()
    {
        SubscribeImpacts();
    }
    
    private void SubscribeImpacts()
    {
        _impacts = GetComponentsInChildren<CollisionCatcher>().ToList();
        
        foreach (var impact in _impacts)
        {
            impact.OnCollisionEnterEvent += collision => { LossContact();};
        }
    }

    private void LossContact()
    {
        _lossPanel.Show();
        _levelProgress.LossLevel?.Invoke();
    }
}
