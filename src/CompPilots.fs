module CompPilots

open Fable.Core
open Sutil
open Sutil.DOM
open Sutil.Attr
open Thoth.Json
open Thoth.Fetch

type PilotStatus =
    { pilotId: string
    ; pilotName: string
    ; pilotStatus: string list
    }
    static member Null =
        { pilotId = ""
        ; pilotName = ""
        ; pilotStatus = []
        }
    static member Decoder =
        Decode.list (Decode.list Decode.string) |> Decode.map (function
            | [[id; name]; status] ->
                { pilotId = id
                ; pilotName = name
                ; pilotStatus = status
                }
            | _ -> PilotStatus.Null)

let getCompPilots (comp : string) : JS.Promise<PilotStatus list> = promise {
    let url = sprintf "http://%s.flaretiming.com/json/gap-point/pilots-status.json" comp
    return! Fetch.get(url, decoder = Decode.list PilotStatus.Decoder)
}

let pilotRow (pilot: PilotStatus) = Html.tr [
        Html.td [
            class' "td-pid"
            text (string pilot.pilotId)
        ]
        Html.td pilot.pilotName
        yield!
            pilot.pilotStatus |> List.map (function
                | "" | "DF" -> Html.td []
                | s -> Html.td [ text s ])
    ]

let pilotsTable (taskNames: string list, pilots: PilotStatus list) = Html.table [
        class' "table is-bordered is-striped"
        Html.thead [
            Html.tr [
                Html.th [
                    class' "th-pid"
                    text "Id"
                ]
                Html.th "Name"
                yield! (taskNames |> List.map Html.th)
            ]
        ]
        Html.tbody (pilots |> List.map pilotRow)
    ]