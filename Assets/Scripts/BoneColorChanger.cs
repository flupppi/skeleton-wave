using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.XR;


public class BoneColorChanger : MonoBehaviour
{

    private Bone2D selectedBone;
    private SpriteRenderer spriteRenderer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // On mouse click
        {
            SelectBone();
        }

        if (Input.GetMouseButtonUp(0)) // On mouse release
        {
            ResetBoneColor();
            selectedBone = null;
        }
    }

    void SelectBone()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            Bone2D bone = hit.transform.GetComponent<Bone2D>();
            if (bone != null)
            {
                selectedBone = bone;
                HighlightSpritesInfluencedByBone(selectedBone);
            }
        }
    }

    void HighlightSpritesInfluencedByBone(Bone2D bone)
    {
        if (bone == null) return;

        spriteRenderer = bone.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red; // Change to desired highlight color
        }
    }

    void ResetBoneColor()
    {
        if (spriteRenderer == null) return;

            spriteRenderer.color = Color.white; // Reset to original color
        
    }

}
