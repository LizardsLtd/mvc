using Microsoft.AspNetCore.Mvc;

namespace Lizards.MvcToolkit..Navigation
{
	public interface IRequireUrlHelper<out TResult>
	{
		TResult WithUrlHelper(IUrlHelper helper);
	}
}