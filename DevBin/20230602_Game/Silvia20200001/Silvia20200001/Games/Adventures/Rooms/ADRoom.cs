using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Games.Adventures.Rooms
{
	public abstract class ADRoom
	{
		public abstract ADRoom DefaultActionAndGetNextRoom();

		private Func<bool> _draw = null;

		public void Draw()
		{
			if (_draw == null)
				_draw = SCommon.Supplier(this.E_Draw());

			if (!_draw())
				throw null; // never
		}

		/// <summary>
		/// 描画を行う。
		/// </summary>
		/// <returns>タスク：常に真</returns>
		protected abstract IEnumerable<bool> E_Draw();
	}
}
