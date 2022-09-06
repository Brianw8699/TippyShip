using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOverlay : MonoBehaviour
{
    Texture2D texture;
    bool brian = true;
    public Sprite sprite;
    public GameObject caveMap;
    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(1200,1200, TextureFormat.ARGB32, false);
        sprite = Sprite.Create(texture, new Rect(0, 0, caveMap.GetComponent<SpriteRenderer>().sprite.bounds.size.x, caveMap.GetComponent<SpriteRenderer>().sprite.bounds.size.y), Vector2.zero);
        GetComponent<SpriteRenderer>().sprite = sprite;
        for(int y = 0; y<texture.height; y++){
            for(int x = 0; x < texture.width; x++){
                texture.SetPixel(x, y, new Color (0,0,0,1));
            }
        }
        texture.Apply();
        Debug.Log("Finished");
        Debug.Log(caveMap.GetComponent<SpriteRenderer>().sprite.bounds.size.x);
        transform.localPosition = new Vector3(-60f, -60f);
        //changeClear();
    }

    void Update(){
        texture.SetPixel(10, 10, Color.clear);
        texture.Apply();

    }

     void changeClear() {
        

for(int y = 50; y<texture.height; y++){
            for(int x = 0; x < texture.width; x++){
                texture.SetPixel(x, y, Color.clear);
            }
        } 
    texture.Apply();

        
        }

    }

