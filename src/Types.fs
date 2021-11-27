module Types

type Page = | PickComp | CompSettings | CompTasks | CompPilots
type Tab = Settings | Tasks | Pilots

let pageToTab : Page -> Tab option = function
    | PickComp -> None
    | CompSettings -> Some Settings
    | CompTasks -> Some Tasks
    | CompPilots -> Some Pilots

let tabToPage : Tab -> Page = function
    | Settings -> CompSettings
    | Tasks -> CompTasks
    | Pilots -> CompPilots
