using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAnimePanel : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

  public void playSide()
    {
        anim.Play("infoAnim");
    }

    public void closeSlide()
    {
        anim.Play("infoAnimReverse");
    }
}
