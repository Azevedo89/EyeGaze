using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GameManager : MonoBehaviour
{
   public List<string> NamesSelectedByUser = new List<string>();
   public List<string> NamesGeneratedBySystem = new List<string>();
   public List<TriggerSimon> SimonGameObject = new List<TriggerSimon>();
   public List<GameObject> prefabsSimon = new List<GameObject>();
   public List<GameObject> prefabPosition = new List<GameObject>();
   public GameObject Plane;
   public ListShuffle textShuffle;
   public ListShuffle prefabShuffle;
   public GameObject Sphere;
    public MoveUiGaze Canvas;

    void Start()
    {
        textShuffle = new ListShuffle();
        prefabShuffle = new ListShuffle();
        textShuffle.ShuffleList<string>(NamesGeneratedBySystem);
        
    }
    
    void Update()
    {
        GameOver();

        if (Canvas.CanMove)
        {
            InstantiatePrefabs();
            Canvas.CanMove = false;
        }

    }

    public void GameOver()
    {
        if(SimonGameObject.Count == 0)
        {   
            bool bothListAreTheSame = NamesGeneratedBySystem.SequenceEqual(NamesSelectedByUser);
            if(bothListAreTheSame)
            {   
               ResetGame("São Iguais");
            }
            else
            {
               ResetGame("Não são Iguais");
            }     
        }     
    }

    public void ResetGame(string txt)
    {
        Debug.Log(txt);
        prefabShuffle.ShuffleList<GameObject>(prefabPosition);
        textShuffle.ShuffleList<string>(NamesGeneratedBySystem);
        Plane.transform.rotation = Quaternion.identity;
        Sphere.transform.position = new Vector3(0, 0, 0);
        InstantiatePrefabs();
        NamesSelectedByUser.Clear();
    }

    public void RemoveSimonFromList(TriggerSimon gm)
    {
        SimonGameObject.Remove(gm);
    }

    public void AddNameSelectedByUser(string name)
    {
        NamesSelectedByUser.Add(name);
    }

    public void InstantiatePrefabs()
    {
         
        for(int i=0; i<prefabPosition.Count;i++)
        {
            GameObject simon = Instantiate(prefabsSimon[i] ,new Vector3(prefabPosition[i].transform.localPosition.x, 
            prefabPosition[i].transform.localPosition.y, 
            prefabPosition[i].transform.localPosition.z 
            ), Quaternion.identity);
           
            simon.transform.SetParent(Plane.transform);
           
            AddPrefabToList(simon);
        }
    }

    public void AddPrefabToList(GameObject go)
    {
        SimonGameObject.Add(go.GetComponent<TriggerSimon>());   
    }
}
