using System;
namespace _Battery
{
		public enum SceneStep
		{
		Wall1
		,Wall2 
		,Wall3 
		,Wall4 
		,Wall5
	};

	public enum BatteryStep
	{
		Wall1
		,Wall2 
		,Wall3 
		,Wall4 
		,Wall5
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