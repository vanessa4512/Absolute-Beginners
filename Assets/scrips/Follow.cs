using UnityEngine;

public class Follow : MonoBehaviour
{
    public float     smoothNess = 4f;
    public Transform player;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(
                                             player.position.x,
                                             transform.position.y,
                                             transform.position.z
                                            );

        transform.position = Vector3.Lerp(
                                          transform.position,
                                          targetPosition,
                                          smoothNess * Time.deltaTime
                                         );
    }
}
