module Lizards.MvcToolkit.FeatureSlices.Tests.GroupedLocationAttributeFixture

open System
open Xunit
open FsUnit.Xunit
open Lizards.MvcToolkit.FeatureSlices

[<Fact>]
let ``Can set group name`` () =
    let groupName = "Test name"
    let testObject = new GroupedLocationAttribute(groupName)
    testObject.GrupeName |> should equal groupName
