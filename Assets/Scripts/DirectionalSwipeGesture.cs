// using System;
// using System.Collections.Generic;
// using TouchScript.Utils;
// using UnityEngine;

// namespace TouchScript.Gestures
// {
//     [AddComponentMenu("TouchScript/Gestures/Directional Swipe Gesture")]
//     public class DirectionalSwipeGesture : Gesture
//     {
//         public const string FLICK_MESSAGE = "OnSwipe";

//         public event EventHandler<EventArgs> Swiped
//         {
//             add { swipedInvoker += value; }
//             remove { swipedInvoker -= value; }
//         }

//         // iOS Events AOT hack
//         private EventHandler<EventArgs> swipedInvoker;

//         public float swipeTime
//         {
//             get { return swipeTime; }
//             set { swipeTime = value; }
//         }

//         public float MinDistance
//         {
//             get { return minDistance; }
//             set { minDistance = value; }
//         }

//         public float MovementThreshold
//         {
//             get { return movementThreshold; }
//             set { movementThreshold = value; }
//         }

//         public Vector2 ScreenFlickVector { get; private set; }

//         public float ScreenFlickTime { get; private set; }

//         [SerializeField]
//         private float flickTime = .1f;

//         [SerializeField]
//         private float minDistance = 1f;

//         [SerializeField]
//         private float movementThreshold = .5f;

//         private bool moving = false;
//         private Vector2 movementBuffer = Vector2.zero;
//         private bool isActive = false;
//         private TimedSequence<Vector2> deltaSequence = new TimedSequence<Vector2>();

//         protected void LateUpdate()
//         {
//             if (!isActive) return;

//             deltaSequence.Add(ScreenPosition - PreviousScreenPosition);
//         }

//         protected override void touchesBegan(IList<ITouch> touches)
//         {
//             base.touchesBegan(touches);

//             if (activeTouches.Count == touches.Count)
//             {
//                 isActive = true;
//             }
//         }

//         protected override void touchesMoved(IList<ITouch> touches)
//         {
//             base.touchesMoved(touches);

//             if (!moving)
//             {
//                 movementBuffer += ScreenPosition - PreviousScreenPosition;
//                 var dpiMovementThreshold = MovementThreshold * touchManager.DotsPerCentimeter;
//                 if (movementBuffer.sqrMagnitude >= dpiMovementThreshold * dpiMovementThreshold)
//                 {
//                     moving = true;
//                 }
//             }
//         }

//         protected override void touchesEnded(IList<ITouch> touches)
//         {
//             base.touchesEnded(touches);

//             if (activeTouches.Count == 0)
//             {
//                 isActive = false;

//                 if (!moving)
//                 {
//                     setState(GestureState.Failed);
//                     return;
//                 }

//                 deltaSequence.Add(ScreenPosition - PreviousScreenPosition);

//                 float lastTime;
//                 var deltas = deltaSequence.FindElementsLaterThan(Time.timeSinceLevelLoad - FlickTime, out lastTime);
//                 var totalMovement = Vector2.zero;
//                 foreach (var delta in deltas) totalMovement += delta;

//                 switch (Direction)
//                 {
//                     case GestureDirection.Horizontal:
//                         totalMovement.y = 0;
//                         break;
//                     case GestureDirection.Vertical:
//                         totalMovement.x = 0;
//                         break;
//                 }

//                 if (totalMovement.magnitude < MinDistance * touchManager.DotsPerCentimeter)
//                 {
//                     setState(GestureState.Failed);
//                 }
//                 else
//                 {
//                     ScreenFlickVector = totalMovement;
//                     ScreenFlickTime = Time.timeSinceLevelLoad - lastTime;
//                     setState(GestureState.Recognized);
//                 }
//             }
//         }

//         protected override void touchesCancelled(IList<ITouch> touches)
//         {
//             base.touchesCancelled(touches);

//             touchesEnded(touches);
//         }

//         protected override void onRecognized()
//         {
//             base.onRecognized();
//             if (flickedInvoker != null) flickedInvoker(this, EventArgs.Empty);
//             if (UseSendMessage) SendMessageTarget.SendMessage(FLICK_MESSAGE, this, SendMessageOptions.DontRequireReceiver);
//         }

//         protected override void reset()
//         {
//             base.reset();

//             isActive = false;
//             moving = false;
//             movementBuffer = Vector2.zero;
//         }
//     }
// }