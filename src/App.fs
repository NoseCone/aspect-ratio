module App

open Sutil
open Sutil.DOM
open Sutil.Attr

type Page = | PickComp | CompSettings | CompTasks | CompPilots

type Model = { Page : Page }
type Message = | SetPage of Page
let init () : Model = { Page = PickComp }
let getPage (m : Model) = m.Page

let update (msg : Message) (model : Model) : Model =
    match msg with
    | SetPage page -> { model with Page = page }

// In Sutil, the view() function is called *once*
let view() =

    let model, dispatch = () |> Store.makeElmishSimple init update ignore

    Html.div [
        // Get used to doing this for components, even though this is a top-level app.
        disposeOnUnmount [ model ]

        // Think of this line as
        // text $"Counter = {model.counter}"
        Bind.fragment (model |> Store.map getPage) <| fun n ->
            text $"Page = {n}"

        Html.div [
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
