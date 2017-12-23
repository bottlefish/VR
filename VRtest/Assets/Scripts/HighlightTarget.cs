namespace VRTK.Examples
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class HighlightTarget : MonoBehaviour
    {

        private PlayerOperation player;
        private GameObject rightController;
        private VRTK_StraightPointerRenderer render;
        public GameObject oldTarget;
        public GameObject target;

        void Awake()
        {
            rightController = GameObject.FindWithTag("RightController");
            player = rightController.GetComponent<PlayerOperation>();
            render = rightController.GetComponent<VRTK_StraightPointerRenderer>();
        }

        void Update()
        {
            target = player.highlightTarget;
            if (oldTarget != null)
            {
                if (target == null || oldTarget != target)
                {
                    oldTarget.GetComponent<Cube>().HighLightToNormal();
                }
            }

            if (target != null)
            {
                if (oldTarget == null || target != oldTarget)
                {
                    if (target.tag == "Cube")
                    {
                        target.GetComponent<Cube>().NormalToHighLight();
                    }
                }
            }

            oldTarget = target;
        }

    }

}
