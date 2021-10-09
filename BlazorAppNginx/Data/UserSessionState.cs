using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppNginx.Data
{
	public class UserSessionState
	{
		public HostData InitialHost { get; private set; }
		public DateTime InitialHostAssignedDate { get; set; }
		public int Counter { get; private set; }

		public void SetInitialHost(HostData hostData)
		{
			if (InitialHost is null)
			{
				this.InitialHost = hostData;
				this.InitialHostAssignedDate = DateTime.UtcNow;
			}
		}

		public void IncrementCount()
		{
			Counter += 1;
		}
	}

	public class HostData
	{
		public string Name { get; set; }
		public IEnumerable<string> IPs { get; set; }

		public HostData(string name, IEnumerable<string> ips)
		{
			Name = name;
			IPs = ips;
		}
	}
}
