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
                class' (isActive Settings)
                onClick (fun _ -> setTab Settings) []
                Html.a [ text "Settings" ]
            ]
            Html.li [
                class' (isActive Tasks)
                onClick (fun _ -> setTab Tasks) []
                Html.a [ text "Tasks" ]
            ]
            Html.li [
                class' (isActive Pilots)
                onClick (fun _ -> setTab Pilots) []
                Html.a [ text "Pilots" ]
            ]
        ]
    ]

let view () =

    let page = Store.make PickComp
    let tab: IStore<Tab option> = Store.make None

    let setPage p _ = page |> Store.modify (fun _ -> p)
    let setTab t = tab |> Store.modify (fun _ -> t)

    Html.div [
        disposeOnUnmount [ page; tab ]

        Html.div [
            Html.button [
                class' "button"
                onClick (setPage PickComp) []
                text "Comps"
            ]

            Html.button [
                class' "button"
                onClick (setPage CompSettings) []
                text "Settings"
            ]

            Html.button [
                class' "button"
                onClick (setPage CompTasks) []
                text "Tasks"
            ]

            Html.button [
                class' "button"
                onClick (setPage CompPilots) []
                text "Pilots"
            ]

            Bind.el(tab, function
                | None -> Html.div []
                | Some tab -> compTabs (setTab << Some) tab)
        ]

        Bind.el(page, fun p -> text $"Page = {p}")

        breadcrumb "COMP"

        Bind.el(page, function
            | PickComp -> Comps.view (page, tab)
            | CompSettings -> Html.pre [ text "Settings" ]
            | CompTasks -> Html.pre [ text "Tasks" ]
            | CompPilots -> Html.pre [ text "Pilots" ])
    ]

view () |> Program.mountElement "sutil"
