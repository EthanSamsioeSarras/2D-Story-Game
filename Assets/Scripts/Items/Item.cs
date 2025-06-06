using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    private SpriteRenderer spriteRenderer;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool collected = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void LoadData(GameData data)
    {
        data.itemsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            spriteRenderer.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected.Remove(id);
        }
        data.itemsCollected.Add(id, collected);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!collected)
            {
                CollectItem();
            }
        }
    }

    private void CollectItem()
    {
        collected = true;
        spriteRenderer.gameObject.SetActive(false);
    }
}
