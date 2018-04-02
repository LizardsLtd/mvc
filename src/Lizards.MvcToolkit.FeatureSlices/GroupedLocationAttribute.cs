﻿using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Lizards.MvcToolkit.FeatureSlices
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class GroupedLocationAttribute : Attribute, IActionConstraintMetadata
	{
		public GroupedLocationAttribute(string groupName)
		{
			this.GrupeName = groupName;
		}

		public string GrupeName { get; }
	}
}