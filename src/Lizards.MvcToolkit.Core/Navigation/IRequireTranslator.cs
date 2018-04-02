using Microsoft.Extensions.Localization;

namespace Lizards.MvcToolkit.Navigation
{
	public interface IRequireTranslator<out TResult>
	{
		TResult WithTranslator(IStringLocalizer translator);
	}
}