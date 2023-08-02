﻿using System.Threading;
using System.Threading.Tasks;

namespace Primer.Models
{
	public interface ICustomController
	{
		Task<long> GetPageSize(CancellationToken cToken);
	}
}
