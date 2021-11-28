module App

open Sutil
open Sutil.DOM
open Sutil.Attr

open Types

let breadcrumb (compName: string) = Html.nav [
        class' "breadcrumb"
        Html.ul [
            Html.li [
                Html.a [
                    Attr.href "/"
                    text "Leading Edge (Sutil)"
                ]
            ]
            Html.li [
                class' "is-active"
                text compName
            ]
        ]
    ]

let spacer = Html.div [ class' "spacer" ]

let compTabs (setTab: Tab -> Unit) (tab: Tab): SutilElement =
    let isActive expected = if tab = expected then "is-active" else ""
    Html.div [
        class' "tabs"
        Html.ul [
            Html.li [
                class' (isActive TabSettings)
                onClick (fun _ -> setTab TabSettings) []
                Html.a [ text "Settings" ]
            ]
            Html.li [
                class' (isActive TabTasks)
                onClick (fun _ -> setTab TabTasks) []
                Html.a [ text "Tasks" ]
            ]
            Html.li [
                class' (isActive TabPilots)
                onClick (fun _ -> setTab TabPilots) []
                Html.a [ text "Pilots" ]
            ]
        ]
    ]

let view () =

    let compPrefix = Store.make (CompPrefix "")
    let comp = Store.make Comp.Null
    let nominals = Store.make Nominals.Null
    let compTasks = Store.make []
    let compPilots = Store.make []
    let taskLengths = Store.make []

    let page = Store.make PageComps
    let tab = Store.make TabTasks

    let setPage p = page |> Store.modify (fun _ -> p)
    let setTab t = tab |> Store.modify (fun _ -> t)

    Html.div [
        disposeOnUnmount [ page; tab ]

        Bind.el(page, function
            | PageComps ->
                Comps.view compPrefix comp nominals compTasks compPilots taskLengths page tab
            | PageComp ->
                fragment [
                    Bind.el(comp, fun c -> breadcrumb c.compName)

                    Bind.el(tab, fun t -> compTabs setTab t)

                    Bind.el(tab, function
                        | TabSettings -> Html.pre [ text "Settings" ]
                        | TabTasks -> Html.pre [ text "Tasks" ]
                        | TabPilots -> Html.pre [ text "Pilots" ])
                ])
    ]

view () |> Program.mountElement "sutil"
