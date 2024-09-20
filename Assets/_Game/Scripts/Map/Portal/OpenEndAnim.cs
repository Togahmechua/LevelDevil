using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndAnim : MonoBehaviour
{
    [SerializeField] private int count;
    private EndGameCanvas endGameCanvas;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCtrl playerCtrl = Cache.GetCharacter(other);
        if (playerCtrl != null)
        {
            endGameCanvas = UIManager.Ins.OpenUI<EndGameCanvas>();
            LevelManager.Ins.endAnim = true;
            if (count > 0)
            {
                StartCoroutine(Wait());
            }
            count++;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        endGameCanvas.Blink();
    }
}
