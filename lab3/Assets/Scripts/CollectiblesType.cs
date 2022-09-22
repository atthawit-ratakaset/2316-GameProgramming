using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesType : MonoBehaviour
{
    [SerializeField] private SoCollectible collectibleObject;

    private void Start() 
    {
        //Debug.Log(collectibleObject.GetCollectible());
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Restore"))
        {
            Debug.Log(collectibleObject.GetCollectible());
            StartCoroutine(RestoreItems(other));
        }
    }
    
    public IEnumerator RestoreItems(Collider2D other)
    {
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);
        other.gameObject.SetActive(true);
    }
    
}
