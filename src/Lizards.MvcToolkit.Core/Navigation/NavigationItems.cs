using System.Collections.Generic;
using System.Linq;
using INavigationQueryWithUrlHelper =
	Lizards.MvcToolkit..Navigation.IRequireUrlHelper<Lizards.MvcToolkit..Navigation.INavigationItemQuery>;

namespace Lizards.MvcToolkit..Navigation
{
	public sealed class NavigationItems
	{
		private List<NavigationPrototype> navigationItems;

		public NavigationItems()
		{
		}

		public void AddRange(IEnumerable<NavigationPrototype> navigationItems)
		{
			this.navigationItems = navigationItems.ToList();
		}

		public IRequireTranslator<INavigationQueryWithUrlHelper> GetQuery()
			=> new NavigationQuery(this.navigationItems);
	}
}