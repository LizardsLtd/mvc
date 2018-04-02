using System;

namespace Lizards.MvcToolkit.Navigation
{
	public interface IMenuAttribute : IEquatable<IMenuAttribute>
	{
		string Section { get; }

		string Name { get; }

		int OrderNumber { get; }

		int Level { get; }
	}
}