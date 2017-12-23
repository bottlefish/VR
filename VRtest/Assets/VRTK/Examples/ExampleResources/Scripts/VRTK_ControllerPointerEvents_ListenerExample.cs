namespace VRTK.Examples
{
    using UnityEngine;

    public class VRTK_ControllerPointerEvents_ListenerExample : MonoBehaviour
    {
        
        public bool showHoverState = false;


        ///////////////////////我们写的
        //状态
        public bool isChoosing = false;             //是否进入选中物体状态
        //物体
        public GameObject pointingTarget;           //射线打到的东西
        public GameObject chosenTarget;             //被选中的东西
        public GameObject highlightTarget;             //被选中的东西
        //变量
        private bool triggerPressed = false;        //是否按下了扳机
        private bool haveDoOnce = false;                //是否只执行了一次
        ///////////////////////我们写的

        private void Start()
        {
            if (GetComponent<VRTK_DestinationMarker>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerPointerEvents_ListenerExample", "VRTK_DestinationMarker", "the Controller Alias"));
                return;
            }
            GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(TriggerReleased);
            //Setup controller event listeners
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
            if (showHoverState)
            {
                GetComponent<VRTK_DestinationMarker>().DestinationMarkerHover += new DestinationMarkerEventHandler(DoPointerHover);
            }
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
        }
        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            triggerPressed = true;
            
        }
        private void TriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            triggerPressed = false;
           
        }
        private void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
        {
            string targetName = (target ? target.name : "<NO VALID TARGET>");
            string colliderName = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
            //VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + targetName + "] on the collider named [" + colliderName + "] - the pointer tip position is/was: " + tipPosition);
        }

        private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
        {
            ///////////////////////我们写的
            pointingTarget = e.target.gameObject;
            ///////////////////////我们写的
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER IN", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
        {
            ///////////////////////我们写的
            pointingTarget = null;
            ///////////////////////我们写的
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER OUT", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerHover(object sender, DestinationMarkerEventArgs e)
        {
            ///////////////////////我们写的
            pointingTarget = e.target.gameObject;
            ///////////////////////我们写的
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER HOVER", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER DESTINATION", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        ///////////////////////我们写的
        private void Update() {
            //判断跟随状态
            if (triggerPressed && pointingTarget != null) {
                isChoosing = true;
            }
            if(!triggerPressed) {
                isChoosing = false;
            }

            //执行跟随状态
            if (isChoosing) {
                //do once
                if (!haveDoOnce) {
                    chosenTarget = pointingTarget;
                    highlightTarget = chosenTarget;
                    haveDoOnce = true;
                }
            }
            else {
                chosenTarget = null;
                haveDoOnce = false;
                highlightTarget = pointingTarget;
            }
        }
        ///////////////////////我们写的
    }
}