using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterManager : MonoBehaviour
{
    #region Singleton class : SplatterManager
    public static SplatterManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [SerializeField] Color[] colors = new Color[2];
    [SerializeField] GameObject splatterPrefab;
    [SerializeField] Sprite[] splatterSprites;

    public void AddSplatter(Transform obstacle, Vector3 position, int colorIndex)
    {
        GameObject splatter = Instantiate(
                                        splatterPrefab,
                                        position,
                                        Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(-320, 320f))),
                                        obstacle
                                        );

        SpriteRenderer sRenderer;
        if (splatter.TryGetComponent(out sRenderer))
        {
            sRenderer.color = colors[colorIndex];
            sRenderer.sprite = splatterSprites[Random.Range(0, splatterSprites.Length)];
        }
        else
            Debug.LogError("SpriteRenderer component not found.");
    }
}
