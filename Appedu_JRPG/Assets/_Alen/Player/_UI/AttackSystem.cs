using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alen
{
    public class AttackSystem : MonoBehaviour
    {
        #region ��Q�Ҧ� Singleton
        public static AttackSystem instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        #region �����ʵe
        private Animator ani;

        #endregion
    }
}

