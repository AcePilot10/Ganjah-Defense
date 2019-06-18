using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryProducer : ProducerBase {

    public DefenseStat reductionStat;
    public float lifetime;
    public Sprite reductionImage;

    public override void OnPlace()
    {
        base.OnPlace();
        StartCoroutine(StatDelay());
    }

    private IEnumerator StatDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Stash stash = FindObjectOfType<Stash>();
        var stat = stash.Stats.Find(x => x.Name == reductionStat.Name);
        stat.Value -= producerStat.Value;
        stat.Value -= reductionStat.Value;
        NotificationPopupManager.instance.ShowPopup(transform.position, reductionImage);
    }
}