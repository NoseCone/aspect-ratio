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
                    text "Leading Edge (Feliz)"
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
    let page = Store.make PageComps
    let tab= Store.make TabTasks

    let setPage p = page |> Store.modify (fun _ -> p)
    let setTab t = tab |> Store.modify (fun _ -> t)

    Html.div [
        disposeOnUnmount [ page; tab ]

        Html.div [
            Html.button [
                class' "button"
                onClick (fun _ -> setPage PageComps) []
                text "Comps"
            ]

            Html.button [
                class' "button"
                onClick (fun _ -> setPage PageComp) []
                text "Comp"
            ]
        ]

        spacer
        Bind.el(compPrefix, fun cp -> text $"CompPrefix = {cp}")
        spacer
        Bind.el(page, fun p -> text $"Page = {p}")
        spacer

        breadcrumb "COMP"

        Bind.el(page, function
            | PageComps -> Comps.view (compPrefix, page, tab)
            | PageComp ->
                fragment [
                    Bind.el(tab, fun t -> compTabs setTab t)

                    Bind.el(tab, function
                        | TabSettings -> Html.pre [ text "Settings" ]
                        | TabTasks -> Html.pre [ text "Tasks" ]
                        | TabPilots -> Html.pre [ text "Pilots" ])
                ])
    ]

view () |> Program.mountElement "sutil"
