module App

open Sutil
open Sutil.DOM
open Sutil.Attr

type Page = | PickComp | CompSettings | CompTasks | CompPilots
type CompTab = Settings | Tasks | Pilots

let pageToTab : Page -> CompTab option = function
    | PickComp -> None
    | CompSettings -> Some Settings
    | CompTasks -> Some Tasks
    | CompPilots -> Some Pilots

let tabToPage : CompTab -> Page = function
    | Settings -> CompSettings
    | Tasks -> CompTasks
    | Pilots -> CompPilots

type Model = { Page : Page }

type Message =
    | SetPage of Page
    | SetTab of CompTab option

let init () : Model = { Page = PickComp }
let getPage (m : Model): Page = m.Page
let getTab (m : Model): CompTab option = pageToTab m.Page

let update (msg : Message) (model : Model) : Model =
    match msg with
    | SetPage page -> { model with Page = page }
    | SetTab tab -> { model with Page = tab |> Option.map tabToPage |> Option.defaultValue PickComp }

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

let compTabs (setTab: CompTab -> Unit) (tab: CompTab): SutilElement =
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

let view() =

    let model, dispatch = () |> Store.makeElmishSimple init update ignore

    Html.div [
        disposeOnUnmount [ model ]

        Bind.fragment (Store.map getPage model) <| fun n -> text $"Page = {n}"

        Html.div [
            breadcrumb "COMP"

            Bind.fragment (Store.map getTab model) <| function
                | None -> Html.div []
                | Some tab ->
                    compTabs
                        (dispatch << SetTab << Some)
                        tab

            Html.button [
                class' "button"
                onClick (fun _ -> dispatch <| SetPage PickComp) []
                text "Comps"
            ]

            Html.button [
                class' "button"
                onClick (fun _ -> dispatch <| SetPage CompSettings) []
                text "Settings"
            ]

            Html.button [
                class' "button"
                onClick (fun _ -> dispatch <| SetPage CompTasks) []
                text "Tasks"
            ]

            Html.button [
                class' "button"
                onClick (fun _ -> dispatch <| SetPage CompPilots) []
                text "Pilots"
            ]
        ]]

view() |> Program.mountElement "sutil"
