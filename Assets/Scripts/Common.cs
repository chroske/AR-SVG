using UnityEngine;
using System.Collections;

namespace Common
{
	public static class Define
	{
		//この距離を離れたらオブジェクトを破棄(ﾒｰﾄﾙ)
		public const int LIMIT_DISTANCE = 2000;
		//1mあたりの経度
		public const decimal ONE_METER_LONGITUDE = 0.000010966382364m;
		//1mあたりの緯度
		public const decimal ONE_METER_LATITUDO = 0.000008983148616m;
		//見やすくするために実際の距離にこの数字をかけて表示する
		public const int REGULATE_VAL = 25;
	}
}