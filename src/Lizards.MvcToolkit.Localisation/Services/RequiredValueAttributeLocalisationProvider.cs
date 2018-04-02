using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;

namespace Lizards.MvcToolkit.Localisation.Services
{
	public sealed class RequiredValueAttributeLocalisationProvider : IDisplayMetadataProvider
	{
		private IStringLocalizer localiser;

		public RequiredValueAttributeLocalisationProvider(IStringLocalizer localiser)
		{
			this.localiser = localiser;
		}

		public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
			=> context
				.PropertyAttributes
				?.Where(attribute => attribute is RequiredValueAttribute)
				.Cast<RequiredValueAttribute>()
				.ToList()
				.ForEach(x => x.TranslatErrorMessage(localiser));
	}
}