namespace VRTK.Examples
{
    using UnityEngine;
    public class LeftHandControl : MonoBehaviour
    {
        public bool isChoosing = false;                                 //是否进入选中物体状态
        //物体
        private VRTK_StraightPointerRenderer pointerRenderer;           //射线打到的东西
        public GameObject chosenTarget;                                 //被选中的东西
        //变量
        private bool triggerPressed = false;                            //是否按下了扳机
        private bool haveDoOnce = false;                                //是否只执行了一次

        public MusicLevel music;

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
        /// 我设置的是只在tree下进行射线检测
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
                    haveDoOnce = true;
                    //播放动画
                    switch (chosenTarget.tag)
                    {
                        case "rune": //树屋里边的rune
                            chosenTarget.GetComponent<Rune>().MoveToTarget();
                            break;
                        case "bird":
                            //让小鸟唱歌
                            music.Startsound();
                            break;
                        case "Tools": //播放向上飞的动画并且放大
                            chosenTarget.GetComponent<Tools>().isTriggerMe = true;
                            break;
                        case "dialog":
                            chosenTarget.GetComponent<Dialog>().AddState();
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (chosenTarget != null && chosenTarget.tag == "Tools")
                {
                    chosenTarget.GetComponent<Tools>().isTriggerMe = false;
                }
                chosenTarget = null;
                haveDoOnce = false;
            }
        }
    }
}

