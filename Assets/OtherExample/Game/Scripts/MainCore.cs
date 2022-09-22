using UnityEngine;

public static class MainCore {
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
  private static void Initialize() {
    Object.FindObjectOfType<BasicScreen>().Initialize();
  }
}
