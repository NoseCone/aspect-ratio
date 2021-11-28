module App

open Sutil
open Sutil.DOM
open Sutil.Attr

open Types
open CompSettings
open CompTasks
open CompPilots
open CompHeader

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
    let activeTab = Store.make TabTasks

    let setPage p = page |> Store.modify (fun _ -> p)
    let setActiveTab t = activeTab |> Store.modify (fun _ -> t)

    Html.div [
        disposeOnUnmount [
            compPrefix
            comp
            nominals
            compTasks
            compPilots
            taskLengths
            page
            activeTab
        ]

        Bind.el(page, function
            | PageComps ->
                Comps.view compPrefix comp nominals compTasks compPilots taskLengths page activeTab
            | PageComp ->
                Bind.el(activeTab, function
                    | TabTasks ->
                        Html.div
                            [ spacer
                            ; Bind.el2 comp nominals (fun (c, ns) -> compHeader c ns)
                            ; spacer
                            ; Bind.el(comp, fun c -> breadcrumb c.compName)
                            ; Bind.el(activeTab, fun t -> compTabs setActiveTab t)
                            ; Bind.el2 compTasks taskLengths (fun (ts, ls) -> tasksTable (mkTaskRows ts ls))
                            ]
                    | TabSettings ->
                        Html.div
                            [ spacer
                            ; Bind.el2 comp nominals (fun (c, ns) -> compHeader c ns)
                            ; spacer
                            ; Bind.el(comp, fun c -> breadcrumb c.compName)
                            ; Bind.el(activeTab, fun t -> compTabs setActiveTab t)
                            ; Bind.el(comp, fun c ->
                                settingsTable
                                    {| giveFraction = c.give.giveFraction
                                    ; earthRadius = c.earth.sphere.radius
                                    ; earthMath = c.earthMath
                                    |})
                            ]
                    | TabPilots ->
                        Html.div
                            [ spacer
                            ; Bind.el2 comp nominals (fun (c, ns) -> compHeader c ns)
                            ; spacer
                            ; Bind.el(comp, fun c -> breadcrumb c.compName)
                            ; Bind.el(activeTab, fun t -> compTabs setActiveTab t)
                            ; Bind.el2 compTasks compPilots (fun (ts, ps) -> pilotsTable (ts |> List.map (fun x -> x.taskName), ps))
                            ]))
    ]

view () |> Program.mountElement "sutil"
