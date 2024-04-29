using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//switches between free roam mode and quiz 
public class QuizCanvas : MonoBehaviour
{
    public CharacterManager CM;
    public Transform QuizCList;
    public Transform QuizPList;
    public GameObject WallSt1;
    public GameObject Roaring1;
    [SerializeField] private bool QuickFire;



    private void OnEnable()
    {
        if (!QuickFire)
        {
            string quizName = CM.getQuizC();

            foreach (Transform child in QuizCList)
            {
                child.gameObject.SetActive(false);
            }


            Transform quizTransform = QuizCList.transform.Find(quizName);
            if (quizTransform != null)
            {
                quizTransform.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning($"No quiz GameObject found with the name: {quizName}");
            }
        }
    }

}
