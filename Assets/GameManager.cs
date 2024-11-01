using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;
        public float weight;
    }

    public List<SpawnableObject> objectsToSpawn;
    public Button spawnButton;
    public Transform spawnTrPos;
    public bool isObjectThere = false;

    private float cooldownTime = 0.5f;
    private float lastSpawnTime = 0f;
    public int Score = 0;
    public Text scoreTxt;
    public string playerName;
    private void Awake()
    {
        playerName = DateTime.Now.ToString();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        spawnButton.onClick.AddListener(SpawnObject);
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= cooldownTime)
        {
            isObjectThere = false;
        }
        scoreTxt.text = $"SCORE : {Score}";
    }

    public void SetDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 1: SetWeights(new float[] { 50, 40, 30, 20, 10 }); break;
            case 2: SetWeights(new float[] { 50, 20, 10, 5, 1 }); break;
            case 3: SetWeights(new float[] { 50, 10, 2, 0.1f, 0 }); break;
        }
    }

    private void SetWeights(float[] weights)
    {
        for (int i = 0; i < objectsToSpawn.Count && i < weights.Length; i++)
        {
            objectsToSpawn[i].weight = weights[i];
        }
    }

    private void SpawnObject()
    {
        if (Time.time - lastSpawnTime < cooldownTime || isObjectThere)
        {
            return;
        }

        GameObject selectedObject = SelectObject();
        if (selectedObject != null)
        {
            Instantiate(selectedObject, spawnTrPos.position, Quaternion.identity);
            isObjectThere = true;
            lastSpawnTime = Time.time;
        }
    }

    private GameObject SelectObject()
    {
        float totalWeight = 0f;
        foreach (var obj in objectsToSpawn)
        {
            totalWeight += obj.weight;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;
        foreach (var obj in objectsToSpawn)
        {
            cumulativeWeight += obj.weight;
            if (randomValue < cumulativeWeight)
            {
                return obj.prefab;
            }
        }

        return null;
    }

    //public void AddScore(int amount)
    //{
    //    Score += amount;
    //    // Optionally, update UI or other systems here to reflect the new score.

    
    //}
    public void AddScore(int amount)
    {
        Score += amount;
        
    }
}
