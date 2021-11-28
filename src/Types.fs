module Types

open Fable.Core
open Thoth.Json
open Thoth.Fetch

type UtcOffset = { timeZoneMinutes: int }
type Radius = { radius: string }
type Give = { giveDistance: string option; giveFraction: float }
type Earth = { sphere: Radius }
type EarthMath = string

type Comp =
    { compName: string
    ; scoreBack: string option
    ; utcOffset: UtcOffset
    ; from: string
    ; ``to``: string
    ; location: string
    ; earth: Earth
    ; earthMath: EarthMath
    ; give: Give
    }
    static member Null =
        { compName = ""
        ; scoreBack = None
        ; utcOffset = { timeZoneMinutes = 0 }
        ; from = ""
        ; ``to`` = ""
        ; location = ""
        ; earth = { sphere = {radius = "" }}
        ; earthMath = ""
        ; give = { giveDistance = None; giveFraction = 0.0 }
        }
    member x.compSlug = sprintf "%s to %s, %s" x.from x.``to`` x.location

type Nominals =
    { free: string
    ; distance: string
    ; time: string
    ; goal: float
    }
    static member Null =
        { free = ""
        ; distance = ""
        ; time = ""
        ; goal = 0.0
        }

type TaskLength = string
type RawZone = { zoneName: string }
type Stopped = { announced: string; retroactive: string}

type Task =
    { taskName: string
    ; zones: {| raw: RawZone list |}
    ; stopped: Stopped option
    ; cancelled: bool option
    }

let mkTaskRows (tasks: Task list) (taskLengths: TaskLength list) =
    (tasks, taskLengths)
    ||> List.map2 (fun {taskName = t; zones = zs; stopped = s; cancelled = c} d ->
        {| taskName = t
        ; tps = zs.raw |> List.map (fun z -> z.zoneName) |> String.concat "-"
        ; distance = d
        ; stopped = if Option.isSome s then true else false
        ; cancelled = Option.defaultValue false c
        |})

let getComp (comp : string) : JS.Promise<Comp> = promise {
    let url = sprintf "http://%s.flaretiming.com/json/comp-input/comps.json" comp
    return! Fetch.get url
}

let getNominals (comp : string) : JS.Promise<Nominals> = promise {
    let url = sprintf "http://%s.flaretiming.com/json/comp-input/nominals.json" comp
    return! Fetch.get url
}

let getTaskLengths (comp : string) : JS.Promise<TaskLength list> = promise {
    let url = sprintf "http://%s.flaretiming.com/json/task-length/task-lengths.json" comp
    return! Fetch.get url
}

let getCompTasks (comp : string) : JS.Promise<Task list> = promise {
    let url = sprintf "http://%s.flaretiming.com/json/comp-input/tasks.json" comp
    return! Fetch.get url
}

type CompPrefix = CompPrefix of string
type Page = | PageComps | PageComp
type Tab = TabSettings | TabTasks | TabPilots