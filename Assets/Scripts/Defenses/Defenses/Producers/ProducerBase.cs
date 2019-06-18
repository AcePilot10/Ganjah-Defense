using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ProducerBase : Defense {

    public DefenseStat producerStat;
    public Sprite placeImage;

    void OnEnable()
    {
        OnPlaceEvent += OnPlace;
    }

    void OnDisable()
    {
        OnPlaceEvent -= OnPlace;
    }

    public virtual void OnPlace()
    {
        Stash stash = FindObjectOfType<Stash>();
        try
        {
            stash.Stats.Single(x => x.Name == producerStat.Name).Value += producerStat.Value;
        }
        catch (Exception) {}
        NotificationImageManager.instance.ShowPopup(transform.position, placeImage);
    }
}