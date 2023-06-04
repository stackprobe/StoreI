using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Adventures.Rooms;

namespace Charlotte.Games.Adventures
{
	public class ADGame : IDisposable
	{
		public static ADGame I;

		public ADGame()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public ADRoom Room;

		public void Run(ADRoom room)
		{
			throw null; // TODO
		}
	}
}
