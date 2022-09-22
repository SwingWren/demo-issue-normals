using UnityEngine;

public class BasicScreen : MonoBehaviour {
  [SerializeField] private Room initialRoom;


  public void Initialize() {
    initialRoom.Initialize();
    
    initialRoom.Enter();
  }
}
