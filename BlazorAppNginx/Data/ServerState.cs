using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppNginx.Data
{
	public class ServerState
	{
		private readonly ICircuitCounter circuitCounter;

		public int ConnectionsCount { get { return circuitCounter.ConnectionCount; } }

		public ServerState(ICircuitCounter circuitCounter)
		{
			this.circuitCounter = circuitCounter;
		}
	}
}
