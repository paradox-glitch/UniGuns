//* Morgan Joshua Finney - 2018
//* Usage - import texture, change from clamp to repeate, create a unlit mat from this texture, make a quad to the same ratio as the texture, apply both this script and that mat.
//* Parallax effect - moves texture based on world position.

using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float parralax = 1f;     //* The Speed of this layer
    Material thisMat;

    private void Start()
    {
        thisMat = GetComponent<MeshRenderer>().material;
    }

    void LateUpdate()
    {
        Vector2 offset = thisMat.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        thisMat.mainTextureOffset = offset;
    }
}