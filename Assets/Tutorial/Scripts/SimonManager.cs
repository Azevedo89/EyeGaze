using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimonManager : MonoBehaviour
{
   public List<string> NameGeneretaedBySimon = new List<string>(); 
   public List<string> NameCollectedByUser = new List<string>(); 
   public List<GameObject> GetAllTokens = new List<GameObject>(); 
   public List<GameObject> PrefabTokens = new List<GameObject>();
    public List<GameObject> EmptyGOPos = new List<GameObject>();
    public GameObject Plane;

    public void Update(){
        GameOver();
    }

    public void AddToList(string go){
        NameCollectedByUser.Add(go);
    }
  
    public void RemoveFromList(GameObject go){
        GetAllTokens.Remove(go);
    }
    
    public void CompareLists(){
        bool test = NameGeneretaedBySimon.SequenceEqual(NameCollectedByUser);
        Debug.Log("Resultado " + test );
    }

    public void GameOver(){
        if(GetAllTokens.Count == 0){
            CompareLists();
             InstatiateTokens();
        }
    }

    public void InstatiateTokens()
    {
        for(int i = 0; i<PrefabTokens.Count;i++){
            var simon = Instantiate(PrefabTokens[i], new Vector3(EmptyGOPos[i].transform.position.x,
            EmptyGOPos[i].transform.position.y,
            EmptyGOPos[i].transform.position.z), Quaternion.identity);

            simon.transform.SetParent(Plane.transform);
        }   
    }

}
