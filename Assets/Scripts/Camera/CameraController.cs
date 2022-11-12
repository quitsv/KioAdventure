using UnityEngine;

public class CameraController : MonoBehaviour
{
  //Follow player
  [SerializeField] private Transform player;
  [SerializeField] private float aheadDistance = 5f;
  [SerializeField] private float cameraSpeed;
  private float lookAhead;

  private void Update()
  {
    //Follow player
    transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
    lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
  }

}