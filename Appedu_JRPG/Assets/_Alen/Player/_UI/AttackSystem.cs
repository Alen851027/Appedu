using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alen
{
    public class AttackSystem : MonoBehaviour
    {
        #region 單利模式 Singleton
        public static AttackSystem instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        #region 攻擊動畫
        private Animator ani;

        #endregion
    }
}

