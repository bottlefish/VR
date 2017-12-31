using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//so that we can see changes we make without having to run the game
[ExecuteInEditMode]
public class PostProcessDepthGrayscale : MonoBehaviour {

    public Material mat;
    //public float radius = 0.5f;
    //Vector3 position;

    void Start() {
        this.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }

    void Update() {
        //position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //mat.SetVector("_Center", position);
        //mat.SetFloat("_Radius", radius);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, mat);
        //mat is the material which contains the shader
        //we are passing the destination RenderTexture to
    }
}
