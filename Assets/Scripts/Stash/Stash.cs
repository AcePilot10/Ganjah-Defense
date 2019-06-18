using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour {

    private float lastHealth = 0f;
    private float _health;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            lastHealth = _health;
            _health = value;
            HealthValueChanged();
        }
    }

    #region Stats
    public DefenseStat productionRate;
    public DefenseStat productionAmount;
    public List<DefenseStat> Stats { get; set; }
    #endregion

    public List<NotificationImageData> popups;

    [HideInInspector]public bool isProducing = true;

    private void Awake()
    {
        Health = 100f;
    }

    private void OnEnable()
    {
        Stats = new List<DefenseStat>();
        Stats.Add(productionRate);
        Stats.Add(productionAmount);
    }

    private void Start()
    {
        StartCoroutine(Produce());
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<EnemyBase>() != null)
        {
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            enemy.ExecuteHitStash();
        }
    }

    #region Production
    private IEnumerator Produce()
    {
        while (isProducing)
        {
            yield return new WaitForSeconds(productionRate.Value);
            ProduceToStash();
        }
    }
    private void ProduceToStash()
    {
        CurrencyManager.instance.Weed += productionAmount.Value;
        Sprite image = popups.Find(x => x.key == "WeedProduced").sprite;
        NotificationImageManager.instance.ShowPopup(transform.position, image);
    }
    #endregion

    private void HealthValueChanged()
    {
        if (Health < lastHealth)
        {
            var img = popups.Find(x => x.key == "EnemyReachedStash").sprite;
            NotificationImageManager.instance.ShowPopup(transform.position, img);
            if (Health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("All of the stash has been taken!");
        FindObjectOfType<AdPlayer>().ShowEndOfLevelAd();
    }
}