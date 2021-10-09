using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppNginx.Data
{
	public interface ICircuitCounter
	{
		int ConnectionCount { get; }
	}

	public class AppCircuitHandler : CircuitHandler, ICircuitCounter
	{
		public int _connectionCounter;

		public int ConnectionCount
		{
			get { return _connectionCounter; }
		}

		public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
		{
			Interlocked.Increment(ref _connectionCounter);
			return base.OnCircuitOpenedAsync(circuit, cancellationToken);
		}

		public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
		{
			return base.OnConnectionUpAsync(circuit, cancellationToken);
		}

		public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
		{
			return base.OnConnectionDownAsync(circuit, cancellationToken);
		}

		public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
		{
			Interlocked.Decrement(ref _connectionCounter);
			return base.OnCircuitClosedAsync(circuit, cancellationToken);
		}
	}
}
