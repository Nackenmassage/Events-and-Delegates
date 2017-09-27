using System.Collections.Generic;
using UnityEngine;

public class MonsterTracker : MonoBehaviour
{
    // keep a list of monsters currently in the trigger volume
    [SerializeField]
    List<GameObject> monsterList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Monster>() != null)
        {
            monsterList.Add(other.gameObject);
            // we know that monsters implement INotifyOnDisable, so we can subscribe
            other.gameObject.GetComponent<INotifyOnDeath>().OnDeath += RemoveMonster;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Monster>() != null)
        {
            RemoveMonster(other.gameObject);
        }
    }

    //RemoveMonster gets triggered by OnTriggerExit - but also by OnDeath, i.e. when the monster dies inside the trigger
    void RemoveMonster(GameObject monster)
    {
        monster.GetComponent<INotifyOnDeath>().OnDeath -= RemoveMonster;
        monsterList.Remove(monster);
    }

    void OnDisable()
    {
        // unsubscribe and replace list with fresh list so it can be reused later
        for (int i = 0; i < monsterList.Count; i++)
        {
            monsterList[i].GetComponent<INotifyOnDeath>().OnDeath -= RemoveMonster;
        }
        monsterList = new List<GameObject>();
    }
}
