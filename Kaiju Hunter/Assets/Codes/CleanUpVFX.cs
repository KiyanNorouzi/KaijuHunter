using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpVFX : MonoBehaviour
{
        #region Datamembers

        #region Private Fields

 

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        private void Start()
        {
  

            StartCoroutine(CleanUpRoutine());
        }


        #endregion

        private IEnumerator CleanUpRoutine()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForFixedUpdate();
            }

  

            Destroy(gameObject,1f);
        }

        #endregion
}
