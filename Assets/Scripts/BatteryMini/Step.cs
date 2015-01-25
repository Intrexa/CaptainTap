using System;
namespace _Battery
{
		public enum SceneStep
		{
		start 
		,removeOld 
		,grabNew 
		,insertNew 
		,end 
	};

	public enum BatteryStep
	{
		start 
		,moveMid 
		,moveEnd 
		,end 
	};

	public enum TouchType
	{
		tapAction
		,upSwipeAction
		,leftSwipeAction
		,downSwipeAction
		,rightSwipeAction
	};

	public enum TouchPattern
	{
		swipe_swipe
		,touch_swipe
	};

	public enum Performance
	{
		perfect
		,partial
		,miss
	};
}