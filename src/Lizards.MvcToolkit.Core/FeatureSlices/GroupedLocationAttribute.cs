namespace Lizzards.MvcToolkit.Core.FeatureSlices
{
  using System;
  using Microsoft.AspNetCore.Mvc.ActionConstraints;

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
