using UnityEngine;

public class ParallaxEffect : MonoBehaviour {

    private Player followTarget;
    private Camera cam;


    private Vector2 startignPosition; //
    private Vector2 camMovedSinceStart => startignPosition - (Vector2)cam.transform.position;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    //if the object is in front of target, use nearclipplane. If behind the target , use farClipPlane
    float clippingPlane => (cam.transform.position.z +(zDistanceFromTarget >0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    private float startingZ;

    private void Awake(){
        startignPosition = transform.position;
        startingZ = transform.position.z;
        cam = Camera.main;
    }
    private void Start() {
        followTarget = Player.Instance;
    }

    private void Update() {
        Vector2 newPosition = startignPosition + camMovedSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }

}