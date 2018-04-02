﻿module Picums.Tests.Search.Keywords

open System
open System.Linq
open Xunit
open FsUnit.Xunit
open Microsoft.Spatial
open Newtonsoft.Json
open Microsoft.Extensions.Logging
open FakeItEasy
open Picums.Search.Azure.KeyWords

[<Fact>]
let ``Location keyword can work with locale using comma to separate double`` () =
    let keyword = new LocationFilter(10.0, 10.0, "Location", 25)
    let result = keyword.GetFilter()
    result |> should equal "geo.distance(Location, geography'POINT(10 10)') lt 25"

[<Fact>]
let ``Fuzzy Match generate required search phrase`` () =
    let keyword = new FuzzyMatchSearch("keyword")
    let result = keyword.GetSearchText()
    result |> should equal "keyword*"