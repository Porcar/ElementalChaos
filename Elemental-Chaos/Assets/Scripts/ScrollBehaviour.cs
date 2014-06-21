using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

public class ScrollBehaviour : MonoBehaviour
{
    public int materialIndex;
    public string textureName = "_MainTex";
    public Vector2 uvAnimationRate = new Vector2(1f, 0f);
    private Vector2 uvOffset = Vector2.zero;

    private void LateUpdate()
    {
        uvOffset += (Vector2) (uvAnimationRate * Time.deltaTime);
        if (renderer.enabled)
        {
            renderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}


 

