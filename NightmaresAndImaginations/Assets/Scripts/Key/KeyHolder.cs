using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    public void ClearKeyList()
    {
        RemoveKey(Key.KeyType.First);
        RemoveKey(Key.KeyType.Second);
        RemoveKey(Key.KeyType.Third);
    }

    public bool ContainsAllKeys()
    {
        if (ContainsKey(Key.KeyType.First) && ContainsKey(Key.KeyType.Second) && ContainsKey(Key.KeyType.Third))
            return true;
        
        else
            return false;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsAllKeys())
            {
                Debug.Log("Player Got All Keys");
                // Currently holding Key to open this door
                //keyDoor.OpenDoor();
                //ClearKeyList();
                // load next level
            }

            else
            {
                Debug.Log("Player Does Not Have All Keys");
                //keyDoor.PlayOpenFailAnim();
            }
        }
    }
}
