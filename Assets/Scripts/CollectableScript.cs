using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CollectableScript : MonoBehaviour
{
    private int count;
    public Text countUI;

    private int locationCount;
    public Text locationCountUI;
    public GameObject LocationUIPanel;

    private List<int> destroyed = new List<int>();

    private void AddToCount()
    {
        count += 1;
    }

    private void AddToLocationCount()
    {
        locationCount += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {

            GameObject CollectableObject = other.gameObject;
            destroyed.Add(CollectableObject.GetInstanceID());//gets unqiue object ID
            Destroy(CollectableObject);

            AddToCount();
            CollectableCount();

            AddToLocationCount();
            CollectableLocationCount();
        }
        if (other.name.Contains("TriggerForTrigger"))
        {
            locationCount = 0;
            CollectableLocationCount();
            LocationUIPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("TriggerForTrigger"))
        {
            LocationUIPanel.SetActive(false);
            other.isTrigger = false;
        }
    }

    private void CollectableCount()
    {
        countUI.text = "Collectables: " + count.ToString() + " / 47";
    }

    private void CollectableLocationCount()
    {
        locationCountUI.text = "Collectables In Location: " + locationCount.ToString() + " / 5";
    }

    public List<int> GetDestroyedCollectables()
    {
        List<int> collectableIDs = new List<int>();

        for (int i = 0; i < destroyed.Capacity; i++)
        {
            collectableIDs.Add(destroyed[i]);
        }
        return collectableIDs;
    }

    public void SaveCollectable()
    {
        Save.SaveCollectablesData(destroyed);
    }

    public void loadCollectable()
    {
        SaveData CollectablesData = Save.LoadCollectabblesData();
        try
        {

            for (int i = 0; i < CollectablesData.DestroyedCollectable.Count; i++)
            {
                int collectableID = CollectablesData.DestroyedCollectable[i];

                GameObject[] CollectableTag = GameObject.FindGameObjectsWithTag("Collectable");

                for (int j = 0; j < CollectableTag.Length; j++)
                {
                    if (CollectableTag[j].GetInstanceID().Equals(collectableID))
                    {
                        GameObject collectable = CollectableTag[j];
                        destroyed.Add(collectable.GetInstanceID());
                        Destroy(collectable);
                        AddToCount();
                        CollectableCount();
                        break;
                    }
                }
            }

        }
        catch (ArgumentOutOfRangeException ex)
        {
            throw ex;
        }
    }
}
