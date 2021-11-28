module CompSettings

open Sutil
open Sutil.DOM
open Sutil.Attr

let settingsTable (settings: {| giveFraction: float; earthRadius: string; earthMath: string |}) = Html.table [
        class' "table is-bordered"
        Html.thead [
            Html.tr [
                Html.th [
                    Attr.colSpan 3
                ]
                Html.th "Value"
            ]
        ]
        Html.tbody [
            Html.tr [
                Html.th "* Give"
                Html.td [
                    Attr.colSpan 2
                    text "give fraction only, no give distance"
                ]
                Html.td (string settings.giveFraction)
            ]
            Html.tr [
                Html.th "Earth model"
                Html.td [
                    Attr.colSpan 2
                    text "Sphere with radius"
                ]
                Html.td settings.earthRadius
            ]
            Html.tr [
                Html.th [
                    Attr.colSpan 3
                    text "Earth math"
                ]
                Html.td settings.earthMath
            ]
        ]
        Html.tfoot [
            Html.tr [
                Html.td [
                    Attr.colSpan 4
                    text "* Adjusting the turnpoint radius with some give for pilots just short of the control zone"
                ]
            ]
        ]
    ]