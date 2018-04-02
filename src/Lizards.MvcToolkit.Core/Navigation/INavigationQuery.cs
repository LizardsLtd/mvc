using System.Collections.Generic;
using Picums.Web.Shared;

namespace Lizards.MvcToolkit..Navigation
{
	public interface INavigationItemQuery
	{
		INavigationItemQuery FilterBasedOnUserAuthenticationStatus(bool userIsAuthenticated);

		INavigationItemQuery IncludeItemsBySections(IEnumerable<string> collectionName);

		INavigationItemQuery FilterByLevels(IEnumerable<int> levels);

		IEnumerable<NavigationItem> Build();
	}
}