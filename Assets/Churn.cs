using UnityEngine;
public class Churn : MonoBehaviour {
  Transform[] cubes;
	void Start () {
    cubes = transform.GetComponentsInChildren<Transform>();
  }
	void Update () {
    foreach(Transform cube in cubes) {
      Vector3 sideways = Vector3.Cross(transform.position, cube.position);

      cube.localRotation = Quaternion.Euler(sideways.normalized*0.001f) * cube.localRotation * Quaternion.Euler(0.1f, 0.1f, 0.1f);
    }
    transform.rotation = Quaternion.identity;
  }
}
