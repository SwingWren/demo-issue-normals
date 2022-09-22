using UnityEngine;

public class Room : MonoBehaviour {
  public void Enter() {
    gameObject.SetActive(true);
  }

  public void Initialize() {
    gameObject.SetActive(false);
  }
}
