namespace VRTK.Examples
{
    using UnityEngine;

    public class PlayerOperation : MonoBehaviour
    {
        //状态
        public bool isChoosing = false;                                 //是否进入选中物体状态
        //物体
        private VRTK_StraightPointerRenderer pointerRenderer;           //射线打到的东西
        public GameObject chosenTarget;                                 //被选中的东西
        public GameObject highlightTarget;                              //被选中的东西
        //变量
        private bool triggerPressed = false;                            //是否按下了扳机
        private bool haveDoOnce = false;                                //是否只执行了一次

        private void Awake()
        {
            pointerRenderer = GetComponent<VRTK_StraightPointerRenderer>();
        }

        private void Start()
        {
            GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(TriggerReleased);
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            triggerPressed = true;

        }
        private void TriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            triggerPressed = false;

        }
        /// <summary>
        /// pointerRenderer.a 为VRTK_StraightPointerRenderer脚本在我们选择的layer mask下边打到的物体 
        /// 我设置的是只在water下进行射线检测
        /// </summary>
        private void Update()
        {
            if (pointerRenderer.a != null && triggerPressed)
            {
                isChoosing = true;
            }
            if (!triggerPressed)
            {
                isChoosing = false;
            }
            if (isChoosing)
            {
                if (!haveDoOnce)
                {
                    chosenTarget = pointerRenderer.a;
                    chosenTarget.GetComponent<Cube>().isTriggerMe = true;
                    highlightTarget = chosenTarget;
                    haveDoOnce = true;
                }
            }
            else
            {
                if (chosenTarget != null)
                {
                    chosenTarget.GetComponent<Cube>().isTriggerMe = false;
                }
                chosenTarget = null;
                haveDoOnce = false;
                highlightTarget = pointerRenderer.a;
            }
        }
    }
}

